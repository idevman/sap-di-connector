namespace IDevman.SAPConnector.Connector
{

    /// <summary>
    /// Used to group Sync downloads
    /// </summary>
    public interface IDownload
    {

        /// <summary>
        /// Use last sync date to download the data from API
        /// </summary>
        /// <param name="lastSyncTime">Last download time (as Unix time)</param>
        /// <returns>If was some data retrieved</returns>
        void Download(long lastSyncTime);

    }

}
