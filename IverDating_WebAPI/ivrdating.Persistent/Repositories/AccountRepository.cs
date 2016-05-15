using ivrdating.Domain;
using ivrdating.Domain.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Persistent.Repositories
{
    public class AccountRepository
    {
        ivrdating.Domain.ivrdating _context;
        public AccountRepository()
        {
            _context = new ivrdating.Domain.ivrdating();
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
            if (_request.FULL_CC_NUMBER.Length >= 1)
            {
                FIRST_ONE_CC = _request.FULL_CC_NUMBER.Substring(0, 1);
            }
            else
            {
                FIRST_ONE_CC = "";
            }
            if (_request.FULL_CC_NUMBER.Length >= 4)
            {
                LAST_FOUR_CC = _request.FULL_CC_NUMBER.Substring(_request.FULL_CC_NUMBER.Length - 5, 4);
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

            if (_request.Charged_Amount > 0)
            {
                //Get Tax_Perc FROM Market
                market _market = _context.markets.Where(x => x.AreaCode == Convert.ToInt32(_request.CallerId.Substring(0, 3))).SingleOrDefault();
                if (_market != null)
                {
                    Tax_Perc_Amount = _market.Tax_Perc * Convert.ToInt32(_request.Plan_Amount);
                }
                //Get Other Records FROM Payment_Plan_List

                payment_plan_list _payment_plan_list = _context.payment_plan_list.Where(x => x.Id == _request.Plan_Id).FirstOrDefault();
                if (_payment_plan_list != null)
                {
                    AppFee_Perc_Amount = _payment_plan_list.ApplicableFee_Perc * Convert.ToInt32(_request.Plan_Amount);
                    AppFee_Static_Amount = _payment_plan_list.ApplicableFee_Static * Convert.ToInt32(_request.Plan_Amount);
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
            _paymentdetail.EXP_DATE = _request.CC_EXPDATE;
            _paymentdetail.FULL_CC_NUMBER = ExtensionMethods.GetMd5Hash(_request.FULL_CC_NUMBER); // MD5
            _paymentdetail.CVC = ExtensionMethods.GetMd5Hash(_request.CVC); //MD5
            _paymentdetail.Amount = _request.Plan_Amount;
            _paymentdetail.Tax_Perc_Amount = Tax_Perc_Amount;
            _paymentdetail.AppFee_Static_Amount = AppFee_Static_Amount;
            _paymentdetail.AppFee_Perc_Amount = AppFee_Perc_Amount;
            _paymentdetail.packagevalidity = _request.Plan_Validity;
            _paymentdetail.MinInPackage = _request.Minutes_In_Package;
            _paymentdetail.Description = _request.Package_Description;
            _paymentdetail.ResponseCode = _request.Response_Code;
            _paymentdetail.ResponseReasonCode = _request.Response_Reason_Code;
            _paymentdetail.ResponseText = _request.Response_Reason_Text;
            _paymentdetail.ApprovalCode = _request.Approval_Code;
            _paymentdetail.AVSResultCode = _request.AVS_Result_Code;
            _paymentdetail.TransactionID = _request.Transaction_Id;
            _paymentdetail.registeredby = _request.Payment_Type_Text;
            _paymentdetail.Source_Description = "Web Transaction";

            _context.paymentdetails.Add(_paymentdetail);
            _context.SaveChanges();


            Add_To_Payment_Details_Response response = new Add_To_Payment_Details_Response();

            response.Acc_Number = _request.Acc_Number;
            return response;
        }

        public Validate_Response validate(Validate_Request _request)
        {
            Validate_Response response = null;

            account ac = _context.accounts.Where(x => x.Acc_Number == _request.Acc_Number && x.PassCode == _request.PassCode).FirstOrDefault();

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

        public Add_New_Account_Response Add_New_Account(Add_New_Account_Request _request)
        {
            Add_New_Account_Response response = null;
            string Grp_id = CommonRepositories.GetGroupID(_request.Group_Prefix);

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

            ac.Gender = "2";
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

            response = new Add_New_Account_Response() { Acc_Number = ac.Acc_Number };
            return response;
        }

        public Deactivate_Acc_Number_Response Deactivate_Acc_Number(Deactivate_Acc_Number_Request _request)
        {
            Deactivate_Acc_Number_Response response = null;

            string Grp_id = CommonRepositories.GetGroupID(_request.Group_Prefix);

            accountid db = _context.accountids.Where(x => x.Acc_Number == _request.Acc_Number).FirstOrDefault();


            foreach (var property in db.GetType().GetProperties())
            {
                if (property.Name == "Grp_Id" + Grp_id)
                {
                    property.SetValue(db, "0", null);
                }
            }
            if (db != null)
            {

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
                ivrdating.Domain.ivrdating d = new Domain.ivrdating();
                accountid acids = d.accountids.Single(x => x.Acc_Number == data.Acc_Number);

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
                d.SaveChanges();


                return new Get_N_Activate_New_Acc_Number_Response() { Acc_Number = data.Acc_Number, PassCode = data.PassCode };
            }
        }


        public Activate_Acc_Number_Response Activate_Acc_Numbe(Activate_Acc_Number_Request _request)
        {
            Activate_Acc_Number_Response response = null;
            string Grp_id = CommonRepositories.GetGroupID(_request.Group_Prefix);

            accountid db = _context.accountids.Where(x => x.Acc_Number == _request.Acc_Number).FirstOrDefault();


            foreach (var property in db.GetType().GetProperties())
            {
                if (property.Name == "Grp_Id" + Grp_id)
                {
                    property.SetValue(db, "1", null);
                }
            }
            if (db != null)
            {
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
