using IDevman.SAPConnector.DBMS;

namespace IDevman.SAPConnector.Connector
{

    /// <summary>
    /// Interface to group rest connectors
    /// </summary>
    public interface IRestConnector
    {

        /// <summary>
        /// Retrieve if Data fetched is not empty
        /// </summary>
        bool Fetched { get; }

        /// <summary>
        /// Store SAP data based on fetched data
        /// </summary>
        /// <param name="sap">SAP connection</param>
        /// <param name="db">Database connection</param>
        /// <param name="commitTime">Commit time (Unix time)</param>
        void SapStore(SAPConnection sap, DBConnection db, long commitTime);

    }

}
