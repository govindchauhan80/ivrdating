using ivrdating.Models;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Logic.Helpers
{
    public class ExtensionMethods
    {
        public static object CreateItemFromRow(DataRow row, IList<PropertyInfo> properties, object type)
        {
            string val = "";
            foreach (var property in properties)
            {
                val = row[property.Name] == null ? "" : row[property.Name].ToString();
                property.SetValue(type, val, null);
            }
            return type;
        }

        public static string SerializeToPlainText(IList<PropertyInfo> properties, object type)
        {
            List<string> val = new List<string>();
            foreach (var property in properties)
            {
                if (type != null && !string.IsNullOrEmpty(Convert.ToString(property.GetValue(type, null))))
                    val.Add(Convert.ToString(property.GetValue(type, null)));
            }
            return string.Join("|", val);
        }

        public static string SerializeToCsv(GetMemberDetailsResponse _getMemberDetailsResponse)
        {
            return CsvSerializer.SerializeToCsv(new List<GetMemberDetailsResponse> {_getMemberDetailsResponse });
        }
    }
}
