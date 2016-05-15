using ivrdating.Domain;
using ivrdating.Domain.VM;
using ivrdating.Models;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
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

        public static string SerializeToJson(object obj)
        {
            return JsonSerializer.SerializeToString(obj);
        }

        public static string SerializeToCsv(GetMemberDetailsResponse _response)
        {
            return CsvSerializer.SerializeToCsv(new List<GetMemberDetailsResponse> { _response });
        }

        public static string SerializeToCsv(Get_New_Acc_Number_Return _response)
        {
            return CsvSerializer.SerializeToCsv(new List<Get_New_Acc_Number_Return> { _response });
        }

        public static string SerializeToCsv(Get_N_Activate_New_Acc_Number_Return _response)
        {
            return CsvSerializer.SerializeToCsv(new List<Get_N_Activate_New_Acc_Number_Return> { _response });
        }

        public static string SerializeToCsv(Activate_Acc_Number_Return _response)
        {
            return CsvSerializer.SerializeToCsv(new List<Activate_Acc_Number_Return> { _response });
        }

        public static string SerializeToCsv(Deactivate_Acc_Number_Return _response)
        {
            return CsvSerializer.SerializeToCsv(new List<Deactivate_Acc_Number_Return> { _response });
        }

        public static string SerializeToCsv(Add_New_Account_Return _response)
        {
            return CsvSerializer.SerializeToCsv(new List<Add_New_Account_Return> { _response });
        }

        public static string SerializeToCsv(Add_To_Customer_Master_Return _response)
        {
            return CsvSerializer.SerializeToCsv(new List<Add_To_Customer_Master_Return> { _response });
        }

        public static string SerializeToCsv(Add_To_User_Minute_Return _response)
        {
            return CsvSerializer.SerializeToCsv(new List<Add_To_User_Minute_Return> { _response });
        }

        public static string SerializeToCsv(object _response)
        {
            return CsvSerializer.SerializeToCsv(new List<object> { _response });
        }
    }
}
