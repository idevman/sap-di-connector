using System.Collections.Generic;

namespace IDevman.SAPConnector.Connector
{

    /// <summary>
    /// Fetched data
    /// </summary>
    public class Fetched<T>
    {

        /// <summary>
        /// New records
        /// </summary>
        public List<T> NewRecords { get; } = new List<T>();

        /// <summary>
        /// Existing records
        /// </summary>
        public List<T> ExistingRecords { get; } = new List<T>();

        /// <summary>
        /// Define if fetched data is empty
        /// </summary>
        public bool Empty
        {
            get
            {
                return NewRecords.Count == 0 && ExistingRecords.Count == 0;
            }
        }

    }

}
