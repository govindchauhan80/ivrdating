using ivrdating.Persistent.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ivrdating.Domain.VM;
using System.Net;
using System.Text.RegularExpressions;

namespace ivrdating.Logic.Services
{
    public class UserService
    {
        UserRepository _userRepository;
        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public Add_To_User_Minute_Return Add_To_User_Minute(Add_To_User_Minute_Request _request)
        {
            Add_To_User_Minute_Response data = null;
            string validRequest = CommonRepositories.ValidateRequest(_request);
            if (!validRequest.Equals("OK"))
            {
                return new Add_To_User_Minute_Return() { Count = 0, ErrorMessage = validRequest, WsResult = null };
            }

            if (_request.Acc_Number <= 0)
            {
                return new Add_To_User_Minute_Return() { Count = 0, ErrorMessage = "Invalid Acc_Number it can 6 digit numeric only", WsResult = null };
            }
            if (_request.Minutes_In_Package <= 0)
            {
                return new Add_To_User_Minute_Return() { Count = 0, ErrorMessage = "Invalid Minutes_In_Package", WsResult = null };
            }

            if (_request.RegisteredDate == null)
            {
                _request.RegisteredDate = DateTime.Now;
            }
            data = _userRepository.Add_To_User_Minute(_request);
            if (data.Acc_Number == -1)
            {
                return new Add_To_User_Minute_Return() { Count = 0, ErrorMessage = "Acc_Number " + _request.Acc_Number + " Already exists" };
            }
            return new Add_To_User_Minute_Return() { Count = 1, ErrorMessage = null, WsResult = data };
        }

        public Add_To_Service_Source_Return Add_To_Service_Source(Add_To_Service_Source_Request _request)
        {
            string validRequest = CommonRepositories.ValidateRequest(_request);
            if (validRequest.Equals("OK"))
            {
                validRequest = "";
            }
            else
            {
                return new Add_To_Service_Source_Return() { Count = 0, ErrorMessage = validRequest, WsResult = null };
            }
            if (_request.Service_Source <= 0)
            {
                validRequest = "Service_Source Not defined";
            }
            if (string.IsNullOrEmpty(_request.Area_Code))
            {
                validRequest = "Invalid Area_Code it has 3 digit numeric onlyd";
            }
            else if (validRequest == "")
            {
                int ps = 0;

                if (int.TryParse(_request.Area_Code, out ps))
                {
                    if (ps <= 99 || ps > 999)
                    {
                        ps = 0;
                    }
                }

                if (ps == 0)
                {
                    validRequest = "Invalid Area_Code it has 3 digit numeric only";
                }
            }

            if (_request.Acc_Number <= 0)
            {
                validRequest = "Invalid Acc_Number it can 6 digit numeric only";
            }

            if (_request.RegisteredDate == null)
            {
                _request.RegisteredDate = DateTime.Now;
            }

            if (!string.IsNullOrEmpty(validRequest))
            {
                return new Add_To_Service_Source_Return() { Count = 0, ErrorMessage = validRequest, WsResult = null };
            }
            Add_To_Service_Source_Response data = _userRepository.Add_To_Service_Source(_request);

            return new Add_To_Service_Source_Return() { Count = 1, ErrorMessage = null, WsResult = data };
        }

        public Update_User_Minute_Return update_user_minute(Update_User_Minute_Request _request)
        {
            string validRequest = CommonRepositories.ValidateRequest(_request);
            if (validRequest.Equals("OK"))
            {
                validRequest = "";
            }
            else
            {
                return new Update_User_Minute_Return() { Count = 0, ErrorMessage = validRequest };
            }
            if (validRequest == "" && _request.Acc_Number <= 0)
            {
                validRequest = "Invalid Acc_Number it can 6 digit numeric only";
            }
            if (validRequest == "" && _request.Minutes_In_Package <= 0)
            {
                validRequest = "Invalid Minutes_In_Package";
            }

            if (_request.RegisteredDate == null)
            {
                validRequest = "Invalid RegisteredDate it should be YYYY-MM-DD format";
            }

            if (validRequest == "")
            {
                Update_User_Minute_Response data = _userRepository.update_user_minute(_request);
                if (data == null)
                {
                    return new Update_User_Minute_Return() { Count = 0, ErrorMessage = "Record not found" };
                }
                else
                {
                    return new Update_User_Minute_Return() { Count = 1, ErrorMessage = null, WsResult = data };
                }
            }
            else
            {
                return new Update_User_Minute_Return() { Count = 0, ErrorMessage = validRequest };
            }
        }

        public Check_Geo_Location_Return check_geo_location(Check_Geo_Location_Request _request)
        {

            IPAddress adr = null;
            string validRequest = CommonRepositories.ValidateRequest(_request);
            if (validRequest.Equals("OK"))
            {
                validRequest = "";
            }


            if (validRequest == "" && string.IsNullOrEmpty(_request.Client_IP_Location))
            {
                validRequest = "Invalid Client_IP_Location";
            }
            else
            {

                Match match = Regex.Match(_request.Client_IP_Location, @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");
                if (!IPAddress.TryParse(_request.Client_IP_Location, out adr) || !match.Success)
                {
                    validRequest = "Invalid Client_IP_Location";
                }

            }


            if (validRequest != "")
            {

                return new Check_Geo_Location_Return() { Count = 0, ErrorMessage = validRequest };
            }
            else
            {

                double inetAtom = ExtensionMethods.inet_aton(adr);
                Check_Geo_Location_Response data = _userRepository.check_geo_location(_request, inetAtom);

                return new Check_Geo_Location_Return() { Count = 1, WsResult = data };
            }
        }

        public Get_Node3_Accesspoint_Ip_Return get_node3_accesspoint_ip(Get_Node3_Accesspoint_Ip_Request _request)
        {
            string validRequest = CommonRepositories.ValidateRequest(_request);
            if (validRequest.Equals("OK"))
            {
                validRequest = "";
            }

            if (validRequest != "")
            {
                return new Get_Node3_Accesspoint_Ip_Return() { Count = 0, ErrorMessage = validRequest };
            }
            else
            {
                Get_Node3_Accesspoint_Ip_Response data = _userRepository.get_node3_accesspoint_ip(_request);

                return new Get_Node3_Accesspoint_Ip_Return() { Count = 1, WsResult = data };
            }
        }
    }
}
