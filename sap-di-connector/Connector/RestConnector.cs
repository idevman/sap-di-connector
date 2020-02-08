using log4net;
using IDevman.SAPConnector.DBMS;
using System.Collections.Generic;
using System.Reflection;
using IDevman.SAPConnector.Extensions;

namespace IDevman.SAPConnector.Connector
{

    /// <summary>
    /// Data connector class
    /// </summary>
    /// <typeparam name="TModel">Default type</typeparam>
    /// <typeparam name="TRest">Rest data</typeparam>
    public abstract class RestConnector<TModel, TRest> : IRestConnector
    {

        /// <summary>
        /// Logger utillity
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(
            MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Store fetched data
        /// </summary>
        private DataFetched<TRest> DataFetched = new DataFetched<TRest>();

        /// <summary>
        /// Retrieve if Data fetched is not empty
        /// </summary>
        public bool Fetched => !DataFetched.Empty;

        /// <summary>
        /// Use last sync date to download the data from API
        /// </summary>
        /// <param name="lastSyncTime">Last download time (as Unix time)</param>
        /// <returns>If was some data retrieved</returns>
        public void Download(long lastSyncTime)
        {
            DataFetched = new DataFetched<TRest>();
            if (this is ISyncDownload<TModel, TRest> downloader)
            {
                logger.Debug("Fetching changes");
                List<TRest> response = downloader.Pull(lastSyncTime);
                if (response != null && response.Count > 0)
                {
                    logger.Info("Fetched " + response.Count + " records");
                    if (downloader.AllowNew)
                    {
                        DataFetched.NewRecords.AddRange(response.FindAll(x => downloader.IsNew(x)));
                    }
                    if (downloader.AllowUpdate)
                    {
                        DataFetched.ExistingRecords.AddRange(response.FindAll(x => !downloader.IsNew(x)));
                    }
                }
            }
        }

        /// <summary>
        /// Upload to warehouse system
        /// </summary>
        /// <param name="db">Database connection</param>
        /// <param name="lastSyncTime">Last synchronization time (Unix time)</param>
        /// <param name="commitTime">Commiting time (Unix time)</param>
        public void Upload(DBConnection db, long lastSyncTime, long commitTime)
        {
            if (this is ISyncUpload<TModel, TRest> uploader)
            {
                logger.Debug("Loading local changes");
                List<TModel> records = uploader.LoadLocal(db, lastSyncTime.AsUnixTime());
                if (records != null && records.Count > 0)
                {
                    logger.Info("Found " + records.Count + " records since: " + lastSyncTime.AsUnixTimeString());
                    for (int i = 0; i < records.Count; i += uploader.PageSize)
                    {
                        int size = records.Count - i;
                        if (size > uploader.PageSize)
                        {
                            size = uploader.PageSize;
                        }
                        uploader.Push(records.GetRange(i, size));
                        logger.Info("Uploading " + (100f * i / records.Count) + "%");
                    }
                    logger.Info("Uploading 100%");
                    uploader.Commit(commitTime);
                }
            }
        }

        /// <summary>
        /// Store SAP data based on fetched data
        /// </summary>
        /// <param name="sap">SAP connection</param>
        /// <param name="db">Database connection</param>
        /// <param name="commitTime">Commit time (Unix time)</param>
        public void SapStore(SAPConnection sap, DBConnection db, long commitTime)
        {
            if (!DataFetched.Empty && this is ISyncDownload<TModel, TRest> downloader)
            {
                logger.Debug("Storing data");
                bool hasChanges = false;
                if (DataFetched.NewRecords.Count > 0)
                {
                    foreach (TRest i in DataFetched.NewRecords)
                    {
                        downloader.Create(db, sap, i);
                    }
                    hasChanges = true;
                }
                if (DataFetched.ExistingRecords.Count > 0)
                {
                    foreach (TRest i in DataFetched.ExistingRecords)
                    {
                        downloader.Update(db, sap, i);
                    }
                    hasChanges = true;
                }
                if (hasChanges)
                {
                    downloader.CommitFetch(commitTime);
                }
            }
        }

    }

}
