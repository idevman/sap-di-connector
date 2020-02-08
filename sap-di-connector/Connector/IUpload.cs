using IDevman.SAPConnector.DBMS;

namespace IDevman.SAPConnector.Connector
{

    /// <summary>
    /// Used to group Sync uploads
    /// </summary>
    public interface IUpload
    {

        /// <summary>
        /// Upload to warehouse system
        /// </summary>
        /// <param name="db">Database connection</param>
        /// <param name="lastSyncTime">Last synchronization time (Unix time)</param>
        /// <param name="commitTime">Commiting time (Unix time)</param>
        void Upload(DBConnection db, long lastSyncTime, long commitTime);

    }

}
