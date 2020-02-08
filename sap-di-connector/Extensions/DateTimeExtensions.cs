using System;

namespace IDevman.SAPConnector.Extensions
{

    /// <summary>
    /// Provide extensiosn to handle dates
    /// </summary>
    public static class DateTimeExtensions
    {

        /// <summary>
        /// Create a long Unix Time from DateTime value
        /// </summary>
        /// <param name="value">Value as Unix time</param>
        /// <returns>Date time</returns>
        public static long AsUnixTime(this DateTime value)
        {
            DateTime offset = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).ToLocalTime();
            return (long)(value - offset).TotalSeconds;
        }

    }

}
