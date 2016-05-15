using ivrdating.Persistent.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ivrdating.Domain.VM;

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
                _request.Acc_Number = 0;
            }
            if (_request.Seconds_In_Package <= 0)
            {
                return new Add_To_User_Minute_Return() { Count = 0, ErrorMessage = "Minutes_In_Package Not defined (Function Add_To_User_Minute)", WsResult = null };
            }

            if (_request.RegisteredDate == null)
            {
                _request.RegisteredDate = DateTime.Now;
            }
            data = _userRepository.Add_To_User_Minute(_request);
            return new Add_To_User_Minute_Return() { Count = 1, ErrorMessage = null, WsResult = data };
        }

        public Add_To_Service_Source_Return Add_To_Service_Source(Add_To_Service_Source_Request _request)
        {
            string validRequest = CommonRepositories.ValidateRequest(_request);
            if (validRequest.Equals("OK"))
            {
                validRequest = "";
            }
            if (_request.Service_Source <= 0)
            {
                validRequest = "Service_Source Not defined";
            }
            if (string.IsNullOrEmpty(_request.Area_Code))
            {
                validRequest = "Area_Code Not defined";
            }

            if (_request.Acc_Number <= 0)
            {
                validRequest = "Invalid Account Number";
            }

            if (_request.RegisteredDate == null)
            {
                _request.RegisteredDate = DateTime.Now;
            }

            if (!string.IsNullOrEmpty(validRequest))
            {
                return new Add_To_Service_Source_Return() { Count = 1, ErrorMessage = validRequest, WsResult = null };
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
            if (validRequest == "" && _request.Acc_Number <= 0)
            {
                validRequest = "Invalid Acc_Number";
            }
            if (validRequest == "" && _request.Minutes_In_Package <= 0)
            {
                validRequest = "Minutes_In_Package Not defined";
            }

            _request.RegisteredDate = _request.RegisteredDate == null ? DateTime.Now : _request.RegisteredDate;

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
    }
}
