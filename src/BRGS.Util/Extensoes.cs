using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BRGS.Util
{
    // Fonte: http://www.dreamincode.net/forums/topic/313126-datatableasenumerablet-for-easy-linq-to-object-functionalit/

    public static class Extensoes
    {
        public static IEnumerable<T> AsEnumerable<T>(this DataTable table) where T : new()
        {
            if (table == null)
                throw new NullReferenceException("DataTable");

             int propertiesLength = typeof(T).GetProperties().Length;

             if (propertiesLength == 0)
                 throw new NullReferenceException("Properties");

             var objList = new List<T>();

             foreach (DataRow row in table.Rows)
             {
                 var obj = new T();

                 PropertyInfo[] objProperties = obj.GetType().GetProperties();
                 for (int i = 0; i < propertiesLength; i++)
                 {
                     PropertyInfo property = objProperties[i];                    

                     if (table.Columns.Contains(property.Name))
                     {
                         object objValue = row[property.Name];

                         var propertyType = property.PropertyType;

                         if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                             propertyType = propertyType.GetGenericArguments()[0];

                         objProperties[i].SetValue(obj, Convert.ChangeType(objValue, propertyType, System.Globalization.CultureInfo.CurrentCulture), null);
                     }
                 }

                 objList.Add(obj);
             }

             return objList;
        }
    }
}
