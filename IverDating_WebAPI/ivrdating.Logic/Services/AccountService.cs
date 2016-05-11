using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ivrdating.Persistent.Repositories;
using ivrdating.Domain;
using ivrdating.Domain.VM;

namespace ivrdating.Logic.Services
{
    public class AccountService
    {
        AccountRepository _accountRepository;
        public AccountService()
        {
            _accountRepository = new AccountRepository();
        }

        public IList<account> GetAll()
        {
            return _accountRepository.GetAll();
        }

        public Get_New_Acc_Number_Return Get_New_Acc_Number(Get_New_Acc_Number_Request _request)
        {
            string validRequest = CommonRepositories.ValidateRequest(_request);
            if (!validRequest.Equals("OK"))
            {
                return new Get_New_Acc_Number_Return() { Count = 0, ErrorMessage = validRequest, WsResult = null };
            }
            var data = _accountRepository.Get_New_Acc_Number(_request);
            if (data != null)
            {
                return new Get_New_Acc_Number_Return() { Count = 1, ErrorMessage = string.Empty, WsResult = data };
            }
            else
            {
                return new Get_New_Acc_Number_Return() { Count = 0, ErrorMessage = "No free records in accountids Table", WsResult = null };
            }
        }


        public Get_N_Activate_New_Acc_Number_Return Get_N_Activate_New_Acc_Number(Get_N_Activate_New_Acc_Number_Request _request)
        {
            string validRequest = CommonRepositories.ValidateRequest(_request);
            if (!validRequest.Equals("OK"))
            {
                return new Get_N_Activate_New_Acc_Number_Return() { Count = 0, ErrorMessage = validRequest, WsResult = null };
            }
            var data = _accountRepository.Get_N_Activate_New_Acc_Number(_request);

            if (data != null)
            {
                return new Get_N_Activate_New_Acc_Number_Return() { Count = 1, ErrorMessage = string.Empty, WsResult = data };
            }
            else
            {
                return new Get_N_Activate_New_Acc_Number_Return() { Count = 0, ErrorMessage = "No free records in accountids Table", WsResult = null };
            }
        }

        public Activate_Acc_Number_Return Activate_Acc_Numbe(Activate_Acc_Number_Request _request)
        {
            string validRequest = CommonRepositories.ValidateRequest(_request);
            if (!validRequest.Equals("OK"))
            {
                return new Activate_Acc_Number_Return() { Count = 0, ErrorMessage = validRequest, WsResult = null };
            }
            var data = _accountRepository.Activate_Acc_Numbe(_request);

            if (data != null)
            {
                return new Activate_Acc_Number_Return() { Count = 1, ErrorMessage = string.Empty, WsResult = data };
            }
            else
            {
                return new Activate_Acc_Number_Return() { Count = 0, ErrorMessage = "No records found in accountids Table", WsResult = null };
            }
        }

        public Deactivate_Acc_Number_Return Deactivate_Acc_Number(Deactivate_Acc_Number_Request _request)
        {
            string validRequest = CommonRepositories.ValidateRequest(_request);
            if (!validRequest.Equals("OK"))
            {
                return new Deactivate_Acc_Number_Return() { Count = 0, ErrorMessage = validRequest, WsResult = null };
            }
            var data = _accountRepository.Deactivate_Acc_Number(_request);

            if (data != null)
            {
                return new Deactivate_Acc_Number_Return() { Count = 1, ErrorMessage = string.Empty, WsResult = data };
            }
            else
            {
                return new Deactivate_Acc_Number_Return() { Count = 0, ErrorMessage = "No records found in accountids Table", WsResult = null };
            }
        }

        public Add_New_Account_Return Add_New_Account(Add_New_Account_Request _request)
        {
            if (_request.Acc_Number <= 0)
            {
                _request.Acc_Number = 0;
            }
            if (_request.RegisteredDate == null)
            {
                _request.RegisteredDate = DateTime.Now;
            }
            if (string.IsNullOrEmpty(_request.CallerId))
            {
                _request.CallerId = "0";
            }

            if (string.IsNullOrEmpty(_request.Active0In1))
            {
                _request.Active0In1 = "0";
            }

            if (string.IsNullOrEmpty(_request.AccountType))
            {
                return new Add_New_Account_Return { Count = 0, ErrorMessage = "Account Type Not defined (Function Add_New_Account)", WsResult = null };
            }

            if (string.IsNullOrEmpty(_request.PassCode))
            {
                return new Add_New_Account_Return { Count = 0, ErrorMessage = "PassCode Not defined (Function Add_New_Account)", WsResult = null };
            }

            if (_request.PlanExpiresOn == null)
            {
                return new Add_New_Account_Return { Count = 0, ErrorMessage = "Plan Expires On Not defined (Function Add_New_Account)", WsResult = null };
            }


            string validRequest = CommonRepositories.ValidateRequest(_request);
            if (!validRequest.Equals("OK"))
            {
                return new Add_New_Account_Return() { Count = 0, ErrorMessage = validRequest, WsResult = null };
            }


            var data = _accountRepository.Add_New_Account(_request);

            if (data != null)
            {
                return new Add_New_Account_Return() { Count = 1, ErrorMessage = string.Empty, WsResult = data };
            }


            return null;
        }
    }
}
