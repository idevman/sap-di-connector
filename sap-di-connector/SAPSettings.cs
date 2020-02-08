using SAPbobsCOM;

namespace IDevman.SAPConnector
{

    /// <summary>
    /// SAP settings configuration for connection and customer selection
    /// </summary>
    public class SAPSettings
    {

        /// <summary>
        /// SAP user name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// SAP user password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Server address for DB and licence service
        /// </summary>
        public string Server { get; set; }

        /// <summary>
        /// Company database selection
        /// </summary>
        public string CompanyDB { get; set; }

        /// <summary>
        /// Database user name
        /// </summary>
        public string DbUserName { get; set; }

        /// <summary>
        /// Database user password
        /// </summary>
        public string DbPassword { get; set; }

        /// <summary>
        /// Database connection as Windows authentication
        /// </summary>
        public bool UseTrusted { get; set; }

        /// <summary>
        /// Database server type
        /// </summary>
        public BoDataServerTypes DbServerType { get; set; }

        /// <summary>
        /// Define current SAP settings
        /// </summary>
        public static SAPSettings Current { get; set; }

    }

}
