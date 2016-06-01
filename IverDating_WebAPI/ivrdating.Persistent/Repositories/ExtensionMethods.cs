using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Persistent.Repositories
{
    public class ExtensionMethods
    {

        public static double inet_aton(IPAddress IPaddress)
        {
            if (IPaddress.IsIPv4MappedToIPv6)
            {
                IPaddress = IPaddress.MapToIPv4();
            }
            int i;
            double num = 0;
            if (IPaddress.ToString() == "")
            {
                return 0;
            }
            string[] arrDec = IPaddress.ToString().Split('.');
            for (i = arrDec.Length - 1; i >= 0; i--)
            {
                num += ((int.Parse(arrDec[i]) % 256) * Math.Pow(256, (3 - i)));
            }
            return num;
        }
        
        public static string GetMd5Hash(string input,string type)
        {
            MD5 md5Hash = MD5.Create();
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        public static bool IsNumeric(string val)
        {
            int i;

            return int.TryParse(val, out i);
        }
    }
}
