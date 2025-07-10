using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.Factory.Helper
{
    public class ExportHelper
    {
        public static void WriteCsv<T>(List<T> data,string filename)
        {
            if(data.Count == 0)
            {
                throw new InvalidOperationException("The data should at least contain one element");
            }

                object first= data[0];
            Type t = first.GetType();
            PropertyInfo[] properties = t.GetProperties();

            StringBuilder sb = new StringBuilder();
            bool comma= false;
            foreach (PropertyInfo property in properties)
            {
                if (comma)
                {
                    sb.Append(";");
                }
                else
                {
                    comma = true;
                } 
                sb.Append(property.Name);

            }
            sb.AppendLine();

            foreach (object row in data)
            {
                AddRow(row, sb,properties);
                sb.AppendLine();
            }
            File.WriteAllText(filename, sb.ToString(),Encoding.UTF8);
        }

        private static void AddRow(object row,StringBuilder sb, PropertyInfo[] properties)
        {
            bool comma = false;
            foreach (PropertyInfo property in properties)
            {
                if (comma)
                {
                    sb.Append(";");
                }
                else
                {
                    comma = true;
                }
                sb.Append(property.GetValue(row));
            }
        }

    }
}
