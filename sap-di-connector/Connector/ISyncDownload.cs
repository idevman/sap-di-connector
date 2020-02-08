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
    public interface ISyncDownload<TModel, TRest> : IDownload
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
        /// <param name="lastSyncTime">Last sync time (as Unix time)</param>
        /// <returns></returns>
        List<TRest> Pull(long lastSyncTime);

        /// <summary>
        /// Commit fetch sync data
        /// </summary>
        /// <param name="commitTime">Confirm time (as Unix time)</param>
        /// <returns></returns>
        void CommitFetch(long commitTime);

        /// <summary>
        /// Create new record to sate
        /// </summary>
        /// <param name="db">Database connection</param>
        /// <param name="sap">Sap connection</param>
        /// <param name="record">Record to create</param>
        /// <returns></returns>
        TModel Create(DBConnection db, SAPConnection sap, TRest record);

        /// <summary>
        /// Update record to sate
        /// </summary>
        /// <param name="db">Database connection</param>
        /// <param name="sap">Sap connection</param>
        /// <param name="document">Document to create</param>
        /// <returns></returns>
        TModel Update(DBConnection db, SAPConnection sap, TRest document);

    }

}
