using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ivrdating.Domain.VM;
using ivrdating.Domain;
using System.Data.Entity.Core.Objects;
using ivrdating.Log;

namespace ivrdating.Persistent.Repositories
{
    public class UserRepository
    {

        ivrdating.Domain.ivrdating _context;
        LogRequestResponse _logRequestResponse;
        public UserRepository()
        {
            _context = new Domain.ivrdating();

            _logRequestResponse = new LogRequestResponse();
            if (CommonRepositories.debugMode.Equals("On", StringComparison.OrdinalIgnoreCase))
                _context.Database.Log = s => _logRequestResponse.LogData(s, "Warn");
        }
        public Add_To_User_Minute_Response Add_To_User_Minute(Add_To_User_Minute_Request _request)
        {
            Add_To_User_Minute_Response response = null;
            string Grp_id = CommonRepositories.GetGroupID(_request.Group_Prefix);
            user_minute um = new user_minute();
            um.Acc_Number = _request.Acc_Number;
            um.R_Seconds = _request.Minutes_In_Package * 60;
            um.Grp_Id = Grp_id;
            um.CreateDateTimeStamp = _request.RegisteredDate;
            um.LastDateTimeStamp = _request.RegisteredDate;

            _context.user_minute.Add(um);
            try
            {
                _context.SaveChanges();
                response = new Add_To_User_Minute_Response() { Acc_Number = _request.Acc_Number };
            }
            catch {
                response = new Add_To_User_Minute_Response() { Acc_Number =-1 };
            }
           
            return response;
        }

        public Add_To_Service_Source_Response Add_To_Service_Source(Add_To_Service_Source_Request _request)
        {
            Add_To_Service_Source_Response response = null;

            string Grp_id = CommonRepositories.GetGroupID(_request.Group_Prefix);

            servicesource sc = new servicesource();

            sc.Acc_Number = _request.Acc_Number;
            sc.AreaCode = _request.Area_Code;
            sc.Grp_Id = Grp_id;
            sc.OnDate = (DateTime)_request.RegisteredDate;
            sc.Source = _request.Service_Source;

            _context.servicesources.Add(sc);
            _context.SaveChanges();

            response = new Add_To_Service_Source_Response() { Acc_Number = _request.Acc_Number };

            return response;
        }

        public Update_User_Minute_Response update_user_minute(Update_User_Minute_Request _request)
        {
            string Grp_id = CommonRepositories.GetGroupID(_request.Group_Prefix);
            user_minute um = _context.user_minute.Where(x => x.Acc_Number == _request.Acc_Number && x.Grp_Id == Grp_id).FirstOrDefault();
            if (um != null)
            {
                um.R_Seconds = _request.Minutes_In_Package * 60;
                um.LastDateTimeStamp = (DateTime)_request.RegisteredDate;
            }
            else
            {
                user_minute new_Um = new user_minute();
                new_Um.Acc_Number = _request.Acc_Number;
                new_Um.Grp_Id = Grp_id;
                new_Um.G_Seconds = 0;
                new_Um.G_UsedSeconds = 0;
                new_Um.R_Seconds = _request.Minutes_In_Package * 60;
                new_Um.R_UsedSeconds = 0;
                new_Um.CreateDateTimeStamp = DateTime.Now;
                new_Um.LastDateTimeStamp = DateTime.Now;
                _context.user_minute.Add(new_Um);
            }
            _context.SaveChanges();
            return new Update_User_Minute_Response() { Acc_Number = _request.Acc_Number };
        }

        public Check_Geo_Location_Response check_geo_location(Check_Geo_Location_Request _request, double inetAtom)
        {
            Check_Geo_Location_Response response = new Check_Geo_Location_Response() { geo_areacode = "0", geo_city = "0", geo_country = "0", geo_stateprov = "0" };
            
            double aton = inetAtom;
            if (!_request.Client_IP_Location.Contains(":"))
            {
                long ip_byte = (1 * Convert.ToInt32(_request.Client_IP_Location.Substring(0, _request.Client_IP_Location.IndexOf("."))));
                ip2location_db15_ipv4m iploc;

                ivrdating.Domain.ivrdatingNode3 _ivrdatingNode3 = new ivrdatingNode3();

                  iploc  = _ivrdatingNode3.ip2location_db15_ipv4m.Where(x => x.ip_byte1 == ip_byte && x.ip_start <= aton && x.ip_end >= aton).FirstOrDefault();
               

                if (iploc != null)
                {
                    response = new Check_Geo_Location_Response() { geo_areacode = iploc.AreaCode, geo_city = iploc.city, geo_country = iploc.country, geo_stateprov = iploc.stateprov };
                }
            }
            else
            {
                ivrdating.Domain.ivrdatingNode3 _ivrdatingNode3 = new ivrdatingNode3();

                ip2location_db15_ipv6m iploc = _ivrdatingNode3.ip2location_db15_ipv6m.SqlQuery("SELECT * FROM ip2location_db15_ipv6m WHERE INET6_ATON(@Client_IP_Location) BETWEEN ip_start AND ip_end LIMIT 1", new object[] {new ObjectParameter("Client_IP_Location", _request.Client_IP_Location) }).FirstOrDefault();
                if (iploc != null)
                {
                    response = new Check_Geo_Location_Response() { geo_areacode = iploc.AreaCode, geo_city = iploc.city, geo_country = iploc.country, geo_stateprov = iploc.stateprov };
                }
            }

            return response;
        }


        public Get_Node3_Accesspoint_Ip_Response get_node3_accesspoint_ip(Get_Node3_Accesspoint_Ip_Request _request)
        {
            Get_Node3_Accesspoint_Ip_Response response = null;

            misc _misc = _context.miscs.Where(x => x.SettingName == "Node3_AccessPoint_IP").FirstOrDefault();
            if (_misc != null)
            {
                response = new Get_Node3_Accesspoint_Ip_Response() { ip_address = _misc.SettingValue };
            }

            return response;
        }
    }
}
