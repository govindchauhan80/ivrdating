using ivrdating.Domain;
using ivrdating.Domain.VM;
using ivrdating.Log;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Persistent.Repositories
{
    public class AccountRepository
    {
        ivrdating.Domain.ivrdating _context;
        LogRequestResponse _logRequestResponse;

        public AccountRepository()
        {
            _context = new ivrdating.Domain.ivrdating();

            //SetDatabaseLogFormatter(
            //   (_context, writeAction) => new OneLineFormatter(_context, writeAction));
            _logRequestResponse = new LogRequestResponse();
            if (CommonRepositories.debugMode.Equals("On", StringComparison.OrdinalIgnoreCase))
                _context.Database.Log = s => _logRequestResponse.LogData(s, "Warn");
        }

        public IList<account> GetAll()
        {
            return (from ac in _context.accounts select ac).ToList<account>();
        }

        public Get_New_Acc_Number_Response Get_New_Acc_Number(Get_New_Acc_Number_Request _request)
        {
            Get_New_Acc_Number_Response response = null;
            string Grp_id = CommonRepositories.GetGroupID(_request.Group_Prefix);
            if (!string.IsNullOrEmpty(_request.CallerId))
            {
                response = (from ac in _context.accounts where ac.callerid == _request.CallerId && (ac.Gender == "1" || ac.Gender == "2") select new Get_New_Acc_Number_Response() { Acc_Number = ac.Acc_Number, PassCode = ac.PassCode }).FirstOrDefault();

                if (response != null)
                {
                    return response;
                }
            }

            int min = int.MaxValue, max = 0;
            int OrderIdValue;
            if (Grp_id == "1")
            {

                var ss = (from aci in _context.accountids select new GetAccountIdsEnum { Id = aci.Id, Grp_Id = aci.Grp_Id1 }).ToList();

                MinMax(ref min, ref max, ss);


                OrderIdValue = new Random().Next(min, max);
                response = (from aci in _context.accountids where aci.Grp_Id1 == "0" && aci.Id > OrderIdValue select new Get_New_Acc_Number_Response() { Acc_Number = aci.Acc_Number, PassCode = aci.PassCode }).FirstOrDefault();
            }
            else if (Grp_id == "2")
            {
                min = (from aci in _context.accountids where aci.Grp_Id2 == "0" select aci.Id).Min();
                max = (from aci in _context.accountids where aci.Grp_Id2 == "0" select aci.Id).Max();

                OrderIdValue = new Random().Next(min, max);
                response = (from aci in _context.accountids where aci.Grp_Id2 == "0" && aci.Id > OrderIdValue select new Get_New_Acc_Number_Response() { Acc_Number = aci.Acc_Number, PassCode = aci.PassCode }).FirstOrDefault();
            }
            else if (Grp_id == "3")
            {
                min = (from aci in _context.accountids where aci.Grp_Id3 == "0" select aci.Id).Min();
                max = (from aci in _context.accountids where aci.Grp_Id3 == "0" select aci.Id).Max();

                OrderIdValue = new Random().Next(min, max);
                response = (from aci in _context.accountids where aci.Grp_Id3 == "0" && aci.Id > OrderIdValue select new Get_New_Acc_Number_Response() { Acc_Number = aci.Acc_Number, PassCode = aci.PassCode }).FirstOrDefault();
            }
            else if (Grp_id == "4")
            {
                min = (from aci in _context.accountids where aci.Grp_Id4 == "0" select aci.Id).Min();
                max = (from aci in _context.accountids where aci.Grp_Id4 == "0" select aci.Id).Max();

                OrderIdValue = new Random().Next(min, max);
                response = (from aci in _context.accountids where aci.Grp_Id4 == "0" && aci.Id > OrderIdValue select new Get_New_Acc_Number_Response() { Acc_Number = aci.Acc_Number, PassCode = aci.PassCode }).FirstOrDefault();
            }
            else if (Grp_id == "5")
            {
                min = (from aci in _context.accountids where aci.Grp_Id5 == "0" select aci.Id).Min();
                max = (from aci in _context.accountids where aci.Grp_Id5 == "0" select aci.Id).Max();

                OrderIdValue = new Random().Next(min, max);
                response = (from aci in _context.accountids where aci.Grp_Id5 == "0" && aci.Id > OrderIdValue select new Get_New_Acc_Number_Response() { Acc_Number = aci.Acc_Number, PassCode = aci.PassCode }).FirstOrDefault();
            }
            else if (Grp_id == "6")
            {
                min = (from aci in _context.accountids where aci.Grp_Id6 == "0" select aci.Id).Min();
                max = (from aci in _context.accountids where aci.Grp_Id6 == "0" select aci.Id).Max();

                OrderIdValue = new Random().Next(min, max);
                response = (from aci in _context.accountids where aci.Grp_Id6 == "0" && aci.Id > OrderIdValue select new Get_New_Acc_Number_Response() { Acc_Number = aci.Acc_Number, PassCode = aci.PassCode }).FirstOrDefault();
            }
            else if (Grp_id == "7")
            {
                min = (from aci in _context.accountids where aci.Grp_Id7 == "0" select aci.Id).Min();
                max = (from aci in _context.accountids where aci.Grp_Id7 == Grp_id select aci.Id).Max();

                OrderIdValue = new Random().Next(min, max);
                response = (from aci in _context.accountids where aci.Grp_Id7 == "0" && aci.Id > OrderIdValue select new Get_New_Acc_Number_Response() { Acc_Number = aci.Acc_Number, PassCode = aci.PassCode }).FirstOrDefault();
            }
            else if (Grp_id == "8")
            {
                min = (from aci in _context.accountids where aci.Grp_Id8 == "0" select aci.Id).Min();
                max = (from aci in _context.accountids where aci.Grp_Id8 == "0" select aci.Id).Max();

                OrderIdValue = new Random().Next(min, max);
                response = (from aci in _context.accountids where aci.Grp_Id8 == "0" && aci.Id > OrderIdValue select new Get_New_Acc_Number_Response() { Acc_Number = aci.Acc_Number, PassCode = aci.PassCode }).FirstOrDefault();
            }
            else if (Grp_id == "9")
            {
                min = (from aci in _context.accountids where aci.Grp_Id9 == "0" select aci.Id).Min();
                max = (from aci in _context.accountids where aci.Grp_Id9 == "0" select aci.Id).Max();

                OrderIdValue = new Random().Next(min, max);
                response = (from aci in _context.accountids where aci.Grp_Id9 == "0" && aci.Id > OrderIdValue select new Get_New_Acc_Number_Response() { Acc_Number = aci.Acc_Number, PassCode = aci.PassCode }).FirstOrDefault();
            }


            if (response != null)
            {
                //Add to the acc_number_web TABLE
                acc_number_web acWeb = new acc_number_web();
                acWeb.Acc_Number = response.Acc_Number;
                acWeb.Grp_Id = Grp_id;
                acWeb.Subscriber_Mobile = "1";
                acWeb.AllocatedOn = DateTime.Now;
                ivrdating.Domain.ivrdating d = new Domain.ivrdating();
                d.acc_number_web.Add(acWeb);
                try
                {
                    d.SaveChanges();
                }
                catch { }
            }

            return response;
        }

        public Add_To_Payment_Details_Response Add_To_Payment_Details(Add_To_Payment_Details_Request _request)
        {

            string Grp_id = CommonRepositories.GetGroupID(_request.Group_Prefix);
            string FIRST_ONE_CC, LAST_FOUR_CC;
            if (!string.IsNullOrEmpty(_request.FULL_CC_NUMBER) && _request.FULL_CC_NUMBER.Length >= 1)
            {
                FIRST_ONE_CC = _request.FULL_CC_NUMBER.Substring(0, 1);
            }
            else
            {
                FIRST_ONE_CC = "";
            }
            if (!string.IsNullOrEmpty(_request.FULL_CC_NUMBER) && _request.FULL_CC_NUMBER.Length >= 4)
            {
                LAST_FOUR_CC = _request.FULL_CC_NUMBER.Substring(_request.FULL_CC_NUMBER.Length - 4, 4);
            }
            else
            {
                LAST_FOUR_CC = "";
            }
            if (_request.Charged_Amount <= 0)
            {
                _request.Charged_Amount = -1;
            }

            decimal Tax_Perc_Amount = 0;
            decimal AppFee_Static_Amount = 0;
            decimal AppFee_Perc_Amount = 0;

            if (!string.IsNullOrEmpty(_request.FULL_CC_NUMBER) || !string.IsNullOrEmpty(_request.CVC))
            {
                using (var con = new ivrdating.Domain.ivrdating())
                {
                    if (!string.IsNullOrEmpty(_request.FULL_CC_NUMBER))
                    {
                        _request.FULL_CC_NUMBER = con.Database.SqlQuery<string>("select AES_Encrypt('@FCC',  MD5('" + CC_Encryption_SALT + "'))", new object[] { new ObjectParameter("FCC", _request.FULL_CC_NUMBER) }).FirstOrDefault();
                    }

                    if (!string.IsNullOrEmpty(_request.CVC))
                    {
                        _request.CVC = con.Database.SqlQuery<string>("select AES_Encrypt('@FCC',  MD5('" + CVC_Encryption_SALT + "'))", new object[] { new ObjectParameter("FCC", _request.CVC) }).FirstOrDefault();
                    }
                }
            }


            if (_request.Charged_Amount > 0)
            {
                //Get Tax_Perc FROM Market
                _request.CallerId = _request.CallerId.Length > 3 ? _request.CallerId.Substring(0, 3) : _request.CallerId;
                int areadCode = 0;
                if (ExtensionMethods.IsNumeric(_request.CallerId))
                {
                    areadCode = Convert.ToInt32(_request.CallerId);
                }

                market _market = _context.markets.Where(x => x.AreaCode == areadCode).SingleOrDefault();
                if (_market != null)
                {
                    Tax_Perc_Amount = _market.Tax_Perc * Convert.ToDecimal(_request.Plan_Amount);
                }
                //Get Other Records FROM Payment_Plan_List

                payment_plan_list _payment_plan_list = _context.payment_plan_list.Where(x => x.Id == _request.Plan_Id).FirstOrDefault();
                if (_payment_plan_list != null)
                {
                    AppFee_Perc_Amount = decimal.Round(_payment_plan_list.ApplicableFee_Perc, 2);
                    AppFee_Static_Amount = decimal.Round(_payment_plan_list.ApplicableFee_Static, 2);
                }

            }
            _context.Configuration.ValidateOnSaveEnabled = false;
            paymentdetail _paymentdetail = new paymentdetail();
            _paymentdetail.Acc_Number = _request.Acc_Number;
            _paymentdetail.Grp_Id = Grp_id;
            _paymentdetail.RegistrationOn = (DateTime)_request.RegisteredDate;
            _paymentdetail.LastExpiry = (DateTime)_request.Old_Expiry;
            _paymentdetail.NewExpiry = (DateTime)_request.New_Expiry;
            _paymentdetail.PlanTakenID = _request.Plan_Id;
            _paymentdetail.FIRST_ONE_CC =
                 FIRST_ONE_CC;
            _paymentdetail.LAST_FOUR_CC = LAST_FOUR_CC;
            _paymentdetail.EXP_DATE = _request.CC_EXPDATE == null ? null : ((DateTime)_request.CC_EXPDATE).ToString("yyMM");
            _paymentdetail.FULL_CC_NUMBER = string.IsNullOrEmpty(_request.FULL_CC_NUMBER) ? "" : _request.FULL_CC_NUMBER; // MD5
            _paymentdetail.CVC = string.IsNullOrEmpty(_request.CVC) ? "" : _request.CVC; //MD5
            _paymentdetail.Amount = _request.Plan_Amount;
            _paymentdetail.Tax_Perc_Amount = Tax_Perc_Amount;
            _paymentdetail.AppFee_Static_Amount = AppFee_Static_Amount;
            _paymentdetail.AppFee_Perc_Amount = AppFee_Perc_Amount;
            _paymentdetail.packagevalidity = _request.Plan_Validity;
            _paymentdetail.MinInPackage = _request.Minutes_In_Package;
            _paymentdetail.Description = _request.Package_Description;
            _paymentdetail.ResponseCode = _request.Response_Code <= 0 ? (short)0 : _request.Response_Code;
            _paymentdetail.ResponseReasonCode = string.IsNullOrEmpty(_request.Response_Reason_Code) ? "0" : _request.Response_Reason_Code;
            _paymentdetail.ResponseText = string.IsNullOrEmpty(_request.Response_Reason_Text) ? " " : _request.Response_Reason_Text;
            _paymentdetail.ApprovalCode = string.IsNullOrEmpty(_request.Approval_Code) ? " " : _request.Approval_Code;
            _paymentdetail.AVSResultCode = string.IsNullOrEmpty(_request.AVS_Result_Code) ? " " : _request.AVS_Result_Code;
            _paymentdetail.TransactionID = string.IsNullOrEmpty(_request.Transaction_Id) ? " " : _request.Transaction_Id;
            _paymentdetail.registeredby = string.IsNullOrEmpty(_request.Payment_Type_Text) ? " " : _request.Payment_Type_Text;
            _paymentdetail.Source_Description = "Web Transaction";
            _paymentdetail.pd_callerid = "";
            _paymentdetail.Dnis = "";
            _paymentdetail.TollFree = "";
            _context.paymentdetails.Add(_paymentdetail);
            _context.SaveChanges();


            Add_To_Payment_Details_Response response = new Add_To_Payment_Details_Response();

            response.Acc_Number = _request.Acc_Number;
            return response;
        }

        public Validate_Response validate(Validate_Request _request)
        {
            Validate_Response response = null;
            string Grp_id = CommonRepositories.GetGroupID(_request.Group_Prefix);
            account ac = _context.accounts.Where(x => x.Acc_Number == _request.Acc_Number && x.PassCode == _request.PassCode && x.Grp_Id == Grp_id).FirstOrDefault();

            if (ac != null)
            {
                response = new Validate_Response() { Acc_Number = _request.Acc_Number };
            }
            return response;
        }

        public Update_Account_Response update_account(Update_Account_Request _request)
        {
            _context.Configuration.ValidateOnSaveEnabled = false;
            Update_Account_Response response = null;

            string Grp_id = CommonRepositories.GetGroupID(_request.Group_Prefix);

            account ac = _context.accounts.Where(x => x.Acc_Number == _request.Acc_Number && x.Grp_Id == Grp_id).FirstOrDefault();
            if (ac != null)
            {
                ac.callerid = string.IsNullOrEmpty(_request.CallerID) ? ac.callerid : _request.CallerID;
                ac.ExpiryDate = _request.New_Expiry == null ? ac.ExpiryDate : (DateTime)_request.New_Expiry;
                ac.AccountType = string.IsNullOrEmpty(_request.AccountType) ? ac.AccountType : _request.AccountType;
                ac.Active0In1 = string.IsNullOrEmpty(_request.Active0In1) ? ac.Active0In1 : _request.Active0In1;

                _context.SaveChanges();
                response = new Update_Account_Response() { Acc_Number = _request.Acc_Number };
            }



            return response;

        }

        public Process_Mobile_Charge_Response process_mobile_charge(Process_Mobile_Charge_Request _request)
        {
            Process_Mobile_Charge_Response response = null;

            string Grp_id = CommonRepositories.GetGroupID(_request.Group_Prefix);

            int p = (from l in _context.liveusers orderby l.Port select l.Port).FirstOrDefault();
            var l_Port = (from s in _context.serverdefns
                          where p > s.PortStart && p < s.PortStop
                          select s.PortStop + 1).FirstOrDefault(); ;
            if (l_Port <= 0)
            {
                l_Port = 1;
            }

            _context.Configuration.ValidateOnSaveEnabled = false;
            sms_queue_active _sms_Queue_Active = new sms_queue_active();

            _sms_Queue_Active.Acc_Number = _request.Acc_Number;
            _sms_Queue_Active.CarrierId = _request.CarrierId;
            _sms_Queue_Active.ChargeAmount = _request.ChargeAmount;
            _sms_Queue_Active.Grp_Id = Grp_id;
            _sms_Queue_Active.PassCode = _request.PassCode;
            _sms_Queue_Active.Port = l_Port;
            _sms_Queue_Active.SubscriberNo = _request.SubscriberNo;
            _sms_Queue_Active.Ticket_Id = _request.TicketId;
            _sms_Queue_Active.SMS_Id = _request.SMS_Id;
            _sms_Queue_Active.ChargeType = 1;
            _sms_Queue_Active.Job_Time = DateTime.Now;
            _sms_Queue_Active.Queue_Time = DateTime.Now;
            _sms_Queue_Active.NextRetryAt = DateTime.Now;
            _sms_Queue_Active.ProgramId = "0";
            _sms_Queue_Active.MessageSendAt = DateTime.Now;
            _sms_Queue_Active.OM0_M1 = 0;
            _sms_Queue_Active.ivr1sms2 = 2;
            _sms_Queue_Active.Q0A1S2F3 = 0;


            _context.sms_queue_active.Add(_sms_Queue_Active);
            _context.SaveChanges();
            response = new Process_Mobile_Charge_Response() { Acc_Number = _request.Acc_Number };

            return response;
        }

        public Update_Login_Log_Response update_login_log(Update_Login_Log_Request _request)
        {
            login_log lg = _context.login_log.Where(x => x.SessionNo == _request.Session).FirstOrDefault();

            if (lg != null)
            {
                lg.DateOut = _request.DateOut == null ? "" : ((DateTime)_request.DateOut).ToString("yyyy-MM-dd");
                lg.TimeOut = _request.TimeOut;
                lg.LastTimeStamp = _request.LastTimeStamp;

                _context.SaveChanges();

                return new Update_Login_Log_Response() { OK = "OK" };
            }

            return null;
        }

        public Insert_Login_Log_Response insert_login_log(Insert_Login_Log_Request _request)
        {
            Insert_Login_Log_Response response = new Insert_Login_Log_Response();

            login_log lg = new login_log();
            lg.IPAddress = _request.CC_IPAddress;
            lg.DateIn = _request.DateIn == null ? "" : ((DateTime)_request.DateIn).ToString("yyyy-MM-dd");
            lg.LastTimeStamp = _request.LastTimeStamp;
            lg.SessionNo = _request.Session;
            if (_request.TimeIn != null)
            {
                lg.TimeIn = _request.TimeIn.Value.ToString();
            }
            lg.Username = _request.CC_UserName;

            _context.login_log.Add(lg);
            _context.SaveChanges();

            response = new Insert_Login_Log_Response() { OK = "OK" };
            return response;
        }

        public Admin_Web_Screening_Response admin_web_screening(Admin_Web_Screening_Request _request, string path)
        {
            Admin_Web_Screening_Response response = null;

            string Grp_id = CommonRepositories.GetGroupID(_request.Group_Prefix);

            account ac = _context.accounts.Where(x => x.Acc_Number == _request.Acc_Number && x.Grp_Id == Grp_id).FirstOrDefault();
            if (ac != null)
            {
                // log

                string logText = "";
                if (_request.App1Del2 == 1)
                {
                    logText = "26," + _request.Acc_Number + ",111," + _request.Group_Prefix;
                }
                else if (_request.App1Del2 == 2)
                {
                    logText = "26," + _request.Acc_Number + ",222," + _request.Group_Prefix;
                }

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                File.AppendAllLines(path + "/" + "Admin_Web_Screening_" + String.Format("{0:MM-yyyy}.text", DateTime.UtcNow), new[] { logText });



                return new Admin_Web_Screening_Response() { OK = "OK" };
            }
            return response;
        }

        public Getchargeamount_Response getchargeamount(Getchargeamount_Request _request)
        {
            Getchargeamount_Response response = null;
            decimal Tax_Perc = 0;

            market m = _context.markets.Where(x => x.AreaCode == _request.Area_Code).FirstOrDefault();
            if (m != null)
            {
                Tax_Perc = m.Tax_Perc;
            }

            payment_plan_list p = _context.payment_plan_list.Where(x => x.Id == _request.Plan_Id).FirstOrDefault();
            if (p != null)
            {
                response = new Getchargeamount_Response();
                if (Tax_Perc > 0)
                {
                    response.Amount = ((decimal)p.Amount) * (1 + Tax_Perc + p.ApplicableFee_Perc) + p.ApplicableFee_Static;
                }
                else
                {
                    response.Amount = (decimal)p.Amount;
                }

                response.Amount = decimal.Round(response.Amount, 2);
            }

            return response;
        }

        public Delete_Completeaccount_Response delete_completeaccount(Delete_Completeaccount_Request _request)
        {
            _context.Configuration.ValidateOnSaveEnabled = false;
            Delete_Completeaccount_Response response = null;

            int ct = 0;
            string Grp_id = CommonRepositories.GetGroupID(_request.Group_Prefix);

            ct = _context.action_queue.Where(x => x.Acc_Number == _request.Acc_Number && x.Grp_Id == Grp_id && x.FuncTable_Name == "DELETE_CompleteAccount").Count();


            if (ct <= 0)
            {
                int p = (from l in _context.liveusers orderby l.Port select l.Port).FirstOrDefault();
                var Port = (from s in _context.serverdefns
                            where p > s.PortStart && p < s.PortStop
                            select s.PortStart).FirstOrDefault(); ;
                if (Port <= 0)
                {
                    Port = 1;
                }
                //INSERT INTO action_queue for maintenance to take care of it

                action_queue aq = new action_queue();
                aq.QDateTimeStamp = DateTime.Now;
                aq.Function1Table2 = "1";
                aq.FuncTable_Name = "DELETE_CompleteAccount";
                aq.Field_Name = "";
                aq.Acc_Number = _request.Acc_Number;
                aq.Grp_Id = Grp_id;
                aq.Port = Port;
                aq.WhereClause = "";
                aq.Action = "EXECUTE";
                aq.Q0A1S2F3 = "0";

                _context.action_queue.Add(aq);
                _context.SaveChanges();
                response = new Delete_Completeaccount_Response() { Message = "Delete account request queued." };
            }
            else
            {
                response = new Delete_Completeaccount_Response() { Message = "Request canceled|Duplicate delete account request - canceled." };
            }
            return response;
        }

        public Set_Misc_Response set_misc(Set_Misc_Request _request)
        {
            misc _misc = null;

            _misc = _context.miscs.Where(x => x.SettingName == _request.SettingName).FirstOrDefault();

            if (_misc == null)
            {
                return null;
            }
            else
            {

                _misc.SettingValue = _request.SettingValue;

                _context.SaveChanges();
                return new Set_Misc_Response() { Status = "Value updated." };

            }
        }

        public Set_Primary_Apiserver_Response set_primary_apiserver(Set_Primary_Apiserver_Request _request)
        {
            Set_Primary_Apiserver_Response response = null;

            int ct = _context.api_servers.Count();
            if (ct > 0)
            {
                api_servers aps = _context.api_servers.Where(x => x.ip_address == _request.ActiveServerIP).FirstOrDefault();

                if (aps != null)
                {
                    if (aps.ip_priority == 1)
                    {
                        response = new Set_Primary_Apiserver_Response() { Status = "API Server already set as Primary." };
                    }
                    else
                    {
                        long curr_ip_priority = aps.ip_priority;
                        aps.ip_priority = aps.ip_priority - (curr_ip_priority - 1);

                        if (aps.ip_priority <= 0)
                        {
                            aps.ip_priority = aps.ip_priority + ct;
                        }
                        _context.SaveChanges();

                        response = new Set_Primary_Apiserver_Response() { Status = "API Server set as Primary" };
                    }
                }
                else
                {
                    response = new Set_Primary_Apiserver_Response() { Status = "Requested Server IP not found." };
                }
            }

            return response;
        }

        public Read_Misc_Response read_misc(Read_Misc_Request _request)
        {
            Read_Misc_Response response = null;

            List<misc> _misc = _context.miscs.OrderBy(x => x.SettingName).Where(x => x.ForWeb == 1).ToList<misc>();

            List<string> str = new List<string>();
            foreach (misc m in _misc)
            {
                str.Add(m.SettingName + ":" + m.SettingValue);
            }

            response = new Read_Misc_Response() { Setting = string.Join("|", str) };
            return response;
        }
        string CC_Encryption_SALT = "O7#sAlpwQk^$*~";
        string CVC_Encryption_SALT = "*RcS!98/>nUp9";
        public Add_Complete_Paid_Account_Response add_complete_paid_account(Add_Complete_Paid_Account_Request _request)
        {
            _context.Configuration.ValidateOnSaveEnabled = false;
            Add_Complete_Paid_Account_Response response = null;
            string Grp_id = CommonRepositories.GetGroupID(_request.Group_Prefix);
            string FIRST_ONE_CC, LAST_FOUR_CC;
            if (!string.IsNullOrEmpty(_request.FULL_CC_NUMBER) && _request.FULL_CC_NUMBER.Length >= 1)
            {
                FIRST_ONE_CC = _request.FULL_CC_NUMBER.Substring(0, 1);
            }
            else
            {
                FIRST_ONE_CC = "";
            }
            if (!string.IsNullOrEmpty(_request.FULL_CC_NUMBER) && _request.FULL_CC_NUMBER.Length >= 4)
            {
                LAST_FOUR_CC = _request.FULL_CC_NUMBER.Substring(_request.FULL_CC_NUMBER.Length - 4, 4);
            }
            else
            {
                LAST_FOUR_CC = "";
            }

            decimal Tax_Perc_Amount = 0;
            decimal AppFee_Static_Amount = 0;
            decimal AppFee_Perc_Amount = 0;


            if (!string.IsNullOrEmpty(_request.FULL_CC_NUMBER) || !string.IsNullOrEmpty(_request.CVC))
            {
                using (var con = new ivrdating.Domain.ivrdating())
                {
                    if (!string.IsNullOrEmpty(_request.FULL_CC_NUMBER))
                    {
                        _request.FULL_CC_NUMBER = con.Database.SqlQuery<string>("select AES_Encrypt('@FCC',  MD5('" + CC_Encryption_SALT + "'))", new object[] { new ObjectParameter("FCC", _request.FULL_CC_NUMBER) }).FirstOrDefault();
                    }

                    if (!string.IsNullOrEmpty(_request.CVC))
                    {
                        _request.CVC = con.Database.SqlQuery<string>("select AES_Encrypt('@FCC',  MD5('" + CVC_Encryption_SALT + "'))", new object[] { new ObjectParameter("FCC", _request.CVC) }).FirstOrDefault();
                    }
                }
            }

            //CHECK IF ACCOUNT ALREADY EXISTS ( BASED ON CALLERID AND GROUP ACCOUNT MAY HAVE EXISTED )
            int l_AId = 0;

            account ac1 = _context.accounts.Where(x => x.Acc_Number == _request.Acc_Number && x.Grp_Id == Grp_id).FirstOrDefault();
            if (ac1 != null)
            {
                l_AId = ac1.Id;
            }
            if (l_AId == 0)
            {
                //Update accountids
                accountid db = _context.accountids.Where(x => x.Acc_Number == _request.Acc_Number).FirstOrDefault();

                if (db != null)
                {
                    foreach (var property in db.GetType().GetProperties())
                    {
                        if (property.Name == "Grp_Id" + Grp_id)
                        {
                            property.SetValue(db, "1", null);
                        }
                    }
                }
                bool newEntry = false;
                //Add to Account
                account ac = new account();
                ac.Acc_Number = _request.Acc_Number;
                ac.PassCode = _request.PassCode;
                ac.callerid = _request.CallerId;

                ac.RegisteredOn = (DateTime)_request.RegisteredDate;
                ac.ExpiryDate = (DateTime)_request.PlanExpiresOn;
                ac.AccountType = _request.AccountType;
                ac.Active0In1 = _request.Active0In1;
                ac.PassCode = _request.PassCode;

                ac.Grp_Id = Grp_id;
                ac.AccRegisteredOn = (DateTime)_request.RegisteredDate;
                ac.Gender = "1";
                ac.LookingFor = "2";
                ac.ScreenStatus_0N2D1S3Ok = "0";
                ac.AdminScreening_0Q1Ok = "0";
                ac.ProfileExists1 = "0";
                ac.Callout_Flag = "0";
                ac.Callout_No = "0";
                ac.Callout_Start = "00:00";
                ac.Callout_End = "00:00";
                ac.DeadAccount1 = "0";
                _context.accounts.Add(ac);
                _context.SaveChanges();
                //Add to Customer Master

                l_AId = _context.accounts.Where(x => x.Acc_Number == _request.Acc_Number && x.Grp_Id == Grp_id).FirstOrDefault().Id;

                customer_master csAdd = new customer_master();
                csAdd.Address = string.IsNullOrEmpty(_request.CustomerAddress) ? " " : _request.CustomerAddress;
                csAdd.AId = l_AId;
                csAdd.City = string.IsNullOrEmpty(_request.CustomerCity) ? " " : _request.CustomerCity;
                csAdd.Country = string.IsNullOrEmpty(_request.CustomerCountry) ? " " : _request.CustomerCountry.Length > 20 ? _request.CustomerCountry.Substring(20) : _request.CustomerCountry;
                csAdd.Email_Address = string.IsNullOrEmpty(_request.CustomerEmail_Address) ? " " : _request.CustomerEmail_Address;
                csAdd.First_Name = string.IsNullOrEmpty(_request.CustomerFirstName) ? " " : _request.CustomerFirstName;
                csAdd.Last_Name = string.IsNullOrEmpty(_request.CustomerLastName) ? " " : _request.CustomerLastName;
                csAdd.RegisteredOn = (DateTime)_request.RegisteredDate;
                csAdd.State_Name = string.IsNullOrEmpty(_request.CustomerState) ? " " : _request.CustomerState;
                csAdd.WebPassword = string.IsNullOrEmpty(_request.WebPassword) ? " " : _request.WebPassword;
                csAdd.WebUserName = string.IsNullOrEmpty(_request.WebUserName) ? " " : _request.WebUserName;
                csAdd.Zip_Code = string.IsNullOrEmpty(_request.CustomerZip_Code) ? " " : _request.CustomerZip_Code;

                _context.customer_master.Add(csAdd);
                _context.SaveChanges();


                //Add to User Minute
                user_minute um = null;
                um = _context.user_minute.Where(x => x.Acc_Number == _request.Acc_Number && x.Grp_Id == Grp_id).FirstOrDefault();
                if (um == null)
                {
                    newEntry = true;
                    um = new user_minute();
                }
                um.Acc_Number = _request.Acc_Number;
                um.R_Seconds = _request.Minutes_In_Package * 60;
                um.Grp_Id = Grp_id;
                um.CreateDateTimeStamp = _request.RegisteredDate;
                um.LastDateTimeStamp = _request.RegisteredDate;

                if (newEntry)
                {
                    _context.user_minute.Add(um);
                }
                _context.SaveChanges();



                ///Add to Service Source
                servicesource sc = new servicesource();

                sc.Acc_Number = _request.Acc_Number;
                sc.AreaCode = _request.Area_Code;
                sc.Grp_Id = Grp_id;
                sc.OnDate = (DateTime)_request.RegisteredDate;
                sc.Source = _request.Service_Source;

                _context.servicesources.Add(sc);
                _context.SaveChanges();


                //Remove from acc_number_web TABLE

                acc_number_web acw = _context.acc_number_web.Where(x => x.Acc_Number == _request.Acc_Number && x.Grp_Id == Grp_id).FirstOrDefault();
                if (acw != null)
                {
                    _context.acc_number_web.Remove(acw);
                    _context.SaveChanges();
                }
            }
            else
            {
                //UPDATE Account
                ac1.AccountType = _request.AccountType;
                ac1.ExpiryDate = (DateTime)_request.PlanExpiresOn;

                //Update to User Minute
                user_minute um = _context.user_minute.Where(x => x.Acc_Number == _request.Acc_Number && x.Grp_Id == Grp_id).FirstOrDefault();
                if (um != null)
                {
                    um.R_Seconds = um.R_Seconds + _request.Minutes_In_Package * 60;
                }
                _context.SaveChanges();

            }

            //If Charged_Amount is defined - calculate the Tax Component

            if (_request.Charged_Amount > 0)
            {
                //Get Tax_Perc FROM Market
                _request.CallerId = _request.CallerId.Length > 3 ? _request.CallerId.Substring(0, 3) : _request.CallerId;
                int areadCode = 0;
                if (ExtensionMethods.IsNumeric(_request.CallerId))
                {
                    areadCode = Convert.ToInt32(_request.CallerId);
                }

                market _market = _context.markets.Where(x => x.AreaCode == areadCode).SingleOrDefault();
                if (_market != null)
                {
                    Tax_Perc_Amount = _market.Tax_Perc * _request.Plan_Amount;
                }
                //Get Other Records FROM Payment_Plan_List

                payment_plan_list _payment_plan_list = _context.payment_plan_list.Where(x => x.Id == _request.Plan_Id).FirstOrDefault();
                if (_payment_plan_list != null)
                {
                    AppFee_Perc_Amount = _payment_plan_list.ApplicableFee_Perc;
                    AppFee_Static_Amount = _payment_plan_list.ApplicableFee_Static;
                }
            }

            paymentdetail _paymentdetail = new paymentdetail();
            _paymentdetail.Acc_Number = _request.Acc_Number;
            _paymentdetail.Grp_Id = Grp_id;
            _paymentdetail.RegistrationOn = (DateTime)_request.RegisteredDate;
            _paymentdetail.LastExpiry = (DateTime)_request.Old_Expiry;
            _paymentdetail.NewExpiry = (DateTime)_request.New_Expiry;
            _paymentdetail.PlanTakenID = _request.Plan_Id;
            _paymentdetail.FIRST_ONE_CC =
                 FIRST_ONE_CC;
            _paymentdetail.LAST_FOUR_CC = LAST_FOUR_CC;
            _paymentdetail.EXP_DATE = _request.CC_EXPDATE == null ? null : ((DateTime)_request.CC_EXPDATE).ToString("MMyy");
            _paymentdetail.FULL_CC_NUMBER = string.IsNullOrEmpty(_request.FULL_CC_NUMBER) ? "" : _request.FULL_CC_NUMBER; // MD5
            _paymentdetail.CVC = string.IsNullOrEmpty(_request.CVC) ? "" : _request.CVC; //MD5
            _paymentdetail.Amount = _request.Plan_Amount.ToString();
            _paymentdetail.Tax_Perc_Amount = Tax_Perc_Amount;
            _paymentdetail.AppFee_Static_Amount = AppFee_Static_Amount;
            _paymentdetail.AppFee_Perc_Amount = AppFee_Perc_Amount;
            _paymentdetail.packagevalidity = _request.Plan_Validity;
            _paymentdetail.MinInPackage = _request.Minutes_In_Package;
            _paymentdetail.Description = _request.Package_Description;
            _paymentdetail.ResponseCode = _request.Response_Code <= 0 ? (short)0 : _request.Response_Code;
            _paymentdetail.ResponseReasonCode = string.IsNullOrEmpty(_request.Response_Reason_Code) ? "0" : _request.Response_Reason_Code;
            _paymentdetail.ResponseText = string.IsNullOrEmpty(_request.Response_Reason_Text) ? " " : _request.Response_Reason_Text;
            _paymentdetail.ApprovalCode = string.IsNullOrEmpty(_request.Approval_Code) ? " " : _request.Approval_Code;
            _paymentdetail.AVSResultCode = string.IsNullOrEmpty(_request.AVS_Result_Code) ? " " : _request.AVS_Result_Code;
            _paymentdetail.TransactionID = string.IsNullOrEmpty(_request.Transaction_Id.ToString()) ? " " : _request.Transaction_Id.ToString();
            _paymentdetail.registeredby = string.IsNullOrEmpty(_request.Payment_Type_Text) ? " " : _request.Payment_Type_Text;
            _paymentdetail.ZipCode = string.IsNullOrEmpty(_request.CustomerZip_Code) ? "" : _request.CustomerZip_Code;
            _paymentdetail.Source_Description = "Web Transaction";
            _paymentdetail.pd_callerid = "";
            _paymentdetail.Dnis = "";
            _paymentdetail.TollFree = "";
            _context.paymentdetails.Add(_paymentdetail);
            _context.SaveChanges();

            response = new Add_Complete_Paid_Account_Response() { Acc_Number = _request.Acc_Number };

            return response;
        }

        public Modify_Customer_Info_Response modify_customer_info(Modify_Customer_Info_Request _request)
        {
            string Grp_id = CommonRepositories.GetGroupID(_request.Group_Prefix);
            _context.Configuration.ValidateOnSaveEnabled = false;
            if ((_request.PassCode == "-1") && (_request.CallerId == "-1"))
            {
                int l_AId = 0;
                string l_Passcode = "";

                account acc = _context.accounts.Where(x => x.Acc_Number == _request.Acc_Number && x.Grp_Id == Grp_id).FirstOrDefault();

                if (acc != null)
                {
                    l_AId = acc.Id;
                    l_Passcode = acc.PassCode;

                    customer_master cs = _context.customer_master.Where(x => x.AId == l_AId).FirstOrDefault();
                    if (cs != null)
                    {
                        cs.WebPassword = l_Passcode;
                        _context.SaveChanges();
                        using (var con = new ivrdating.Domain.ivrdating())
                        {
                            int rs = con.Database.ExecuteSqlCommand("update customer_master set ModifiedOn = @mod where AId = @id", new object[] { new MySqlParameter("@mod", DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss")), new MySqlParameter("@id", l_AId) });
                        }
                    }
                }
                else
                {
                    return null;
                }

            }
            else if ((_request.PassCode == "-1") && (_request.WebPassword == "-1"))
            {
                account acc = _context.accounts.Where(x => x.Acc_Number == _request.Acc_Number && x.Grp_Id == Grp_id).FirstOrDefault();

                if (acc != null)
                {
                    acc.callerid = _request.CallerId;
                    _context.SaveChanges();
                }
                else
                {
                    return null;
                }
            }
            else if ((_request.CallerId == "-1") && (_request.WebPassword == "-1"))
            {
                int l_AId = 0;
                string l_Passcode = "";

                account acc = _context.accounts.Where(x => x.Acc_Number == _request.Acc_Number && x.Grp_Id == Grp_id).FirstOrDefault();

                if (acc != null)
                {
                    bool saveChanges = false;
                    l_AId = acc.Id;
                    l_Passcode = acc.PassCode;
                    acc.PassCode = _request.PassCode;
                    customer_master cs = _context.customer_master.Where(x => x.AId == l_AId).FirstOrDefault();
                    if (cs != null)
                    {
                        cs.WebPassword = l_Passcode;
                        _context.SaveChanges();
                        saveChanges = true;
                        using (var con = new ivrdating.Domain.ivrdating())
                        {
                            int rs = con.Database.ExecuteSqlCommand("update customer_master set ModifiedOn = @mod where AId = @id", new object[] { new MySqlParameter("@mod", DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss")), new MySqlParameter("@id", l_AId) });
                        }
                    }
                    if (!saveChanges)
                    {
                        _context.SaveChanges();
                    }
                }
                else
                {
                    return null;
                }
            }

            return new Modify_Customer_Info_Response() { Acc_Number = _request.Acc_Number };
        }

        public Add_New_Account_Response Add_New_Account(Add_New_Account_Request _request)
        {


            _context.Configuration.ValidateOnSaveEnabled = false;
            Add_New_Account_Response response = null;
            string Grp_id = CommonRepositories.GetGroupID(_request.Group_Prefix);

            if (_context.accounts.Where(x => x.Acc_Number == _request.Acc_Number && x.Grp_Id == Grp_id).FirstOrDefault() != null)
            {
                return response;
            }

            account ac = new account();
            ac.Acc_Number = _request.Acc_Number;
            ac.PassCode = _request.PassCode;
            ac.callerid = _request.CallerId;
            ac.AccRegisteredOn = (DateTime)_request.RegisteredDate;
            ac.RegisteredOn = (DateTime)_request.RegisteredDate;
            ac.ExpiryDate = (DateTime)_request.PlanExpiresOn;
            ac.AccountType = _request.AccountType;
            ac.Active0In1 = _request.Active0In1;
            ac.PassCode = _request.PassCode;

            ac.Grp_Id = Grp_id;

            ac.Gender = "1";
            ac.LookingFor = "2";
            ac.ScreenStatus_0N2D1S3Ok = "0";
            ac.AdminScreening_0Q1Ok = "0";
            ac.ProfileExists1 = "0";
            ac.Callout_Flag = "0";
            ac.Callout_No = "0";
            ac.Callout_Start = "00:00";
            ac.Callout_End = "00:00";

            ac.DeadAccount1 = "0";
            //ac.LastGreetingRecordedOn = new DateTime(0, 0, 0, 0, 0, 0);
            //ac.LastLogon = new DateTime(0, 0, 0, 0, 0, 0);

            _context.accounts.Add(ac);

            mobile_carrier_account moac = new mobile_carrier_account();
            moac.Acc_Number = _request.Acc_Number;
            moac.PassCode = _request.PassCode;
            moac.Ani = _request.CallerId;
            moac.Grp_Id = Grp_id;
            moac.RegisteredOn = (DateTime)_request.RegisteredDate;
            moac.ExpiryDate = (DateTime)_request.PlanExpiresOn;
            //moac.LastCalledOn = new DateTime(0, 0, 0, 0, 0, 0);

            _context.mobile_carrier_account.Add(moac);
            try
            {
                _context.SaveChanges();

                response = new Add_New_Account_Response() { Acc_Number = ac.Acc_Number };
            }

            catch { }
            return response;
        }

        public Deactivate_Acc_Number_Response Deactivate_Acc_Number(Deactivate_Acc_Number_Request _request)
        {
            Deactivate_Acc_Number_Response response = null;

            string Grp_id = CommonRepositories.GetGroupID(_request.Group_Prefix);

            accountid db = _context.accountids.Where(x => x.Acc_Number == _request.Acc_Number).FirstOrDefault();



            if (db != null)
            {
                foreach (var property in db.GetType().GetProperties())
                {
                    if (property.Name == "Grp_Id" + Grp_id)
                    {
                        property.SetValue(db, "0", null);
                    }
                }

                //Check whether link to an active account, do not deactivate if valid account exists

                var acc = _context.accounts.Where(x => x.Acc_Number == _request.Acc_Number && x.Grp_Id == Grp_id);
                if (acc == null)
                {
                    _context.SaveChanges();
                }
            }

            acc_number_web acweb = _context.acc_number_web.Where(x => x.Acc_Number == _request.Acc_Number && x.Grp_Id == Grp_id).FirstOrDefault();

            if (acweb != null)
            {
                _context.acc_number_web.Remove(acweb);
                _context.SaveChanges();
            }

            response = new Deactivate_Acc_Number_Response() { Acc_Number = _request.Acc_Number };

            return response;
        }

        private static void MinMax(ref int min, ref int max, List<GetAccountIdsEnum> ss)
        {
            foreach (GetAccountIdsEnum ac in ss)
            {
                if (ac.Grp_Id == "0")
                {
                    if (ac.Id < min)
                    {
                        min = ac.Id;
                    }
                    if (ac.Id > max)
                    {
                        max = ac.Id;
                    }
                }
            }
        }

        public Get_N_Activate_New_Acc_Number_Response Get_N_Activate_New_Acc_Number(Get_N_Activate_New_Acc_Number_Request _request)
        {
            var data = this.Get_New_Acc_Number(new Get_New_Acc_Number_Request() { AuthKey = _request.AuthKey, Group_Prefix = _request.Group_Prefix, WS_Password = _request.WS_Password, WS_UserName = _request.WS_UserName });
            string Grp_id = CommonRepositories.GetGroupID(_request.Group_Prefix);
            if (data == null)
            {
                return null;
            }
            else
            {
                //ivrdating.Domain.ivrdating d = new Domain.ivrdating();
                accountid acids = _context.accountids.Where(x => x.Acc_Number == data.Acc_Number).FirstOrDefault();
                if (acids != null)
                {
                    switch (Grp_id)
                    {

                        case "1": acids.Grp_Id1 = "1"; break;
                        case "2": acids.Grp_Id2 = "1"; break;
                        case "3": acids.Grp_Id3 = "1"; break;
                        case "4": acids.Grp_Id4 = "1"; break;
                        case "5": acids.Grp_Id5 = "1"; break;
                        case "6": acids.Grp_Id6 = "1"; break;
                        case "7": acids.Grp_Id7 = "1"; break;
                        case "8": acids.Grp_Id8 = "1"; break;
                        case "9": acids.Grp_Id9 = "1"; break;
                    }
                    _context.SaveChanges();
                }


                return new Get_N_Activate_New_Acc_Number_Response() { Acc_Number = data.Acc_Number, PassCode = data.PassCode };
            }
        }


        public Activate_Acc_Number_Response Activate_Acc_Numbe(Activate_Acc_Number_Request _request)
        {
            Activate_Acc_Number_Response response = null;
            string Grp_id = CommonRepositories.GetGroupID(_request.Group_Prefix);

            accountid db = _context.accountids.Where(x => x.Acc_Number == _request.Acc_Number).FirstOrDefault();

            if (db != null)
            {
                foreach (var property in db.GetType().GetProperties())
                {
                    if (property.Name == "Grp_Id" + Grp_id)
                    {
                        property.SetValue(db, "1", null);
                    }
                }
                _context.SaveChanges();

                response = new Activate_Acc_Number_Response() { Acc_Number = _request.Acc_Number };
                acc_number_web acweb = new acc_number_web();
                acweb.Acc_Number = _request.Acc_Number;
                acweb.AllocatedOn = DateTime.Now;
                acweb.Subscriber_Mobile = "1";
                acweb.Grp_Id = Grp_id;

                _context.acc_number_web.Add(acweb);
                try
                {
                    _context.SaveChanges();
                }
                catch { }
            }
            return response;
        }

    }
}
