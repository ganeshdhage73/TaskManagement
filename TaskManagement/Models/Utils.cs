using System.Data;
#region Namespaces
using System.Reflection;
#endregion

namespace TaskManagement.Models
{
    public static class Utils
    {
        public static List<T> ConvertToList<T>(this DataTable table) where T : new()
        {
            Type t = typeof(T);

            // Create a list of the entities we want to return
            List<T> returnObject = new List<T>();

            // Iterate through the DataTable's rows
            foreach (DataRow dr in table.Rows)
            {
                // Convert each row into an entity object and add to the list
                T newRow = dr.ConvertToEntity<T>();
                returnObject.Add(newRow);
            }

            // Return the finished list
            return returnObject;
        }
        public static T ConvertToEntity<T>(this DataRow tableRow) where T : new()
        {
            // Create a new type of the entity I want
            Type t = typeof(T);
            T returnObject = new T();

            foreach (DataColumn col in tableRow.Table.Columns)
            {
                string colName = col.ColumnName;

                // Look for the object's property with the columns name, ignore case
                PropertyInfo pInfo = t.GetProperty(colName.ToLower(), BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                // did we find the property ?
                if (pInfo != null)
                {
                    try
                    {
                        object val = tableRow[colName];

                        // is this a Nullable<> type
                        bool IsNullable = (Nullable.GetUnderlyingType(pInfo.PropertyType) != null);
                        if (IsNullable)
                        {
                            if (val is System.DBNull)
                            {
                                val = null;
                            }
                            else
                            {
                                try
                                {
                                    // Convert the db type into the T we have in our Nullable<T> type
                                    if (!pInfo.PropertyType.IsEnum)
                                        val = Convert.ChangeType(val, Nullable.GetUnderlyingType(pInfo.PropertyType));
                                    else
                                        val = Enum.Parse(pInfo.PropertyType, val.ToString());
                                }
                                catch
                                {
                                    val = null;
                                }
                            }
                        }
                        else
                        {
                            if (val is System.DBNull)
                            {
                                val = null;
                            }
                            else
                            {
                                try
                                {
                                    // Convert the db type into the type of the property in our entity
                                    if (!pInfo.PropertyType.IsEnum)
                                        val = Convert.ChangeType(val, pInfo.PropertyType);
                                    else
                                        val = Enum.Parse(pInfo.PropertyType, val.ToString());
                                }
                                catch
                                {
                                    val = null;
                                }
                            }
                        }
                        // Set the value of the property with the value from the db
                        pInfo.SetValue(returnObject, val, null);
                    }
                    catch
                    {
                    }
                }
            }

            // return the entity object with values
            return returnObject;
        }
    }
}
