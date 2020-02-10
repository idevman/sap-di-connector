using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
            List<T> list = new List<T>();
            try
            {
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
                                propertyInfo.SetValue(obj,
                                    Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType, CultureInfo.InvariantCulture),
                                    null);
                            }
                            catch (ArgumentException ex) { Debug.Fail(ex.Message); continue; }
                            catch (TargetException ex) { Debug.Fail(ex.Message); continue; }
                            catch (TargetParameterCountException ex) { Debug.Fail(ex.Message); continue; }
                            catch (MethodAccessException ex) { Debug.Fail(ex.Message); continue; }
                            catch (TargetInvocationException ex) { Debug.Fail(ex.Message); continue; }
                            catch (InvalidCastException ex) { Debug.Fail(ex.Message); continue; }
                            catch (FormatException ex) { Debug.Fail(ex.Message); continue; }
                            catch (OverflowException ex) { Debug.Fail(ex.Message); continue; }
                            catch (AmbiguousMatchException ex) { Debug.Fail(ex.Message); continue; }
                        }
                    }
                    list.Add(obj);
                }
            }
            catch (ArgumentNullException ex)
            {
                Debug.Fail(ex.Message);
            }
            return list;
        }

    }

}
