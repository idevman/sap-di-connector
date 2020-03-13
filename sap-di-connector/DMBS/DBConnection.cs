using log4net;
using IDevman.SAPConnector.Exceptions;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Threading;
using Sap.Data.Hana;
using System.Data.Common;

namespace IDevman.SAPConnector.DBMS
{

    /// <summary>
    /// Persistence unit
    /// </summary>
    public class DBConnection : IDisposable
    {

        /// <summary>
        /// Logger utillity
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// SQL connection to handle in persistence unit
        /// </summary>
        private DbConnection SQLConnection { get; set; }

        /// <summary>
        /// SQL command to execute
        /// </summary>
        public DbCommand SQLCommand { get; set; }

        /// <summary>
        /// Retrieve command as SQL command
        /// </summary>
        public SqlCommand AsSqlCommand
        {
            get
            {
                return (SqlCommand)SQLCommand;
            }
        }

        /// <summary>
        /// Retrieve connection as hanna command
        /// </summary>
        public HanaCommand AsHanaCommand
        {
            get
            {
                return (HanaCommand)SQLCommand;
            }
        }

        /// <summary>
        /// Create a new instance of Persistence
        /// </summary>
        public DBConnection()
        {
            if (SAPSettings.Current == null)
            {
                SAPException exception = new SAPException(-1, 
                    string.Format(CultureInfo.InvariantCulture, Properties.Resources.SettingsNotDefined, "SAPSettings.Current"));
                logger.Error(exception.Message, exception);
                Debug.WriteLine(exception.Message);
                throw exception;
            }
            Thread.CurrentThread.CurrentCulture = CultureInfo.CurrentCulture;//.CreateSpecificCulture("es-MX");
            StringBuilder connectionStringBuilder = new StringBuilder();
            if (SAPSettings.Current.DbServerType == SAPbobsCOM.BoDataServerTypes.dst_HANADB)
            {
                connectionStringBuilder.Append("Server=").Append(SAPSettings.Current.Server).Append(";");
                connectionStringBuilder.Append("UserId=").Append(SAPSettings.Current.DbUserName).Append(";");
                connectionStringBuilder.Append("Password=").Append(SAPSettings.Current.DbPassword).Append(";");
                connectionStringBuilder.Append("databaseName=").Append(SAPSettings.Current.CompanyDB).Append(";");
                SQLConnection = new HanaConnection
                {
                    ConnectionString = connectionStringBuilder.ToString()
                };
            }
            else
            {
                connectionStringBuilder.Append("Server=").Append(SAPSettings.Current.Server).Append(";");
                connectionStringBuilder.Append("Database=").Append(SAPSettings.Current.CompanyDB).Append(";");
                if (SAPSettings.Current.UseTrusted)
                {
                    connectionStringBuilder.Append("Trusted_Connection=True");
                }
                else
                {
                    connectionStringBuilder.Append("User Id=").Append(SAPSettings.Current.DbUserName).Append(";");
                    connectionStringBuilder.Append("Password=").Append(SAPSettings.Current.DbPassword).Append(";");
                }
                SQLConnection = new SqlConnection
                {
                    ConnectionString = connectionStringBuilder.ToString()
                };
            }
            CleanCommands();
            SQLConnection.Open();
        }

        /// <summary>
        /// Update and initialize components
        /// </summary>
        private void CleanCommands()
        {
            if (SAPSettings.Current.DbServerType == SAPbobsCOM.BoDataServerTypes.dst_HANADB)
            {
                SQLCommand = new HanaCommand
                {
                    Connection = (HanaConnection)SQLConnection
                };
            }
            else
            {
                SQLCommand = new SqlCommand
                {
                    Connection = (SqlConnection)SQLConnection
                };
            }
        }

        /// <summary>
        /// Fill data table
        /// </summary>
        /// <returns>Data table loaded</returns>
        public DataTable CreateDataTable()
        {
            DataTable dataTable = new DataTable();
            using (DataSet dataSet = new DataSet())
            using (DbDataAdapter sqlAdapter =
                    SAPSettings.Current.DbServerType == SAPbobsCOM.BoDataServerTypes.dst_HANADB ?
                    ((DbDataAdapter) new HanaDataAdapter()
                    {
                        SelectCommand = AsHanaCommand
                    })
                    : ((DbDataAdapter) new SqlDataAdapter()
                    {
                        SelectCommand = AsSqlCommand
                    }))
            {
                sqlAdapter.Fill(dataSet);
                if (dataSet.Tables.Count > 0)
                {
                    dataTable = dataSet.Tables[0];
                }
            }
            CleanCommands();
            return dataTable;
        }

        /// <summary>
        /// Dispose action
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose action
        /// </summary>
        protected virtual void Dispose(bool dispose)
        {
            if (SQLConnection.State != ConnectionState.Closed)
            {
                SQLConnection.Close();
            }
        }

    }

}
