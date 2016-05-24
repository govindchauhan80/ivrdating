using ivrdating.Domain;
using ivrdating.Domain.VM;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            StackTrace stackTrace = new StackTrace();

            string Function = stackTrace.GetFrame(1).GetMethod().Name.ToLower();

            if ((Function == "set_misc") || (Function == "read_misc") || (Function == "insert_login_log") || (Function == "update_login_log") || (Function == "getchargeamount") || (Function == "set_primary_apiserver") || (Function == "check_geo_location") || (Function == "get_node3_accesspoint_ip"))
            {
                return "0";
            }


            var groupAssociation = (from ga in _context.group_association where ga.Grp_Prefix == Group_Prefix select ga).FirstOrDefault();
            if (groupAssociation == null)
            {
                return "0";
            }
            return groupAssociation.Grp_Id;
        }

        public static string ValidateRequest(RequestBase _request)
        {

            StackTrace stackTrace = new StackTrace();

            string Function = stackTrace.GetFrame(1).GetMethod().Name.ToLower();

            if ((Function == "set_misc") || (Function == "read_misc") || (Function == "insert_login_log") || (Function == "update_login_log") || (Function == "getchargeamount") || (Function == "set_primary_apiserver") || (Function == "check_geo_location") || (Function == "get_node3_accesspoint_ip"))
            {
                // _request.Group_Id = "0";
            }
            else
            {
                if (string.IsNullOrEmpty(_request.Group_Prefix))
                {
                    return "Invalid Group_Prefix";
                }
            }
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
            return "127.0.0.1";
            //return ip == "::1" ? "127.0.0.1" : ip;
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
