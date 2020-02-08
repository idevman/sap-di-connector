using IDevman.SAPConnector;
using IDevman.SAPConnector.Connector;
using IDevman.SAPConnector.DBMS;
using IDevman.SAPConnector.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Connectors;
using Tests.Rest;

namespace Tests
{

    /// <summary>
    /// used to verify connection tests
    /// </summary>
    [TestClass]
    class RestConnectorTest
    {

        /// <summary>
        /// Check if rest connector can be created
        /// </summary>
        [TestMethod]
        public void ShouldCreateInstance()
        {
            long lastSyncTime = 0;
            long commitTime = DateTime.Now.AsUnixTime();

            RestConnectorPool pool = new RestConnectorPool();
            pool.Connectors.Add(new WarehouseConnector());

            pool.Sync(lastSyncTime, commitTime);
        }

    }

}
