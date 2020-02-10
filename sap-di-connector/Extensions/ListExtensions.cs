using System;
using System.Collections.Generic;
using System.Globalization;

namespace IDevman.SAPConnector.Extensions
{
    /// <summary>
    /// Provide basic functionallity for generic lists
    /// </summary>
    public static class ListExtensions
    {

        /// <summary>
        /// Load first element or null
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="list">List to load</param>
        /// <returns>First or null</returns>
        public static T First<T>(this List<T> list) where T : class, new()
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list),
                    string.Format(CultureInfo.InvariantCulture, Properties.Resources.NullValue, nameof(list)));
            }
            return list.Count == 0 ? null : list.First();
        }

    }

}
