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
    }
}
