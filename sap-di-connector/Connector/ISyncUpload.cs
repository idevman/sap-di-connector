using Silifalcon.Rest.Connection;
using IDevman.SAPConnector.DBMS;
using System;
using System.Collections.Generic;

namespace IDevman.SAPConnector.Connector
{

    /// <summary>
    /// Provide method access to upload and sync data
    /// </summary>
    /// <typeparam name="T">Default type</typeparam>
    /// <typeparam name="U">Rest data</typeparam>
    public interface ISyncUpload<T, U>
    {

        /// <summary>
        /// Records to upload
        /// </summary>
        int PageSize { get; set; }

        /// <summary>
        /// Load from database
        /// </summary>
        /// <param name="connection">Database connection</param>
        /// <param name="lastSyncDate">Last sync date</param>
        /// <returns></returns>
        List<T> LoadLocal(DBConnection connection, DateTime lastSyncDate);

        /// <summary>
        /// Push documents
        /// </summary>
        /// <param name="rest">Rest connection</param>
        /// <param name="records">Documents to push</param>
        /// <returns></returns>
        void Push(RestClient rest, List<T> records);

        /// <summary>
        /// Commit sync data
        /// </summary>
        /// <param name="rest">Rest connection</param>
        /// <param name="commitDate">Confirm date</param>
        /// <returns></returns>
        void Commit(RestClient rest, DateTime commitDate);
    }

}
