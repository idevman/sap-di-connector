﻿using IDevman.SAPConnector.DBMS;
using System;
using System.Collections.Generic;

namespace IDevman.SAPConnector.Connector
{

    /// <summary>
    /// Provide method access to upload and sync data
    /// </summary>
    /// <typeparam name="TRest">Rest data</typeparam>
    public interface ISyncUpload<TRest> : IUpload
    {

        /// <summary>
        /// Records to upload
        /// </summary>
        int PageSize { get; set; }

        /// <summary>
        /// Load from database
        /// </summary>
        /// <param name="db">Database connection</param>
        /// <param name="lastSyncTime">Last sync time</param>
        /// <returns></returns>
        List<TRest> LoadLocal(DBConnection db, DateTime lastSyncTime);

        /// <summary>
        /// Push documents
        /// </summary>
        /// <param name="records">Documents to push</param>
        /// <returns></returns>
        void Push(List<TRest> records);

        /// <summary>
        /// Commit sync data
        /// </summary>
        /// <param name="commitTime">Commit time (Unix time)</param>
        /// <returns></returns>
        void Commit(long commitTime);
    }

}
