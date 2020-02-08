using log4net;
using IDevman.SAPConnector.DBMS;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Globalization;
using IDevman.SAPConnector.Extensions;

namespace IDevman.SAPConnector.Connector
{

    /// <summary>
    /// Data connector class
    /// </summary>
    /// <typeparam name="TModel">Default type</typeparam>
    /// <typeparam name="TRest">Rest data</typeparam>
    public abstract class RestConnector<TModel, TRest>
    {

        /// <summary>
        /// Logger utillity
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(
            MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Download process handler
        /// </summary>
        public ISyncDownload<TModel, TRest> SyncDownload { get; set; }

        /// <summary>
        /// Upload process handler
        /// </summary>
        public ISyncUpload<TModel, TRest> SyncUpload { get; set; }

        /// <summary>
        /// Use last sync date to download the transfers from API to upload SAP also
        /// </summary>
        /// <param name="lastSyncDate">Last download date</param>
        /// <returns>If was some data retrieved</returns>
        public Fetched<TRest> Fetch(DateTime lastSyncDate)
        {
            if (SyncDownload == null)
            {
                throw new Exception(string.Format(CultureInfo.InvariantCulture, Properties.Resources.PropertyNotFound, "SyncDownload"));
            }
            logger.Debug("Fetching changes");
            List<TRest> response = SyncDownload.Pull(lastSyncDate);
            if (response != null && response.Count > 0)
            {
                logger.Info("Fetched " + response.Count + " records");
                Fetched<TRest> fetched = new Fetched<TRest>();
                if (SyncDownload.AllowNew)
                {
                    fetched.NewRecords.AddRange(response.FindAll(x => SyncDownload.IsNew(x)));
                }
                if (SyncDownload.AllowUpdate)
                {
                    fetched.ExistingRecords.AddRange(response.FindAll(x => !SyncDownload.IsNew(x)));
                }
                return fetched;
            }
            return null;
        }

        /// <summary>
        /// Upload to warehouse system
        /// </summary>
        /// <param name="connection">Database connection</param>
        /// <param name="lastSyncTime">Last synchronization time (Unix time)</param>
        /// <param name="confirmDate">Confirming date</param>
        public void Upload(DBConnection connection, long lastSyncTime, DateTime confirmDate)
        {
            if (SyncUpload == null)
            {
                throw new Exception(string.Format(CultureInfo.InvariantCulture, Properties.Resources.PropertyNotFound, "SyncUpload"));
            }
            logger.Debug("Loading local changes");
            List<TModel> records = SyncUpload.LoadLocal(connection, lastSyncTime);
            if (records != null && records.Count > 0)
            {
                logger.Info("Found " + records.Count + " records since: " + lastSyncTime.AsUnixTimeString());
                for (int i = 0; i < records.Count; i += SyncUpload.PageSize)
                {
                    int size = records.Count - i;
                    if (size > SyncUpload.PageSize)
                    {
                        size = SyncUpload.PageSize;
                    }
                    SyncUpload.Push(records.GetRange(i, size));
                    logger.Info("Uploading " + (100f * i / records.Count) + "%");
                }
                logger.Info("Uploading 100%");
                SyncUpload.Commit(confirmDate);
            }
        }

        /// <summary>
        /// Store SAP connection
        /// </summary>
        /// <param name="sap">SAP connection</param>
        /// <param name="connection">Database connection</param>
        /// <param name="fetched">Fetched data</param>
        /// <param name="nowDate">Current date sync date</param>
        public void Storing(SAPConnection sap, DBConnection connection, Fetched<TRest> fetched, DateTime nowDate)
        {
            if (SyncDownload == null)
            {
                throw new Exception(string.Format(CultureInfo.InvariantCulture, Properties.Resources.PropertyNotFound, "SyncDownload"));
            }
            if (fetched != null)
            {
                logger.Debug("Storing data");
                bool hasChanges = false;
                if (fetched.NewRecords != null && fetched.NewRecords.Count > 0)
                {
                    foreach (TRest i in fetched.NewRecords)
                    {
                        SyncDownload.Create(connection, sap, i);
                    }
                    hasChanges = true;
                }
                if (fetched.ExistingRecords != null && fetched.ExistingRecords.Count > 0)
                {
                    foreach (TRest i in fetched.ExistingRecords)
                    {
                        SyncDownload.Update(connection, sap, i);
                    }
                    hasChanges = true;
                }
                if (hasChanges)
                {
                    SyncDownload.CommitFetch(nowDate);
                }
            }
        }

    }

}
