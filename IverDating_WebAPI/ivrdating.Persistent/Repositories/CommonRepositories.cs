using ivrdating.Domain;
using ivrdating.Domain.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Persistent.Repositories
{
    public class CommonRepositories
    {
        static ivrdating.Domain.ivrdating _context;
        static CommonRepositories()
        {
            _context = new Domain.ivrdating();
        }
        public static string GetGroupID(string Group_Prefix)
        {
            var groupAssociation = (from ga in _context.group_association where ga.Grp_Prefix == Group_Prefix select ga).FirstOrDefault();
            
            return groupAssociation.Grp_Id;
        }

        public static string ValidateRequest(RequestBase _request)
        {
            ws_agent db = (from ws in _context.ws_agent where ws.WS_Username == _request.WS_UserName && ws.WS_Password == _request.WS_Password select ws).FirstOrDefault();
            if (db != null)
            {
                if (db.AuthKey != _request.AuthKey)
                {
                    return "Invalid Auth Key";
                }
                if (db.IP_Address != GetIp())
                {
                    return "Invalid Remote IP Address";
                }

            }
            else if (db == null)
            {
                return "WS_Agent credentials does not match";
            }
            return "OK";
        }
        private static string GetIp()
        {
            string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {
                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            return ip == "::1" ? "127.0.0.1" : ip;
        }

        public static string ValidateIp(string activeServerIP)
        {
            IPAddress address;
            if (IPAddress.TryParse(activeServerIP, out address))
            {
                return "";
            }
            else
            {
                return "Invalid Ip";
            }
        }
    }

    public class GetAccountIdsEnum
    {
        public int Id { get; set; }
        public string Grp_Id { get; set; }
    }
}
