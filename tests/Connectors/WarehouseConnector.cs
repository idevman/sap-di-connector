using IDevman.SAPConnector;
using IDevman.SAPConnector.Connector;
using IDevman.SAPConnector.Data.Model;
using IDevman.SAPConnector.DBMS;
using System;
using System.Collections.Generic;
using Tests.Rest;

namespace Tests.Connectors
{

    /// <summary>
    /// Create a mock for a warehouse connector
    /// </summary>
    public class WarehouseConnector : RestConnector<OWHS, WarehouseRest>, ISyncUpload<OWHS, WarehouseRest>
    {
        public int PageSize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Commit(long commitTime)
        {
            throw new NotImplementedException();
        }

        public List<OWHS> LoadLocal(DBConnection db, DateTime lastSyncTime)
        {
            throw new NotImplementedException();
        }

        public void Push(List<OWHS> records)
        {
            throw new NotImplementedException();
        }
    }

}
