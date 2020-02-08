using System;
using System.Globalization;

namespace IDevman.SAPConnector.Extensions
{

    /// <summary>
    /// Provide extensions to handle Long values
    /// </summary>
    public static class LongExtensions
    {

        /// <summary>
        /// Create a DateTime from long value interpreted as unix time
        /// </summary>
        /// <param name="value">Value as Unix time</param>
        /// <returns>Date time</returns>
        public static DateTime AsUnixTime(this long value)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                .AddSeconds(value)
                .ToLocalTime();
        }

        /// <summary>
        /// Create a string date from long value interpreted as unix time
        /// </summary>
        /// <param name="value">Value as Unix time</param>
        /// <returns>Date time string representation dd/MM/yyyy HH:mm:ss</returns>
        public static string AsUnixTimeString(this long value)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                .AddSeconds(value)
                .ToLocalTime()
                .ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        }

    }

}
