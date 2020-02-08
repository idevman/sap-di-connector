using System;
using System.Runtime.Serialization;

namespace IDevman.SAPConnector.Exceptions
{

    /// <summary>
    /// SAP exception
    /// </summary>
    [Serializable]
    public class SAPException : Exception
    {

        /// <summary>
        /// SAP error code
        /// </summary>
        public int SAPErrorCode { get; set; }

        /// <summary>
        /// SAP Error message
        /// </summary>
        public string SAPErrorMessage { get; set; }

        /// <summary>
        /// Create a new instance of SAP Exception
        /// </summary>
        protected SAPException(): base()
        {
        }

        /// <summary>
        /// Create a new instance of SAP Exception
        /// </summary>
        /// <param name="message">Error message</param>
        public SAPException(string message) : base(message)
        {
            SAPErrorMessage = message;
        }

        /// <summary>
        /// Create a new instance of SAP Exception
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="innerException">Exception cause</param>
        public SAPException(string message, Exception innerException) : base(message, innerException)
        {
            SAPErrorMessage = message;
        }

        /// <summary>
        /// Create a new instance of SAP exception
        /// </summary>
        /// <param name="code">Error code to display</param>
        /// <param name="message">Error message</param>
        public SAPException(int code, string message) : base("[" + code + "]: " + message)
        {
            SAPErrorCode = code;
            SAPErrorMessage = message;
        }

        /// <summary>
        /// Create a new instance of SAP exception
        /// </summary>
        /// <param name="info">Serialziation info</param>
        /// <param name="context">Streaming context</param>
        protected SAPException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }

        /// <summary>
        /// Load serialization objects
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("SAPErrorCode", SAPErrorCode);
            info.AddValue("SAPErrorMessage", SAPErrorMessage);
        }

    }

}