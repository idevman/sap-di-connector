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
        public Dictionary<string, IRestConnector> Connectors { get; } = new Dictionary<string, IRestConnector>();

        /// <summary>
        /// Synchornize all connectors
        /// </summary>
        /// <param name="lastDownload">Last downloads times</param>
        /// <param name="lastUpload">Last upload times</param>
        /// <param name="commitTime">Commit times</param>
        public virtual void Sync(Dictionary<string, long> lastDownload, Dictionary<string, long> lastUpload, long commitTime)
        {
            if (Connectors.Count > 0 && lastDownload != null && lastUpload != null)
            {
                // Creating database connection
                using (DBConnection db = new DBConnection())
                {
                    bool fetched = false;
                    foreach (KeyValuePair<string, IRestConnector> connector in Connectors)
                    {
                        // Upload to API
                        if (connector.Value is IUpload upload)
                        {
                            long last = 0;
                            if (lastUpload.ContainsKey(connector.Key))
                            {
                                last = lastUpload[connector.Key];
                            }
                            upload.Upload(db, last, commitTime);
                        }
                        // Download from API
                        if (connector.Value is IDownload download)
                        {
                            long last = 0;
                            if (lastDownload.ContainsKey(connector.Key))
                            {
                                last = lastDownload[connector.Key];
                            }
                            download.Download(last);
                        }
                        fetched |= connector.Value.Fetched;
                    }
                    // Store in SAP (Openning SAP is highly cost, so open just when required)
                    if (fetched)
                    {
                        using (SAPConnection sap = new SAPConnection())
                        {
                            foreach (KeyValuePair<string, IRestConnector> connector in Connectors)
                            {
                                if (connector.Value.Fetched)
                                {
                                    connector.Value.SapStore(sap, db, commitTime);
                                }
                            }
                        }
                    }
                }
            }
        }

    }

}
