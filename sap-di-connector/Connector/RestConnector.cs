using log4net;
using Silifalcon.Rest.Connection;
using IDevman.SAPConnector.DBMS;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace IDevman.SAPConnector.Connector
{

    /// <summary>
    /// Data connector class
    /// </summary>
    /// <typeparam name="T">Default type</typeparam>
    /// <typeparam name="U">Rest data</typeparam>
    public abstract class RestConnector<T, U>
    {

        /// <summary>
        /// Logger utillity
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(
            MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Download process handler
        /// </summary>
        public ISyncDownload<T, U> SyncDownload { get; set; }

        /// <summary>
        /// Upload process handler
        /// </summary>
        public ISyncUpload<T, U> SyncUpload { get; set; }

        /// <summary>
        /// Use last sync date to download the transfers from API to upload SAP also
        /// </summary>
        /// <param name="connection">Database connection</param>
        /// <param name="rest">Rest client</param>
        /// <param name="lastSyncDate">Last download date</param>
        /// <returns>If was some data retrieved</returns>
        public Fetched<U> Fetch(DBConnection connection, RestClient rest, DateTime lastSyncDate)
        {
            if (SyncDownload == null)
            {
                throw new Exception("'SyncDownload' property not defined");
            }
            logger.Debug("Fetching changes");
            List<U> response = SyncDownload.Pull(rest, lastSyncDate);
            if (response != null && response.Count > 0)
            {
                logger.Info("Fetched " + response.Count + " records");
                return new Fetched<U>
                {
                    NewRecords = SyncDownload.AllowNew ? response.FindAll(x => SyncDownload.IsNew(x)) : null,
                    ExistingRecords = SyncDownload.AllowUpdate ? response.FindAll(x => !SyncDownload.IsNew(x)) : null
                };
            }
            return null;
        }

        /// <summary>
        /// Upload to warehouse system
        /// </summary>
        public void Upload(DBConnection connection, RestClient rest, DateTime lastSyncDate, DateTime confirmDate)
        {
            if (SyncUpload == null)
            {
                throw new Exception("'SyncUpload' property not defined");
            }
            logger.Debug("Loading local changes");
            List<T> records = SyncUpload.LoadLocal(connection, lastSyncDate);
            if (records != null && records.Count > 0)
            {
                logger.Info("Found " + records.Count + " records since: "
                        + lastSyncDate.ToString("dd/MM/yyyy HH:mm:ss"));
                for (int i = 0; i < records.Count; i += SyncUpload.PageSize)
                {
                    int size = records.Count - i;
                    if (size > SyncUpload.PageSize)
                    {
                        size = SyncUpload.PageSize;
                    }
                    SyncUpload.Push(rest, records.GetRange(i, size));
                    logger.Info("Uploading " + (100f * i / records.Count) + "%");
                }
                logger.Info("Uploading 100%");
                SyncUpload.Commit(rest, confirmDate);
            }
        }

        /// <summary>
        /// Store SAP connection
        /// </summary>
        /// <param name="sap">SAP connection</param>
        /// <param name="connection">Database connection</param>
        /// <param name="rest">Rest connection</param>
        /// <param name="fetched">Fetched data</param>
        /// <param name="nowDate">Last sync date</param>
        public void Storing(SAPConnection sap,
                            DBConnection connection,
                            RestClient rest,
                            Fetched<U> fetched,
                            DateTime nowDate)
        {
            if (SyncDownload == null)
            {
                throw new Exception("'SyncDownload' property not defined");
            }
            if (fetched != null)
            {
                logger.Debug("Storing data");
                bool hasChanges = false;
                if (fetched.NewRecords != null && fetched.NewRecords.Count > 0)
                {
                    foreach (U i in fetched.NewRecords)
                    {
                        SyncDownload.Create(connection, sap, i);
                    }
                    hasChanges = true;
                }
                if (fetched.ExistingRecords != null && fetched.ExistingRecords.Count > 0)
                {
                    foreach (U i in fetched.ExistingRecords)
                    {
                        SyncDownload.Update(connection, sap, i);
                    }
                    hasChanges = true;
                }
                if (hasChanges)
                {
                    SyncDownload.CommitFetch(rest, nowDate);
                }
            }
        }

    }

}
