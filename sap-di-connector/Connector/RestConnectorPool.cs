using IDevman.SAPConnector.DBMS;
using System.Collections.Generic;

namespace IDevman.SAPConnector.Connector
{

    /// <summary>
    /// Used to collect rest connectors and sync in single step avoiding complex logic in multiple scenarios
    /// </summary>
    public class RestConnectorPool
    {

        /// <summary>
        /// Connectors to execute for sincronization
        /// </summary>
        public List<IRestConnector> Connectors { get; } = new List<IRestConnector>();

        /// <summary>
        /// Synchornize all connectors
        /// </summary>
        /// <param name="lastSyncTime"></param>
        /// <param name="commitTime"></param>
        public virtual void Sync(long lastSyncTime, long commitTime)
        {
            if (Connectors.Count > 0)
            {
                // Creating database connection
                using (DBConnection db = new DBConnection())
                {
                    bool fetched = false;
                    foreach (IRestConnector connector in Connectors)
                    {
                        // Upload to API
                        if (connector is IUpload upload)
                        {
                            upload.Upload(db, lastSyncTime, commitTime);
                        }
                        // Download from API
                        if (connector is IDownload download)
                        {
                            download.Download(lastSyncTime);
                        }
                        fetched |= connector.Fetched;
                    }
                    // Store in SAP (Openning SAP is highly cost, so open just when required)
                    if (fetched)
                    {
                        using (SAPConnection sap = new SAPConnection())
                        {
                            foreach (IRestConnector connector in Connectors)
                            {
                                if (connector.Fetched)
                                {
                                    connector.SapStore(sap, db, commitTime);
                                }
                            }
                        }
                    }
                }
            }
        }

    }

}
