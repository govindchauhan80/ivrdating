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

        public Add_To_Payment_Details_Return Add_To_Payment_Details(Add_To_Payment_Details_Request _request)
        {
            string validRequest = CommonRepositories.ValidateRequest(_request);
            if (validRequest.Equals("OK"))
            {
                validRequest = "";
            }

            if (string.IsNullOrEmpty(_request.CallerId))
            {
                _request.CallerId = "0";
            }
            if (_request.Old_Expiry == null)
            {
                validRequest = "Old_Expiry Not defined ";
            }
            if (_request.New_Expiry == null)
            {
                validRequest = "New_Expiry Not defined ";
            }
            if (_request.Plan_Id <= 0)
            {
                validRequest = "Payment Plan_Id Not defined";
            }
            if (string.IsNullOrEmpty(_request.Plan_Amount) || !ExtensionMethods.IsNumeric(_request.Plan_Amount))
            {
                validRequest = "Invalid Payment Plan_Amount";
            }
            if (_request.Plan_Validity <= 0)
            {
                validRequest = "Invalid Payment Plan_Validity";
            }
            if (_request.Minutes_In_Package <= 0)
            {
                validRequest = "Invalid Payment Minutes_In_Package";
            }
            if (string.IsNullOrEmpty(_request.Package_Description))
            {
                validRequest = "Package_Description Not defined";
            }



            if (!string.IsNullOrEmpty(validRequest))
            {
                return new Add_To_Payment_Details_Return() { Count = 0, ErrorMessage = validRequest, WsResult = null };
            }
            Add_To_Payment_Details_Response data = _accountRepository.Add_To_Payment_Details(_request);
            return new Add_To_Payment_Details_Return() { Count = 1, ErrorMessage = null, WsResult = data };
        }

        public Update_Account_Return update_account(Update_Account_Request _request)
        {
            string validRequest = CommonRepositories.ValidateRequest(_request);
            if (validRequest.Equals("OK"))
            {
                validRequest = "";
            }

            if (string.IsNullOrEmpty(_request.CallerID) && validRequest == "")
            { _request.CallerID = "0"; }

            if (_request.New_Expiry == null && validRequest == "")
            {
                validRequest = "New_Expiry Not defined";
            }
            if (string.IsNullOrEmpty(_request.AccountType) && validRequest == "")
            {
                _request.AccountType = "0";
            }
            if (string.IsNullOrEmpty(_request.Active0In1) && validRequest == "")
            {
                _request.Active0In1 = "0";
            }
            if (string.IsNullOrEmpty(validRequest))
            {
                Update_Account_Response data = _accountRepository.update_account(_request);
                if (data == null)
                {
                    return new Update_Account_Return() { Count = 0, ErrorMessage = "No recorde updated" };
                }
                else
                {
                    return new Update_Account_Return() { Count = 0, ErrorMessage = null, WsResult = data };
                }
            }
            else
            {
                return new Update_Account_Return() { Count = 0, ErrorMessage = validRequest };
            }


        }

        public Validate_Return validate(Validate_Request _request)
        {
            string validRequest = CommonRepositories.ValidateRequest(_request);
            if (validRequest.Equals("OK"))
            {
                validRequest = "";
            }

            if (string.IsNullOrEmpty(_request.PassCode) && validRequest == "")
            {
                validRequest = "PassCode not define";
            }
            if (_request.Acc_Number <= 0 && validRequest == "")
            {
                validRequest = "Invalid Acc_Number";
            }
            if (string.IsNullOrEmpty(validRequest))
            {
                Validate_Response data = _accountRepository.validate(_request);
                if (data != null)
                {
                    return new Validate_Return() { Count = 1, ErrorMessage = null, WsResult = data };
                }
                else
                {
                    return new Validate_Return() { Count = 1, ErrorMessage = "Record not found" };
                }
            }
            else
            {
                return new Validate_Return() { Count = 0, ErrorMessage = validRequest };
            }
        }

        public Process_Mobile_Charge_Return process_mobile_charge(Process_Mobile_Charge_Request _request)
        {
            string validRequest = CommonRepositories.ValidateRequest(_request);
            if (validRequest.Equals("OK"))
            {
                validRequest = "";
            }

            if (string.IsNullOrEmpty(_request.SubscriberNo) && validRequest == "")
            {
                validRequest = "SubscriberNo not define";
            }
            if (_request.Acc_Number <= 0 && validRequest == "")
            {
                validRequest = "Invalid Acc_Number";
            }

            if (_request.SMS_Id <= 0 && validRequest == "")
            {
                validRequest = "Invalid Acc_Number";
            }
            if (_request.ChargeAmount <= 0 && validRequest == "")
            {
                validRequest = "Invalid ChargeAmount";
            }

            if (_request.CarrierId <= 0 && validRequest == "")
            {
                validRequest = "CarrierId ChargeAmount";
            }
            if (string.IsNullOrEmpty(_request.TicketId) && validRequest == "")
            {
                validRequest = "TicketId not define";
            }

            if (string.IsNullOrEmpty(validRequest))
            {
                Process_Mobile_Charge_Response data = _accountRepository.process_mobile_charge(_request);
                if (data == null)
                {
                    return new Process_Mobile_Charge_Return() { Count = 0, ErrorMessage = "No record found", WsResult = data };
                }
                else
                {
                    return new Process_Mobile_Charge_Return() { Count = 1, ErrorMessage = null, WsResult = data };

                }
            }
            else
            {
                return new Process_Mobile_Charge_Return() { Count = 0, ErrorMessage = validRequest };
            }
        }

        public Insert_Login_Log_Return insert_login_log(Insert_Login_Log_Request _request)
        {
            string validRequest = CommonRepositories.ValidateRequest(_request);
            if (validRequest.Equals("OK"))
            {
                validRequest = "";
            }

            if (string.IsNullOrEmpty(_request.TimeIn) && validRequest == "")
            {
            }
            else
            {
                if (!ExtensionMethods.IsNumeric(_request.TimeIn))
                {
                    validRequest = "Invalid TimeIn";
                }
            }

            if (validRequest == "")
            {
                Insert_Login_Log_Response data = _accountRepository.insert_login_log(_request);
                return new Insert_Login_Log_Return() { Count = 1, ErrorMessage = null, WsResult = data };
            }
            else
            {
                return new Insert_Login_Log_Return() { Count = 0, ErrorMessage = validRequest };

            }
        }

        public Update_Login_Log_Return update_login_log(Update_Login_Log_Request _request)
        {
            string validRequest = CommonRepositories.ValidateRequest(_request);
            if (validRequest.Equals("OK"))
            {
                validRequest = "";
            }

            if (string.IsNullOrEmpty(_request.TimeOut) && validRequest == "")
            {
            }
            else
            {
                if (!ExtensionMethods.IsNumeric(_request.TimeOut))
                {
                    validRequest = "Invalid TimeOut";
                }
            }

            if (validRequest == "")
            {
                Update_Login_Log_Response data = _accountRepository.update_login_log(_request);
                if (data == null)
                {
                    return new Update_Login_Log_Return() { Count = 0, ErrorMessage = "No record found", WsResult = data };
                }
                else
                {
                    return new Update_Login_Log_Return() { Count = 1, ErrorMessage = null, WsResult = data };
                }
            }
            else
            {
                return new Update_Login_Log_Return() { Count = 0, ErrorMessage = validRequest };

            }
        }

        public Admin_Web_Screening_Return admin_web_screening(Admin_Web_Screening_Request _request, string path)
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
            if (validRequest == "" && _request.App1Del2 <= 0)
            {
                validRequest = "Incomplete Request 'App1Del2 not define'";
            }
            if (validRequest == "")
            {
                Admin_Web_Screening_Response data = _accountRepository.admin_web_screening(_request, path);

                if (data == null)
                {
                    return new Admin_Web_Screening_Return() { Count = 0, ErrorMessage = "Account Not Find" };
                }
                else
                {
                    return new Admin_Web_Screening_Return() { Count = 0, ErrorMessage = null, WsResult = data };
                }
            }
            else
            {
                return new Admin_Web_Screening_Return() { Count = 0, ErrorMessage = validRequest };
            }
        }

        public Getchargeamount_Return getchargeamount(Getchargeamount_Request _request)
        {
            string validRequest = CommonRepositories.ValidateRequest(_request);
            if (validRequest.Equals("OK"))
            {
                validRequest = "";
            }
            if (validRequest == "" && _request.Plan_Id <= 0)
            {
                validRequest = "Plan_Id not define";
            }
            if (validRequest == "" && _request.Area_Code <= 0)
            {
                validRequest = "Area_Code not define";
            }

            if (validRequest == "")
            {
                Getchargeamount_Response data = _accountRepository.getchargeamount(_request);

                if (data == null)
                {
                    return new Getchargeamount_Return() { Count = 0, ErrorMessage = "Payment Plan Not Found" };
                }
                else
                {
                    return new Getchargeamount_Return() { Count = 1, WsResult = data };

                }
            }
            else
            {
                return new Getchargeamount_Return() { Count = 0, ErrorMessage = validRequest };
            }
        }

        public Delete_Completeaccount_Return delete_completeaccount(Delete_Completeaccount_Request _request)
        {
            string validRequest = CommonRepositories.ValidateRequest(_request);
            if (validRequest.Equals("OK"))
            {
                validRequest = "";
            }
            if (validRequest == "" && _request.Acc_Number <= 0)
            {
                validRequest = "Acc_Number not define";
            }
            if (validRequest == "")
            {
                Delete_Completeaccount_Response data = _accountRepository.delete_completeaccount(_request);
                if (data == null)
                {
                    return new Delete_Completeaccount_Return() { Count = 0, ErrorMessage = "No record found" };
                }
                else
                {
                    return new Delete_Completeaccount_Return() { Count = 1, WsResult = data };
                }
            }
            else
            {
                return new Delete_Completeaccount_Return() { Count = 0, ErrorMessage = validRequest };
            }
        }

        public Read_Misc_Return read_misc(Read_Misc_Request _request)
        {
            string validRequest = CommonRepositories.ValidateRequest(_request);
            if (validRequest.Equals("OK"))
            {
                validRequest = "";
            }
            if (validRequest == "")
            {
                Read_Misc_Response data = _accountRepository.read_misc(_request);

                return new Read_Misc_Return() { Count = 1, WsResult = data };
            }
            else
            {
                return new Read_Misc_Return() { Count = 0, ErrorMessage = validRequest };
            }
        }

        public Set_Misc_Return set_misc(Set_Misc_Request _request)
        {
            string validRequest = CommonRepositories.ValidateRequest(_request);
            if (validRequest.Equals("OK"))
            {
                validRequest = "";
            }
            if (validRequest == "")
            {
                Set_Misc_Response data = _accountRepository.set_misc(_request);

                if (data == null)
                {
                    return new Set_Misc_Return() { Count = 0, ErrorMessage = "Invalid Setting name" };
                }

                return new Set_Misc_Return() { Count = 1, WsResult = data };
            }
            else
            {
                return new Set_Misc_Return() { Count = 0, ErrorMessage = validRequest };
            }
        }

        public Set_Primary_Apiserver_Return set_primary_apiserver(Set_Primary_Apiserver_Request _request)
        {
            string validRequest = CommonRepositories.ValidateRequest(_request);
            if (validRequest.Equals("OK"))
            {
                validRequest = "";
            }
            if (validRequest == "")
            {
                validRequest = CommonRepositories.ValidateIp(_request.ActiveServerIP);
            }
            if (validRequest == "")
            {
                Set_Primary_Apiserver_Response data = _accountRepository.set_primary_apiserver(_request);
                if (data == null)
                {
                    return new Set_Primary_Apiserver_Return() { Count = 0, ErrorMessage = "No record found" };
                }
                else
                {
                    return new Set_Primary_Apiserver_Return() { Count = 1, WsResult = data };
                }
            }
            else
            {
                return new Set_Primary_Apiserver_Return() { Count = 0, ErrorMessage = validRequest };
            }
        }
    }
}
