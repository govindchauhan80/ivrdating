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



            if (string.IsNullOrEmpty(_request.CallerId))
            {
                return new Get_New_Acc_Number_Return { Count = 0, ErrorMessage = "CallerId Not defined", WsResult = null };
            }
            else
            {
                double ps = 0;

                if (double.TryParse(_request.CallerId, out ps))
                {
                    if (ps <= 999999999 || ps > 9999999999)
                    {
                        ps = 0;
                    }
                }
                if (ps == 0)
                {
                    return new Get_New_Acc_Number_Return { Count = 0, ErrorMessage = "Invalid CallerId it has 10 digit numeric only", WsResult = null };
                }
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

            if (_request.Acc_Number <= 0)
            {
                return new Activate_Acc_Number_Return() { Count = 0, ErrorMessage = "Invalid Acc_Number it can 6 digit numeric only", WsResult = null };
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

            if (_request.Acc_Number <= 0)
            {
                return new Deactivate_Acc_Number_Return() { Count = 0, ErrorMessage = "Invalid Acc_Number it can 6 digit numeric only", WsResult = null };
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
            string validRequest = CommonRepositories.ValidateRequest(_request);
            if (!validRequest.Equals("OK"))
            {
                return new Add_New_Account_Return() { Count = 0, ErrorMessage = validRequest, WsResult = null };
            }
            if (_request.Acc_Number <= 0)
            {
                return new Add_New_Account_Return { Count = 0, ErrorMessage = "Invalid Acc_Number it can 6 digit numeric only", WsResult = null };
            }
            if (_request.RegisteredDate == null)
            {
                _request.RegisteredDate = DateTime.Now;
            }
            //if (string.IsNullOrEmpty(_request.CallerId))
            //{
            //    _request.CallerId = "0";
            //}



            if (string.IsNullOrEmpty(_request.AccountType))
            {
                return new Add_New_Account_Return { Count = 0, ErrorMessage = "Account Type Not defined (Function Add_New_Account)", WsResult = null };
            }
            else if (_request.AccountType != "0" && _request.AccountType != "1")
            {
                return new Add_New_Account_Return { Count = 0, ErrorMessage = "Account Type can be 0 OR 1 only", WsResult = null };
            }

            if (string.IsNullOrEmpty(_request.PassCode))
            {
                return new Add_New_Account_Return { Count = 0, ErrorMessage = "PassCode Not defined (Function Add_New_Account)", WsResult = null };
            }
            else
            {
                int ps = 0;

                if (int.TryParse(_request.PassCode, out ps))
                {
                    if (ps <= 999 || ps > 9999)
                    {
                        ps = 0;
                    }
                }
                if (ps == 0)
                {
                    return new Add_New_Account_Return { Count = 0, ErrorMessage = "invalid PassCode it has 4 digit numeric only", WsResult = null };
                }
            }

            if (string.IsNullOrEmpty(_request.Active0In1))
            {
                return new Add_New_Account_Return { Count = 0, ErrorMessage = "Active0In1 Type Not defined (Function Add_New_Account)", WsResult = null };
            }
            else if (_request.Active0In1 != "0" && _request.Active0In1 != "1")
            {
                return new Add_New_Account_Return { Count = 0, ErrorMessage = "Active0In1e can be 0 OR 1 only", WsResult = null };
            }


            if (string.IsNullOrEmpty(_request.CallerId))
            {
                return new Add_New_Account_Return { Count = 0, ErrorMessage = "CallerId Not defined (Function Add_New_Account)", WsResult = null };
            }
            else
            {
                double ps = 0;

                if (double.TryParse(_request.CallerId, out ps))
                {
                    if (ps <= 999999999 || ps > 9999999999)
                    {
                        ps = 0;
                    }
                }
                if (ps == 0)
                {
                    return new Add_New_Account_Return { Count = 0, ErrorMessage = "Invalid CallerId it has 10 digit numeric only", WsResult = null };
                }
            }

            if (_request.PlanExpiresOn == null)
            {
                return new Add_New_Account_Return { Count = 0, ErrorMessage = "Plan Expires On Not defined (Function Add_New_Account)", WsResult = null };
            }


            


            var data = _accountRepository.Add_New_Account(_request);

            if (data != null)
            {
                return new Add_New_Account_Return() { Count = 1, ErrorMessage = string.Empty, WsResult = data };
            }
            else
            {
                return new Add_New_Account_Return() { Count = 0, ErrorMessage = "This Account Number already exist" };
            }
        }

        public Add_To_Payment_Details_Return Add_To_Payment_Details(Add_To_Payment_Details_Request _request)
        {
            string validRequest = CommonRepositories.ValidateRequest(_request);
            if (validRequest.Equals("OK"))
            {
                validRequest = "";
            }
            else
            {
                return new Add_To_Payment_Details_Return() { Count = 0, ErrorMessage = validRequest, WsResult = null };
            }

            if (_request.Acc_Number <= 0)
            {
                validRequest = "Invalid Acc_Number it can 6 digit numeric only";
            }

            if (string.IsNullOrEmpty(_request.CallerId))
            {
                validRequest = "Invalid CallerId it has 10 digit numeric only";
            }
            else
            {
                double ps = 0;

                if (double.TryParse(_request.CallerId, out ps))
                {
                    if (ps <= 999999999 || ps > 9999999999)
                    {
                        ps = 0;
                    }
                }
                if (ps == 0)
                {
                    validRequest = "Invalid CallerId it has 10 digit numeric only";
                }
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
            decimal d;
            if (string.IsNullOrEmpty(_request.Plan_Amount) || !decimal.TryParse(_request.Plan_Amount, out d))
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
            else
            {
                return new Update_Account_Return() { Count = 0, ErrorMessage = validRequest };
            }

            if (validRequest == "")
            {
                double ps = 0;

                if (double.TryParse(_request.CallerID, out ps))
                {
                    if (ps <= 999999999 || ps > 9999999999)
                    {
                        ps = 0;
                    }
                }
                if (ps == 0)
                {
                    validRequest = "Invalid CallerId it has 10 digit numeric only";
                }
            }
           

            if (_request.New_Expiry == null && validRequest == "")
            {
                validRequest = "New_Expiry Not defined";
            }
            if (_request.AccountType != "0" && _request.AccountType != "1")
            {
                validRequest = "Account Type can be 0 OR 1 only";
            }
             if (_request.Active0In1 != "0" && _request.Active0In1 != "1")
            {
                validRequest = "Active0In1 can be 0 OR 1 only";
            }
            if (_request.Acc_Number <= 0 && validRequest == "")
            {
                validRequest = "Invalid Acc_Number it can 6 digit numeric only";
            }
            if (string.IsNullOrEmpty(validRequest))
            {
                Update_Account_Response data = _accountRepository.update_account(_request);
                if (data == null)
                {
                    return new Update_Account_Return() { Count = 0, ErrorMessage = "No records updated" };
                }
                else
                {
                    return new Update_Account_Return() { Count = 1, ErrorMessage = null, WsResult = data };
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
            else
            {
                return new Validate_Return() { Count = 0, ErrorMessage = validRequest };
            }

            if (string.IsNullOrEmpty(_request.PassCode) && validRequest == "")
            {
                validRequest = "PassCode not define";
            }
            else
            {
                int ps = 0;

                if (int.TryParse(_request.PassCode, out ps))
                {
                    if (ps <= 999 || ps > 9999)
                    {
                        ps = 0;
                    }
                }
                if (ps == 0)
                {
                    validRequest = "invalid PassCode it has 4 digit numeric only";
                }
            }
            if (_request.Acc_Number <= 0 && validRequest == "")
            {
                validRequest = "Invalid Acc_Number it can 6 digit numeric only";
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
            else
            {
                return new Process_Mobile_Charge_Return() { Count = 0, ErrorMessage = validRequest };
            }

            if (string.IsNullOrEmpty(_request.SubscriberNo) && validRequest == "")
            {
                validRequest = "Subscriber No not define";
            }
            else
            {
                double ps1 = 0;

                if (double.TryParse(_request.SubscriberNo, out ps1))
                {
                    if (ps1 <= 999999999 || ps1 > 9999999999)
                    {
                        ps1 = 0;
                    }
                }
                if (ps1 == 0)
                {
                    validRequest = "Invalid SubscriberNo it has 10 digit numeric only";
                }
            }


            if (_request.Acc_Number <= 0 && validRequest == "")
            {
                validRequest = "Invalid Acc_Number it can 6 digit numeric only";
            }

            if (_request.SMS_Id <= 0 && validRequest == "")
            {
                validRequest = "Invalid SMS_Id";
            }
            if (_request.ChargeAmount <= 0 && validRequest == "")
            {
                validRequest = "Invalid ChargeAmount";
            }

            if (_request.CarrierId <= 0 && validRequest == "")
            {
                validRequest = "Invalid CarrierId";
            }
            if (string.IsNullOrEmpty(_request.TicketId) && validRequest == "")
            {
                validRequest = "TicketId not define";
            }
            else
            {
                Guid g;

                if (!Guid.TryParse(_request.TicketId, out g))
                {
                    validRequest = "TicketId should be a valid GUID";
                }
            }
            int ps = 0;

            if (int.TryParse(_request.PassCode.ToString(), out ps))
            {
                if (ps <= 999 || ps > 9999)
                {
                    ps = 0;
                }
            }
            if (ps == 0)
            {
                validRequest = "Invalid PassCode it has 4 digit numeric only";
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
            else
            {
                return new Insert_Login_Log_Return() { Count = 0, ErrorMessage = validRequest };

            }

            //if (string.IsNullOrEmpty(_request.TimeIn) && validRequest == "")
            //{
            //}
            //else
            //{
            //    if (!ExtensionMethods.IsNumeric(_request.TimeIn))
            //    {
            //        validRequest = "Invalid TimeIn";
            //    }
            //}

            DateTime dt;
            if (!string.IsNullOrEmpty(_request.DateIn))
            {
                validRequest = CommonRepositories.ValidateDateString(_request.DateIn);

            }

            if (!string.IsNullOrEmpty(_request.LastTimeStamp.ToString()) && !DateTime.TryParse(_request.LastTimeStamp.ToString(), out dt))
            {
                validRequest = "Invalid LastTimeStamp it should be YYYYMMDD format";
            }


            if (_request.TimeIn != null)
            {
                validRequest = CommonRepositories.ValidateTimeString(_request.TimeIn);
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
            else
            {
                return new Update_Login_Log_Return() { Count = 0, ErrorMessage = validRequest };

            }

            DateTime dt;
            if (!string.IsNullOrEmpty(_request.DateOut))
            {
                validRequest = CommonRepositories.ValidateDateString(_request.DateOut);

            }

            if (!string.IsNullOrEmpty(_request.LastTimeStamp.ToString()) && !DateTime.TryParse(_request.LastTimeStamp.ToString(), out dt))
            {
                validRequest = "Invalid LastTimeStamp it should be YYYYMMDD format";
            }


            if (_request.TimeOut != null)
            {
                validRequest = CommonRepositories.ValidateTimeString(_request.TimeOut);
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
                validRequest = "Invalid Acc_Number it can 6 digit numeric only";
            }
            if (validRequest == "" && _request.App1Del2 <= 0)
            {
                validRequest = "Incomplete Request 'App1Del2 not define'";
            }
            else if (validRequest == "" && _request.App1Del2 > 2)
            {
                validRequest = "Incomplete Request 'App1Del2 can be 1 OR 2 only";
            }
            if (validRequest == "")
            {
                Admin_Web_Screening_Response data = _accountRepository.admin_web_screening(_request, path);

                if (data == null)
                {
                    return new Admin_Web_Screening_Return() { Count = 0, ErrorMessage = "Acc_Number " + _request.Acc_Number + " not found" };
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
            if (validRequest == "" && string.IsNullOrEmpty(_request.Area_Code))
            {
                validRequest = "Area_Code not define";
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
                validRequest = "Invalid Acc_Number it can 6 digit numeric only";
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

        public Add_Complete_Paid_Account_Return add_complete_paid_account(Add_Complete_Paid_Account_Request _request)
        {
            string validRequest = CommonRepositories.ValidateRequest(_request);
            if (validRequest.Equals("OK"))
            {
                validRequest = "";
            }
            else
            {
                return new Add_Complete_Paid_Account_Return() { Count = 0, ErrorMessage = validRequest };
            }
            if (string.IsNullOrEmpty(_request.CallerId))
            {
                validRequest = "Invalid CallerId it has 10 digit numeric only";
            }
            else
            {
                double ps = 0;

                if (double.TryParse(_request.CallerId, out ps))
                {
                    if (ps <= 999999999 || ps > 9999999999)
                    {
                        ps = 0;
                    }
                }
                if (ps == 0)
                {
                    validRequest = "Invalid CallerId it has 10 digit numeric only";
                }
            }


            if (_request.Old_Expiry == null)
            {
                validRequest = "Old_Expiry Not defined ";
            }
            if (_request.PlanExpiresOn == null)
            {
                validRequest = "PlanExpiresOn Not defined ";
            }
            if (_request.New_Expiry == null)
            {
                validRequest = "New_Expiry Not defined ";
            }
            if (_request.Plan_Id <= 0)
            {
                validRequest = "Payment Plan_Id Not defined";
            }
            if (_request.Plan_Amount <= 0)
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

            if (string.IsNullOrEmpty(_request.PassCode))
            {
                validRequest = "PassCode Not defined";
            }
            else
            {
                int ps = 0;
                if (int.TryParse(_request.PassCode, out ps))
                {
                    if (ps <= 999 || ps > 9999)
                    {
                        ps = 0;
                    }
                }
                if (ps == 0)
                {
                    validRequest = "Invalid PassCode it has 4 digit numeric only";
                }
            }
            if (string.IsNullOrEmpty(_request.AccountType))
            {
                validRequest = "AccountType Not defined";
            }
            else if (_request.AccountType != "0" && _request.AccountType != "1")
            {
                validRequest = "Account Type can be 0 OR 1 only";
            }

            if (string.IsNullOrEmpty(_request.Area_Code))
            {
                validRequest = "Area_Code Not defined";
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
            if (_request.Service_Source <= 0)
            {
                validRequest = "Service_Source Not defined";
            }
            //if (string.IsNullOrEmpty(_request.CallerId))
            //{
            //    _request.CallerId = "0";
            //}
            if (_request.Acc_Number <= 0)
            {
                validRequest = "Invalid Acc_Number it can 6 digit numeric only";
            }
            if (_request.RegisteredDate == null)
            {
                _request.RegisteredDate = DateTime.Now;
            }
            //if (string.IsNullOrEmpty(_request.CallerId))
            //{
            //    _request.CallerId = "0";
            //}

            if (string.IsNullOrEmpty(_request.Active0In1))
            {
                _request.Active0In1 = "0";
            }

            if (validRequest == "")
            {
                _request.Plan_Amount = decimal.Round(_request.Plan_Amount, 2);
                Add_Complete_Paid_Account_Response data = _accountRepository.add_complete_paid_account(_request);
                if (data == null)
                {
                    return new Add_Complete_Paid_Account_Return() { Count = 0, ErrorMessage = "No record found" };
                }
                else
                {
                    return new Add_Complete_Paid_Account_Return()
                    {
                        Count = 1,
                        WsResult = data
                    };
                }
            }
            else
            {
                return new Add_Complete_Paid_Account_Return() { Count = 0, ErrorMessage = validRequest };
            }
        }

        public Modify_Customer_Info_Return modify_customer_info(Modify_Customer_Info_Request _request)
        {
            Modify_Customer_Info_Return data = new Modify_Customer_Info_Return();
            string validRequest = CommonRepositories.ValidateRequest(_request);
            if (validRequest.Equals("OK"))
            {
                validRequest = "";
            }
            else
            {
                data = new Modify_Customer_Info_Return() { Count = 0, ErrorMessage = validRequest };
            }
            int cnt = 0;
            if (string.IsNullOrEmpty(_request.CallerId))
            {
                _request.CallerId = "-1";
                cnt++;
            }
            if (string.IsNullOrEmpty(_request.PassCode))
            {
                _request.PassCode = "-1";
                cnt++;
            }
            if (string.IsNullOrEmpty(_request.WebPassword))
            {
                _request.WebPassword = "-1";
                cnt++;
            }

            if (_request.Acc_Number <= 0)
            {
                validRequest = "Invalid Acc_Number it can 6 digit numeric only";
            }

            if (string.IsNullOrEmpty(_request.CallerId))
            {
                validRequest = "CallerId Not defined";
            }
            else
            {
                double ps = 0;

                if (double.TryParse(_request.CallerId, out ps))
                {
                    if (ps <= 999999999 || ps > 9999999999)
                    {
                        ps = 0;
                    }
                }
                if (ps == 0)
                {
                    validRequest = "Invalid CallerId it has 10 digit numeric only";
                }
            }


            if (string.IsNullOrEmpty(_request.PassCode))
            {
                validRequest = "PassCode Not defined";
            }
            else
            {
                int ps = 0;

                if (int.TryParse(_request.PassCode, out ps))
                {
                    if (ps <= 999 || ps > 9999)
                    {
                        ps = 0;
                    }
                }
                if (ps == 0)
                {
                    validRequest = "Invalid PassCode it has 4 digit numeric only";
                }
            }


            if (cnt == 3 && string.IsNullOrEmpty(validRequest))
            {
                validRequest = "CAN NOT SEARCH CUSTOMER DETAILS, INCOMPLETE SEARCH CRITERIA";
            }
            if (string.IsNullOrEmpty(validRequest))
            {
                Modify_Customer_Info_Response rs = _accountRepository.modify_customer_info(_request);

                if (rs == null)
                {
                    data = new Modify_Customer_Info_Return() { Count = 0, ErrorMessage = "Acc_Number not found" };
                }
                else
                {
                    data = new Modify_Customer_Info_Return() { Count = 1, WsResult = rs };
                }
            }
            else
            {
                data = new Modify_Customer_Info_Return() { Count = 0, ErrorMessage = validRequest };
            }

            return data;
        }
    }
}
