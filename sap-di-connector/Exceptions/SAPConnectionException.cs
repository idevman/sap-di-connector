using System;
using System.Runtime.Serialization;

namespace IDevman.SAPConnector.Exceptions
{

    /// <summary>
    /// SAP connection exception
    /// </summary>
    [Serializable]
    public class SAPConnectionException : SAPException
    {

        /// <summary>
        /// Create a new instance of SAP Exception
        /// </summary>
        protected SAPConnectionException() : base()
        {
        }

        /// <summary>
        /// Create a new instance of SAP Exception
        /// </summary>
        /// <param name="message">Error message</param>
        public SAPConnectionException(string message) : base(message)
        {
        }

        /// <summary>
        /// Create a new instance of SAP Exception
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="innerException">Exception cause</param>
        public SAPConnectionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Create a new instance of SAP exception
        /// </summary>
        /// <param name="code">Error code to display</param>
        /// <param name="message">Error message</param>
        public SAPConnectionException(int code, string message) : base(code, message)
        {
        }

        /// <summary>
        /// Create a new instance of SAP exception
        /// </summary>
        /// <param name="info">Serialziation info</param>
        /// <param name="context">Streaming context</param>
        protected SAPConnectionException(SerializationInfo info, StreamingContext context) : base(info, context)
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
        }

    }

}