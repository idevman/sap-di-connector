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
        /// SAP connection exception
        /// </summary>
        /// <param name="message">Error message</param>
        public SAPConnectionException(int code, string message) : base(code, message)
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