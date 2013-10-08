using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using System.Data.SqlTypes;

namespace IPDectect.Client.Common
{
    public class CSVExport<T> where T : class
    {
        public List<T> Objects;

        public CSVExport(List<T> objects)
        {
            Objects = objects;
        }

        public string Export(Dictionary<string,string> headerFields)
        {

            StringBuilder sb = new StringBuilder();
            //Get properties using reflection.
            IList<PropertyInfo> propertyInfos = typeof(T).GetProperties();
            IList<PropertyInfo> propertyInfosAdjust = new List<PropertyInfo>();
            if (headerFields != null && headerFields.Count > 0)
            {
                //add header line.
                foreach (var h in headerFields)
                {
                    sb.Append(h.Value).Append(",");
                    // adjust property sort
                    foreach (var pi in propertyInfos)
                    {
                        if (pi.Name.Equals(h.Key, StringComparison.OrdinalIgnoreCase))
                        {
                            propertyInfosAdjust.Add(pi);
                        }
                    }
                }
                sb.Remove(sb.Length - 1, 1).AppendLine();
            }

            //add value for each property.
            foreach (T obj in Objects)
            {
                foreach (PropertyInfo propertyInfo in propertyInfosAdjust)
                {
                    sb.Append(MakeValueCsvFriendly(propertyInfo.GetValue(obj, null))).Append(",");
                }
                sb.Remove(sb.Length - 1, 1).AppendLine();
            }

            return sb.ToString();
        }

        //export to a file.
        public void ExportToFile(string path, Dictionary<string,string> headerFields = null)
        {
            File.WriteAllText(path, Export(headerFields),Encoding.Unicode);
        }

        //export as binary data.
        //public byte[] ExportToBytes()
        //{
        //    return Encoding.UTF8.GetBytes(Export());
        //}

        //get the csv value for field.
        private string MakeValueCsvFriendly(object value)
        {
            if (value == null) return "";
            if (value is Nullable && ((INullable)value).IsNull) return "";

            if (value is DateTime)
            {
                if (((DateTime)value).TimeOfDay.TotalSeconds == 0)
                    return ((DateTime)value).ToString("yyyy-MM-dd");
                return ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss");
            }
            string output = value.ToString();

            if (output.Contains(",") || output.Contains("\""))
                output = '"' + output.Replace("\"", "\"\"") + '"';

            return output;

        }
    }
}
