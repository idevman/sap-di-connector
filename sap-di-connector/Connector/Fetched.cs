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
        public List<T> NewRecords { get; set; }

        /// <summary>
        /// Existing records
        /// </summary>
        public List<T> ExistingRecords { get; set; }

        /// <summary>
        /// Define if fetched data is empty
        /// </summary>
        public bool Empty
        {
            get
            {
                return (NewRecords == null || NewRecords.Count == 0) &&
                    (ExistingRecords == null || ExistingRecords.Count == 0);
            }
        }

    }

}
