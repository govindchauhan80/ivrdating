using ivrdating.Domain;
using ivrdating.Domain.VM;
using ivrdating.Log;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Install;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace ivrdating.Persistent.Repositories
{
    public class CommonRepositories
    {
        static ivrdating.Domain.ivrdating _context;
        static LogRequestResponse _logRequestResponse;

        public static readonly string debugMode = System.Configuration.ConfigurationManager.AppSettings["Debug"];
        static CommonRepositories()
        {
            _context = new Domain.ivrdating();

            _logRequestResponse = new LogRequestResponse();
            if (CommonRepositories.debugMode.Equals("On", StringComparison.OrdinalIgnoreCase))
                _context.Database.Log = s => _logRequestResponse.LogData(s, "Warn");
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
                else
                {
                    if (GetGroupID(_request.Group_Prefix) == "0")
                    {
                        return "Invalid Group_Prefix";
                    }
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

        public static string ValidateRequest(RequestBaseWithOutGp _request)
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
            //return "182.50.132.48";

            return "127.0.0.1";
            // return ip == "::1" ? "127.0.0.1" : ip;
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

        public static bool IsValidEmailAddress(string s)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(s);
        }
    }

    public class GetAccountIdsEnum
    {
        public int Id { get; set; }
        public string Grp_Id { get; set; }
    }
    /*
    public class MyDbConfiguration : DbConfiguration
    {
        public MyDbConfiguration()
        {
            SetDatabaseLogFormatter(
                (context, writeAction) => new OneLineFormatter(context, writeAction));
        }


    }

    public class OneLineFormatter : DatabaseLogFormatter
    {
        public OneLineFormatter(DbContext context, Action<string> writeAction)
            : base(context, writeAction)
        {
        }

        public override void LogCommand<TResult>(
            DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
        {
            var data = string.Format(
                "Context '{0}' is executing command '{1}'{2}",
                Context.GetType().Name,
                command.CommandText.Replace(Environment.NewLine, ""),
                Environment.NewLine);
            LogRequestResponse _logRequestResponse = new LogRequestResponse();
            _logRequestResponse.LogData(data, "Warn");
        }

        public override void LogResult<TResult>(
            DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
        {
        }
    }

    */
}
