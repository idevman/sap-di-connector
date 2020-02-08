using Silifalcon.Rest.Connection;
using IDevman.SAPConnector.DBMS;
using System;
using System.Collections.Generic;

namespace IDevman.SAPConnector.Connector
{

    /// <summary>
    /// Provide method access to download and sync data
    /// </summary>
    /// <typeparam name="T">Default type</typeparam>
    /// <typeparam name="U">Rest data</typeparam>
    public interface ISyncDownload<T, U>
    {

        /// <summary>
        /// Define if sync process allow create records from external system
        /// </summary>
        bool AllowNew { get; }

        /// <summary>
        /// Define if sync process allow update records from external system
        /// </summary>
        bool AllowUpdate { get; }

        /// <summary>
        /// If is new record
        /// </summary>
        /// <param name="record">Record to evaluate</param>
        /// <returns></returns>
        bool IsNew(U record);

        /// <summary>
        /// Execute pull action
        /// </summary>
        /// <param name="rest">Rest connection</param>
        /// <param name="lastSyncDate">Last sync date</param>
        /// <returns></returns>
        List<U> Pull(RestClient rest, DateTime lastSyncDate);

        /// <summary>
        /// Commit fetch sync data
        /// </summary>
        /// <param name="rest">Rest connection</param>
        /// <param name="commitDate">Confirm date</param>
        /// <returns></returns>
        void CommitFetch(RestClient rest, DateTime commitDate);

        /// <summary>
        /// Create new record to sate
        /// </summary>
        /// <param name="connection">Database connection</param>
        /// <param name="sap">Sap connection</param>
        /// <param name="record">Record to create</param>
        /// <returns></returns>
        T Create(DBConnection connection, SAPConnection sap, U record);

        /// <summary>
        /// Update record to sate
        /// </summary>
        /// <param name="connection">Database connection</param>
        /// <param name="sap">Sap connection</param>
        /// <param name="document">Document to create</param>
        /// <returns></returns>
        T Update(DBConnection connection, SAPConnection sap, U document);

    }

}
