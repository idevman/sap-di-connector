using IDevman.SAPConnector.Exceptions;
using System.Diagnostics;
using SAPbobsCOM;
using System;
using System.Reflection;
using log4net;

namespace IDevman.SAPConnector
{

    /// <summary>
    /// Used to handle common utillities for SAP connection
    /// </summary>
    public class SAPConnection : IDisposable
    {

        /// <summary>
        /// Logger utillity
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Company property
        /// </summary>
        public Company Company { get; private set; }

        /// <summary>
        /// Create a new SAP connection
        /// </summary>
        public SAPConnection()
        {
            if (SAPSettings.Current == null)
            {
                SAPException exception = new SAPException(-1, "SAPSettings.Current not defined");
                logger.Error(exception.Message, exception);
                Debug.WriteLine(exception.Message);
                throw exception;
            }
            Company = new Company
            {
                Server = SAPSettings.Current.Server,
                CompanyDB = SAPSettings.Current.CompanyDB,
                UserName = SAPSettings.Current.UserName,
                Password = SAPSettings.Current.Password,
                DbUserName = SAPSettings.Current.DbUserName,
                DbPassword = SAPSettings.Current.DbPassword,
                UseTrusted = SAPSettings.Current.UseTrusted,
                DbServerType = SAPSettings.Current.DbServerType
            };
            logger.Info("Connecting");
            Debug.WriteLine("Connecting");
            int response = Company.Connect();
            if (response != 0)
            {
                Company.GetLastError(out response, out string error);
                SAPConnectionException exception = new SAPConnectionException(response, error);
                logger.Error(exception.Message, exception);
                Debug.WriteLine(exception.Message);
                throw exception;
            }
        }

        /// <summary>
        /// Check response code
        /// </summary>
        /// <param name="response">Response code</param>
        public void CheckResponse(int response)
        {
            if (response == 0)
            {
                logger.Info("Success action");
                Debug.WriteLine("Success action");
            }
            else
            {
                Company.GetLastError(out response, out string error);
                SAPException exception = new SAPException(response, error);
                logger.Error(exception.Message, exception);
                Debug.WriteLine(exception.Message);
                throw exception;
            }
        }

        /// <summary>
        /// Close current connection
        /// </summary>
        public void Dispose()
        {
            Dispose(false);
        }

        /// <summary>
        /// Real dispose
        /// </summary>
        /// <param name="x">Disposing flag</param>
        protected virtual void Dispose(bool x)
        {
            if (Company.Connected)
            {
                logger.Info("Disconnecting");
                Debug.WriteLine("Disconnecting");
                Company.Disconnect();
            }
            GC.SuppressFinalize(this);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

    }

}
