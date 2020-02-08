using System.Collections.Generic;

namespace IDevman.SAPConnector.Connector
{

    /// <summary>
    /// Fetched data
    /// </summary>
    public class DataFetched<TRest>
    {

        /// <summary>
        /// New records
        /// </summary>
        public List<TRest> NewRecords { get; } = new List<TRest>();

        /// <summary>
        /// Existing records
        /// </summary>
        public List<TRest> ExistingRecords { get; } = new List<TRest>();

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
