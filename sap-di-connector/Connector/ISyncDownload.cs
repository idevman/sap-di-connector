using IDevman.SAPConnector.DBMS;
using System;
using System.Collections.Generic;

namespace IDevman.SAPConnector.Connector
{

    /// <summary>
    /// Provide method access to download and sync data
    /// </summary>
    /// <typeparam name="TModel">Default type</typeparam>
    /// <typeparam name="TRest">Rest data</typeparam>
    public interface ISyncDownload<TModel, TRest>
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
        bool IsNew(TRest record);

        /// <summary>
        /// Execute pull action
        /// </summary>
        /// <param name="lastSyncDate">Last sync date</param>
        /// <returns></returns>
        List<TRest> Pull(DateTime lastSyncDate);

        /// <summary>
        /// Commit fetch sync data
        /// </summary>
        /// <param name="commitDate">Confirm date</param>
        /// <returns></returns>
        void CommitFetch(DateTime commitDate);

        /// <summary>
        /// Create new record to sate
        /// </summary>
        /// <param name="connection">Database connection</param>
        /// <param name="sap">Sap connection</param>
        /// <param name="record">Record to create</param>
        /// <returns></returns>
        TModel Create(DBConnection connection, SAPConnection sap, TRest record);

        /// <summary>
        /// Update record to sate
        /// </summary>
        /// <param name="connection">Database connection</param>
        /// <param name="sap">Sap connection</param>
        /// <param name="document">Document to create</param>
        /// <returns></returns>
        TModel Update(DBConnection connection, SAPConnection sap, TRest document);

    }

}
