using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace IDevman.SAPConnector.Extensions
{

    /// <summary>
    /// Provide extension data to cast data table to object related data
    /// </summary>
    public static class DataTableExtensions
    {
        /// <summary>
        /// Convert Datatable content into List of generic objects in order to cast data
        /// </summary>
        /// <typeparam name="T">Target type to fill</typeparam>
        /// <param name="table">Data table to load</param>
        /// <returns>Object list from data table</returns>
        public static List<T> ToList<T>(this DataTable table) where T : class, new()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CurrentCulture;//.CreateSpecificCulture("es-MX");
            try
            {
                List<T> list = new List<T>();
                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();
                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        if (row.Table.Columns.Contains(prop.Name))
                        {
                            try
                            {
                                PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                                propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                            }
                            catch (Exception ex)
                            {
                                continue;
                            }
                        }
                    }
                    list.Add(obj);
                }
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }

}
