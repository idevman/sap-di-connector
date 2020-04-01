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
    /// Enumeration types
    /// </summary>
    public enum DBType
    {
        AlphaNum = 1,
        BigInt = 2,
        Blob = 3,
        Boolean = 4,
        Clob = 5,
        Date = 6,
        Decimal = 7,
        Double = 8,
        Integer = 9,
        NClob = 10,
        NVarChar = 11,
        Real = 12,
        SecondDate = 13,
        ShortText = 14,
        SmallDecimal = 15,
        SmallInt = 16,
        Text = 17,
        Time = 18,
        TimeStamp = 19,
        TinyInt = 20,
        VarBinary = 21,
        VarChar = 22,
        TableType = 23,
        Binnary = 24,
        Char = 25,
    }

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
                // connectionStringBuilder.Append("databaseName=").Append(SAPSettings.Current.CompanyDB).Append(";");
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
        /// Add parameter to generic command
        /// </summary>
        /// <param name="name">Parameter name</param>
        /// <param name="type">Parameter type</param>
        /// <param name="value">Parameter value</param>
        /// <param name="size">Parameter size</param>
        public void AddSQLCommandParameter(string name, DBType type, object value, int? size = null)
        {
            if (SAPSettings.Current.DbServerType == SAPbobsCOM.BoDataServerTypes.dst_HANADB)
            {
                HanaDbType hanaType = HanaDbType.VarChar;
                switch (type) {
                    case DBType.AlphaNum:
                    case DBType.Char:
                        hanaType = HanaDbType.AlphaNum;
                        break;
                    case DBType.BigInt:
                        hanaType = HanaDbType.BigInt;
                        break;
                    case DBType.Blob:
                    case DBType.Binnary:
                        hanaType = HanaDbType.Blob;
                        break;
                    case DBType.Boolean:
                        hanaType = HanaDbType.Boolean;
                        break;
                    case DBType.Clob:
                        hanaType = HanaDbType.Clob;
                        break;
                    case DBType.Date:
                        hanaType = HanaDbType.Date;
                        break;
                    case DBType.Decimal:
                        hanaType = HanaDbType.Decimal;
                        break;
                    case DBType.Double:
                        hanaType = HanaDbType.Double;
                        break;
                    case DBType.Integer:
                        hanaType = HanaDbType.Integer;
                        break;
                    case DBType.NClob:
                        hanaType = HanaDbType.NClob;
                        break;
                    case DBType.NVarChar:
                        hanaType = HanaDbType.NVarChar;
                        break;
                    case DBType.Real:
                        hanaType = HanaDbType.Real;
                        break;
                    case DBType.SecondDate:
                        hanaType = HanaDbType.SecondDate;
                        break;
                    case DBType.ShortText:
                        hanaType = HanaDbType.ShortText;
                        break;
                    case DBType.SmallDecimal:
                        hanaType = HanaDbType.SmallDecimal;
                        break;
                    case DBType.SmallInt:
                        hanaType = HanaDbType.SmallInt;
                        break;
                    case DBType.Text:
                        hanaType = HanaDbType.Text;
                        break;
                    case DBType.Time:
                        hanaType = HanaDbType.Time;
                        break;
                    case DBType.TimeStamp:
                        hanaType = HanaDbType.TimeStamp;
                        break;
                    case DBType.TinyInt:
                        hanaType = HanaDbType.TinyInt;
                        break;
                    case DBType.VarBinary:
                        hanaType = HanaDbType.VarBinary;
                        break;
                    case DBType.VarChar:
                        hanaType = HanaDbType.VarChar;
                        break;
                    case DBType.TableType:
                        hanaType = HanaDbType.TableType;
                        break;
                }
                if (size != null)
                {
                    SQLCommand.Parameters.Add(new HanaParameter(name, hanaType, size.Value)
                    {
                        Value = value
                    });
                } else
                {
                    SQLCommand.Parameters.Add(new HanaParameter(name, hanaType)
                    {
                        Value = value
                    });
                }
            } else
            {
                SqlDbType sqlType = SqlDbType.VarChar;
                switch (type)
                {
                    case DBType.AlphaNum:
                    case DBType.Char:
                        sqlType = SqlDbType.Char;
                        break;
                    case DBType.BigInt:
                        sqlType = SqlDbType.BigInt;
                        break;
                    case DBType.Blob:
                    case DBType.Binnary:
                        sqlType = SqlDbType.VarBinary;
                        break;
                    case DBType.Boolean:
                        sqlType = SqlDbType.Bit;
                        break;
                    case DBType.Clob:
                        sqlType = SqlDbType.NVarChar;
                        break;
                    case DBType.Date:
                        sqlType = SqlDbType.Date;
                        break;
                    case DBType.Decimal:
                        sqlType = SqlDbType.Decimal;
                        break;
                    case DBType.Double:
                        sqlType = SqlDbType.Float;
                        break;
                    case DBType.Integer:
                        sqlType = SqlDbType.Int;
                        break;
                    case DBType.NVarChar:
                        sqlType = SqlDbType.NVarChar;
                        break;
                    case DBType.Real:
                        sqlType = SqlDbType.Real;
                        break;
                    case DBType.SecondDate:
                        sqlType = SqlDbType.DateTime2;
                        break;
                    case DBType.ShortText:
                        sqlType = SqlDbType.Text;
                        break;
                    case DBType.SmallDecimal:
                        sqlType = SqlDbType.Decimal;
                        break;
                    case DBType.SmallInt:
                        sqlType = SqlDbType.SmallInt;
                        break;
                    case DBType.Text:
                        sqlType = SqlDbType.Text;
                        break;
                    case DBType.Time:
                        sqlType = SqlDbType.Time;
                        break;
                    case DBType.TimeStamp:
                        sqlType = SqlDbType.Timestamp;
                        break;
                    case DBType.TinyInt:
                        sqlType = SqlDbType.TinyInt;
                        break;
                    case DBType.VarBinary:
                        sqlType = SqlDbType.VarBinary;
                        break;
                    case DBType.VarChar:
                        sqlType = SqlDbType.VarChar;
                        break;
                }
                if (size != null)
                {
                    SQLCommand.Parameters.Add(new SqlParameter(name, sqlType, size.Value)
                    {
                        Value = value
                    });
                } else
                {
                    SQLCommand.Parameters.Add(new SqlParameter(name, sqlType)
                    {
                        Value = value
                    });
                }
            }
        }

        protected HanaCommand TranslateToHana()
        {
            SQLCommand.CommandText = SQLCommand.CommandText
                    .Replace("[dbo]", string.Format("[{0}]", SAPSettings.Current.CompanyDB))
                    .Replace('[', '"')
                    .Replace(']', '"')
                    .Replace('@', ':');
            foreach (DbParameter i in SQLCommand.Parameters)
            {
                i.ParameterName = i.ParameterName.Replace('@', ':');
            }
            
            return AsHanaCommand;
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
                        SelectCommand = TranslateToHana()
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
