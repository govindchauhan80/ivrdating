using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ivrdating.Domain;
using ivrdating.Logic.Services;
using ivrdating.Models;
using ivrdating.Domain.VM;
using ivrdating.Logic.Helpers;
using ivrdating.Web.Filter;
using System.Configuration;

namespace ivrdating.Web.Controllers
{
    [LogActionFilter]
    [LogExceptionFilter]
    public class WebServiceController : ApiController
    {
        #region Global members
        AccountService _accountService;
        MemberService _memberService;
        CustomerService _customerService;
        UserService _userService;
        #endregion Global members

        public WebServiceController()
        {
            _accountService = new AccountService();
            _memberService = new MemberService();
            _customerService = new CustomerService();
            _userService = new UserService();
        }

        //[Route("api/webservices/get_accounts")]
        //[HttpGet]
        //public IHttpActionResult get_accounts()
        //{
        //    return Ok(_accountService.GetAll());
        //}
        #region 1  get_member_details
        [Route("api/webservices/get_member_details")]
        [HttpPost]
        public IHttpActionResult get_member_details(GetMemberDetailsRequest _Request, string output = null)
        {
            ReturnData vm = _memberService.GetMemberDetails(_Request);
            return GetMemberDetail(output, vm);
        }

        [Route("api/webservices/get_member_details")]
        [HttpGet]
        public IHttpActionResult get_member_details(string AuthKey, string WS_UserName, string WS_Password, string Group_Prefix, int Acc_Number, string CustomerEmail_Address = null, string PassCode = null, string CallerId = null, string output = null)
        {
            ReturnData vm = _memberService.GetMemberDetails(new GetMemberDetailsRequest() { Acc_Number = Acc_Number, AuthKey = AuthKey, CallerId = CallerId, CustomerEmail_Address = CustomerEmail_Address, Group_Prefix = Group_Prefix, PassCode = PassCode, WS_Password = WS_Password, WS_UserName = WS_UserName });
            return GetMemberDetail(output, vm);
        }

        [NonAction]
        private IHttpActionResult GetMemberDetail(string output, ReturnData vm)
        {

            if (string.Equals(output, "text", StringComparison.OrdinalIgnoreCase))
            {
                //return Ok(Helper.ExtensionMethods.SerializeToPlainText(typeof(MemberDetailVM).GetProperties().ToList(), vm.WsResult));
                return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(GetMemberDetailsResponse).GetProperties().ToList(), vm.WsResult), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "csv", StringComparison.OrdinalIgnoreCase))
            {
                // return Ok(CsvSerializer.SerializeToCsv(new List<MemberDetailVM> { vm.WsResult }));
                //return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm.WsResult), Configuration.Formatters.JsonFormatter);

                if (vm.WsResult != null)
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm.WsResult), Configuration.Formatters.JsonFormatter);
                else
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "json", StringComparison.OrdinalIgnoreCase))
            {
                //return Json(vm);
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "xml", StringComparison.OrdinalIgnoreCase))
            {
                //return Ok(XmlSerializer.SerializeToString(vm.WsResult));
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.XmlFormatter);
            }
            else
            {
                return Ok(vm);
            }
        }

        #endregion  get_member_details

        #region 2 member_forgot_passcode

        [Route("api/webservices/member_forgot_passcode")]
        [HttpPost]
        public IHttpActionResult member_forgot_passcode(Member_Forgot_Passcode_Request _Request, string output = null)
        {
            Member_Forgot_Passcode_Return vm = _memberService.member_forgot_passcode(_Request);
            return FN_Member_Forgot_Passcode(vm, output);
        }

        [Route("api/webservices/member_forgot_passcode")]
        [HttpGet]
        public IHttpActionResult member_forgot_passcode(string AuthKey, string WS_UserName, string WS_Password, string Group_Prefix, int Acc_Number, string CustomerEmail_Address = null, string PassCode = null, string CallerId = null, string output = null)
        {
            Member_Forgot_Passcode_Return vm = _memberService.member_forgot_passcode(new Member_Forgot_Passcode_Request() { Acc_Number = Acc_Number, AuthKey = AuthKey, CallerId = CallerId, CustomerEmail_Address = CustomerEmail_Address, Group_Prefix = Group_Prefix, PassCode = PassCode, WS_Password = WS_Password, WS_UserName = WS_UserName });
            return FN_Member_Forgot_Passcode(vm, output);
        }

        [NonAction]
        private IHttpActionResult FN_Member_Forgot_Passcode(Member_Forgot_Passcode_Return vm, string output)
        {
            if (string.Equals(output, "text", StringComparison.OrdinalIgnoreCase))
            {
                //return Ok(Helper.ExtensionMethods.SerializeToPlainText(typeof(MemberDetailVM).GetProperties().ToList(), vm.WsResult));
                if (vm.WsResult != null)
                {
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Member_Forgot_Passcode_Response).GetProperties().ToList(), vm.WsResult), Configuration.Formatters.JsonFormatter);
                }
                return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Member_Forgot_Passcode_Return).GetProperties().ToList(), vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "csv", StringComparison.OrdinalIgnoreCase))
            {
                // return Ok(CsvSerializer.SerializeToCsv(new List<MemberDetailVM> { vm.WsResult }));
                if (vm.WsResult != null)
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm.WsResult), Configuration.Formatters.JsonFormatter);
                else
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm), Configuration.Formatters.JsonFormatter);


            }
            else if (string.Equals(output, "json", StringComparison.OrdinalIgnoreCase))
            {
                //return Json(vm);
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "xml", StringComparison.OrdinalIgnoreCase))
            {
                //return Ok(XmlSerializer.SerializeToString(vm.WsResult));
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.XmlFormatter);
            }
            else
            {
                return Ok(vm);
            }
        }
        #endregion member_forgot_passcode

        #region 3 Get_New_Acc_Number
        /// <summary>
        /// Acc_Number	= "0"
        /// </summary>
        /// <returns></returns>
        [Route("api/webservices/Get_New_Acc_Number")]
        [HttpPost]
        public IHttpActionResult Get_New_Acc_Number(Get_New_Acc_Number_Request _request, string output = null)
        {
            var data = _accountService.Get_New_Acc_Number(_request);
            return FN_Get_New_Acc_Number(data, output);

        }
        [Route("api/webservices/Get_New_Acc_Number")]
        [HttpGet]
        public IHttpActionResult Get_New_Acc_Number(string AuthKey, string WS_UserName, string WS_Password, string Group_Prefix, string CallerId = null, string output = null)
        {
            var data = _accountService.Get_New_Acc_Number(new Get_New_Acc_Number_Request() { AuthKey = AuthKey, CallerId = CallerId, Group_Prefix = Group_Prefix, WS_Password = WS_Password, WS_UserName = WS_UserName });
            return FN_Get_New_Acc_Number(data, output);

        }

        [NonAction]
        private IHttpActionResult FN_Get_New_Acc_Number(Get_New_Acc_Number_Return vm, string output)
        {
            if (string.Equals(output, "text", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Get_New_Acc_Number_Response).GetProperties().ToList(), vm.WsResult), Configuration.Formatters.JsonFormatter);
                return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Get_New_Acc_Number_Return).GetProperties().ToList(), vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "csv", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm.WsResult), Configuration.Formatters.JsonFormatter);
                else
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "json", StringComparison.OrdinalIgnoreCase))
            {
                //return Json(vm);
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "xml", StringComparison.OrdinalIgnoreCase))
            {
                //return Ok(XmlSerializer.SerializeToString(vm.WsResult));
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.XmlFormatter);
            }
            else
            {
                return Ok(vm);
            }
        }
        #endregion Get_New_Acc_Number

        #region 4 get_n_activate_new_acc_number
        [Route("api/webservices/get_n_activate_new_acc_number")]
        [HttpPost]
        public IHttpActionResult get_n_activate_new_acc_number(Get_N_Activate_New_Acc_Number_Request _request, string output = null)
        {
            var data = _accountService.Get_N_Activate_New_Acc_Number(_request);
            return FN_Get_N_Activate_New_Acc_Number(data, output);
        }

        [Route("api/webservices/get_n_activate_new_acc_number")]
        [HttpGet]
        public IHttpActionResult get_n_activate_new_acc_number(string AuthKey, string WS_UserName, string WS_Password, string Group_Prefix, string output = null)
        {
            var data = _accountService.Get_N_Activate_New_Acc_Number(new Get_N_Activate_New_Acc_Number_Request() { AuthKey = AuthKey, Group_Prefix = Group_Prefix, WS_Password = WS_Password, WS_UserName = WS_UserName });
            return FN_Get_N_Activate_New_Acc_Number(data, output);
        }

        [NonAction]
        private IHttpActionResult FN_Get_N_Activate_New_Acc_Number(Get_N_Activate_New_Acc_Number_Return vm, string output)
        {
            if (string.Equals(output, "text", StringComparison.OrdinalIgnoreCase))
            {
                //return Ok(Helper.ExtensionMethods.SerializeToPlainText(typeof(MemberDetailVM).GetProperties().ToList(), vm.WsResult));
                return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Get_N_Activate_New_Acc_Number_Return).GetProperties().ToList(), vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "csv", StringComparison.OrdinalIgnoreCase))
            {
                // return Ok(CsvSerializer.SerializeToCsv(new List<MemberDetailVM> { vm.WsResult }));
                if (vm.WsResult != null)
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm.WsResult), Configuration.Formatters.JsonFormatter);
                else
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "json", StringComparison.OrdinalIgnoreCase))
            {
                //return Json(vm);
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "xml", StringComparison.OrdinalIgnoreCase))
            {
                //return Ok(XmlSerializer.SerializeToString(vm.WsResult));
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.XmlFormatter);
            }
            else
            {
                return Ok(vm);
            }
        }
        #endregion get_n_activate_new_acc_number

        #region 5 activate_acc_number 

        [Route("api/webservices/activate_acc_number")]
        [HttpPost]
        public IHttpActionResult activate_acc_number(Activate_Acc_Number_Request _request, string output = null)
        {
            var data = _accountService.Activate_Acc_Numbe(_request);
            return FN_Activate_Acc_Number(data, output);
        }

        [Route("api/webservices/activate_acc_number")]
        [HttpGet]
        public IHttpActionResult activate_acc_number(string AuthKey, string WS_UserName, string WS_Password, string Group_Prefix, int Acc_Number, string output = null)
        {
            var data = _accountService.Activate_Acc_Numbe(new Activate_Acc_Number_Request() { AuthKey = AuthKey, Group_Prefix = Group_Prefix, WS_Password = WS_Password, WS_UserName = WS_UserName, Acc_Number = Acc_Number });
            return FN_Activate_Acc_Number(data, output);
        }

        [NonAction]
        private IHttpActionResult FN_Activate_Acc_Number(Activate_Acc_Number_Return vm, string output)
        {
            if (string.Equals(output, "text", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                {
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Activate_Acc_Number_Response).GetProperties().ToList(), vm.WsResult), Configuration.Formatters.JsonFormatter);
                }
                return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Activate_Acc_Number_Return).GetProperties().ToList(), vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "csv", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm.WsResult), Configuration.Formatters.JsonFormatter);
                else
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "json", StringComparison.OrdinalIgnoreCase))
            {
                //return Json(vm);
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "xml", StringComparison.OrdinalIgnoreCase))
            {
                //return Ok(XmlSerializer.SerializeToString(vm.WsResult));
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.XmlFormatter);
            }
            else
            {
                return Ok(vm);
            }
        }

        #endregion activate_acc_number

        #region 6 deactivate_acc_number 


        [Route("api/webservices/deactivate_acc_number")]
        [HttpPost]
        public IHttpActionResult deactivate_acc_number(Deactivate_Acc_Number_Request _request, string output = null)
        {
            var data = _accountService.Deactivate_Acc_Number(_request);
            return FN_Deactivate_Acc_Number(data, output);
        }

        [Route("api/webservices/deactivate_acc_number")]
        [HttpGet]
        public IHttpActionResult deactivate_acc_number(string AuthKey, string WS_UserName, string WS_Password, string Group_Prefix, int Acc_Number, string output = null)
        {
            var data = _accountService.Deactivate_Acc_Number(new Deactivate_Acc_Number_Request() { AuthKey = AuthKey, Group_Prefix = Group_Prefix, WS_Password = WS_Password, WS_UserName = WS_UserName, Acc_Number = Acc_Number });
            return FN_Deactivate_Acc_Number(data, output);
        }

        [NonAction]
        private IHttpActionResult FN_Deactivate_Acc_Number(Deactivate_Acc_Number_Return vm, string output)
        {
            if (string.Equals(output, "text", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                {
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Deactivate_Acc_Number_Response).GetProperties().ToList(), vm.WsResult), Configuration.Formatters.JsonFormatter);
                }
                return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Deactivate_Acc_Number_Return).GetProperties().ToList(), vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "csv", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm.WsResult), Configuration.Formatters.JsonFormatter);
                else
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "json", StringComparison.OrdinalIgnoreCase))
            {
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "xml", StringComparison.OrdinalIgnoreCase))
            {
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.XmlFormatter);
            }
            else
            {
                return Ok(vm);
            }
        }
        #endregion deactivate_acc_number

        #region 7 add_new_account 

        [Route("api/webservices/add_new_account")]
        [HttpPost]
        public IHttpActionResult add_new_account(Add_New_Account_Request _request, string output = null)
        {
            var data = _accountService.Add_New_Account(_request);
            return FN_Add_New_Account(data, output);
        }

        [Route("api/webservices/add_new_account")]
        [HttpGet]
        public IHttpActionResult add_new_account(string AuthKey, string WS_UserName, string WS_Password, string Group_Prefix, int Acc_Number, string PassCode, DateTime? RegisteredDate, DateTime? PlanExpiresOn, string AccountType, string Active0In1 = null, string CallerId = null, string output = null)
        {
            var data = _accountService.Add_New_Account(new Add_New_Account_Request() { AuthKey = AuthKey, Group_Prefix = Group_Prefix, WS_Password = WS_Password, WS_UserName = WS_UserName, Acc_Number = Acc_Number, AccountType = AccountType, Active0In1 = Active0In1, CallerId = CallerId, PassCode = PassCode, PlanExpiresOn = PlanExpiresOn, RegisteredDate = RegisteredDate });
            return FN_Add_New_Account(data, output);
        }

        [NonAction]
        private IHttpActionResult FN_Add_New_Account(Add_New_Account_Return vm, string output)
        {
            if (string.Equals(output, "text", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                {
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Add_New_Account_Response).GetProperties().ToList(), vm.WsResult), Configuration.Formatters.JsonFormatter);
                }
                return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Add_New_Account_Return).GetProperties().ToList(), vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "csv", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm.WsResult), Configuration.Formatters.JsonFormatter);
                else
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "json", StringComparison.OrdinalIgnoreCase))
            {
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "xml", StringComparison.OrdinalIgnoreCase))
            {
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.XmlFormatter);
            }
            else
            {
                return Ok(vm);
            }
        }
        #endregion add_new_account

        #region 8 add_to_customer_master 

        [Route("api/webservices/add_to_customer_master")]
        [HttpPost]
        public IHttpActionResult add_to_customer_master(Add_To_Customer_Master_Request _request, string output = null)
        {
            var data = _customerService.Add_To_Customer_Master(_request);
            return FN_Add_To_Customer_Master(data, output);
        }

        [Route("api/webservices/add_to_customer_master")]
        [HttpGet]
        public IHttpActionResult add_to_customer_master(string AuthKey, string WS_UserName, string WS_Password, string Group_Prefix, int Acc_Number, string First_Name = null, string Last_Name = null, string WebUserName = null, string WebPassword = null, string CustomerAddress = null, string CustomerCity = null, string CustomerState = null, string CustomerZip_Code = null, string CustomerCountry = null, string CustomerEmail_Address = null, DateTime? RegisteredDate = null, string output = null)
        {
            var data = _customerService.Add_To_Customer_Master(new Add_To_Customer_Master_Request() { AuthKey = AuthKey, Group_Prefix = Group_Prefix, WS_Password = WS_Password, WS_UserName = WS_UserName, Acc_Number = Acc_Number, RegisteredDate = RegisteredDate, CustomerAddress = CustomerAddress, CustomerCity = CustomerCity, CustomerCountry = CustomerCountry, CustomerEmail_Address = CustomerEmail_Address, CustomerState = CustomerState, CustomerZip_Code = CustomerZip_Code, First_Name = First_Name, Last_Name = Last_Name, WebPassword = WebPassword, WebUserName = WebUserName });
            return FN_Add_To_Customer_Master(data, output);
        }

        [NonAction]
        private IHttpActionResult FN_Add_To_Customer_Master(Add_To_Customer_Master_Return vm, string output)
        {
            if (string.Equals(output, "text", StringComparison.OrdinalIgnoreCase))
            {

                if (vm.WsResult != null)
                {
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Add_To_Customer_Master_Response).GetProperties().ToList(), vm.WsResult), Configuration.Formatters.JsonFormatter);
                }
                return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Add_To_Customer_Master_Return).GetProperties().ToList(), vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "csv", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm.WsResult), Configuration.Formatters.JsonFormatter);
                else
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "json", StringComparison.OrdinalIgnoreCase))
            {

                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "xml", StringComparison.OrdinalIgnoreCase))
            {

                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.XmlFormatter);
            }
            else
            {
                return Ok(vm);
            }
        }
        #endregion add_to_customer_master

        #region 9 add_to_user_minute

        [Route("api/webservices/add_to_user_minute")]
        [HttpPost]
        public IHttpActionResult add_to_user_minute(Add_To_User_Minute_Request _request, string output = null)
        {
            var data = _userService.Add_To_User_Minute(_request);
            return FN_Add_To_User_Minute(data, output);
        }

        [Route("api/webservices/add_to_user_minute")]
        [HttpGet]
        public IHttpActionResult add_to_user_minute(string AuthKey, string WS_UserName, string WS_Password, string Group_Prefix, int Acc_Number, int Minute_In_Package, DateTime? RegisteredDate = null, string output = null)
        {
            var data = _userService.Add_To_User_Minute(new Add_To_User_Minute_Request() { AuthKey = AuthKey, Group_Prefix = Group_Prefix, WS_Password = WS_Password, WS_UserName = WS_UserName, Acc_Number = Acc_Number, RegisteredDate = RegisteredDate, Seconds_In_Package = Minute_In_Package });
            return FN_Add_To_User_Minute(data, output);
        }
        [NonAction]
        private IHttpActionResult FN_Add_To_User_Minute(Add_To_User_Minute_Return vm, string output)
        {
            if (string.Equals(output, "text", StringComparison.OrdinalIgnoreCase))
            {

                if (vm.WsResult != null)
                {
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Add_To_User_Minute_Response).GetProperties().ToList(), vm.WsResult), Configuration.Formatters.JsonFormatter);
                }
                return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Add_To_User_Minute_Return).GetProperties().ToList(), vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "csv", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm.WsResult), Configuration.Formatters.JsonFormatter);
                else
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "json", StringComparison.OrdinalIgnoreCase))
            {
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "xml", StringComparison.OrdinalIgnoreCase))
            {
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.XmlFormatter);
            }
            else
            {
                return Ok(vm);
            }
        }

        #endregion add_to_user_minute

        #region 10 add_to_payment_details  

        [Route("api/webservices/add_to_payment_details")]
        [HttpPost]
        public IHttpActionResult add_to_payment_details(Add_To_Payment_Details_Request _request, string output = null)
        {
            var data = _accountService.Add_To_Payment_Details(_request);
            return FN_Add_To_Payment_Details(data, output);
        }
        [Route("api/webservices/add_to_payment_details")]
        [HttpGet]
        public IHttpActionResult add_to_payment_details(string AuthKey, string WS_UserName, string WS_Password, string Group_Prefix, int Acc_Number, DateTime? RegisteredDate, int Minutes_In_Package, DateTime? New_Expiry, DateTime? Old_Expiry, string Package_Description, string Plan_Amount, int Plan_Id, int Plan_Validity, int Charged_Amount, string CC_EXPDATE = null, string FULL_CC_NUMBER = null, string CVC = null, short Response_Code = 0, string Response_Reason_Code = null, string Response_Reason_Text = null, string Approval_Code = null, string AVS_Result_Code = null, string Transaction_Id = null, string Payment_Type_Text = null, string CallerId = null, string output = null)
        {
            var data = _accountService.Add_To_Payment_Details(new Add_To_Payment_Details_Request() { AuthKey = AuthKey, Group_Prefix = Group_Prefix, WS_Password = WS_Password, WS_UserName = WS_UserName, Acc_Number = Acc_Number, RegisteredDate = RegisteredDate, Approval_Code = Approval_Code, AVS_Result_Code = AVS_Result_Code, CC_EXPDATE = CC_EXPDATE, CVC = CVC, FULL_CC_NUMBER = FULL_CC_NUMBER, Minutes_In_Package = Minutes_In_Package, New_Expiry = New_Expiry, Old_Expiry = Old_Expiry, Package_Description = Package_Description, Payment_Type_Text = Payment_Type_Text, Plan_Amount = Plan_Amount, Plan_Id = Plan_Id, Plan_Validity = Plan_Validity, Response_Code = Response_Code, Response_Reason_Code = Response_Reason_Code, Response_Reason_Text = Response_Reason_Text, Transaction_Id = Transaction_Id, Charged_Amount = Charged_Amount, CallerId = CallerId });
            return FN_Add_To_Payment_Details(data, output);
        }
        [NonAction]
        private IHttpActionResult FN_Add_To_Payment_Details(Add_To_Payment_Details_Return vm, string output)
        {
            if (string.Equals(output, "text", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                {
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Add_To_Payment_Details_Response).GetProperties().ToList(), vm.WsResult), Configuration.Formatters.JsonFormatter);
                }
                return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Add_To_Payment_Details_Return).GetProperties().ToList(), vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "csv", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm.WsResult), Configuration.Formatters.JsonFormatter);
                else
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "json", StringComparison.OrdinalIgnoreCase))
            {
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "xml", StringComparison.OrdinalIgnoreCase))
            {
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.XmlFormatter);
            }
            else
            {
                return Ok(vm);
            }
        }


        #endregion add_to_payment_details

        #region 11 add_to_service_source 

        [Route("api/webservices/add_to_service_source")]
        [HttpPost]
        public IHttpActionResult add_to_service_source(Add_To_Service_Source_Request _request, string output = null)
        {
            var data = _userService.Add_To_Service_Source(_request);
            return FN_Add_To_Service_Source(data, output);
        }

        [Route("api/webservices/add_to_service_source")]
        [HttpGet]
        public IHttpActionResult add_to_service_source(string AuthKey, string WS_UserName, string WS_Password, string Group_Prefix, int Acc_Number, int Service_Source, string Area_Code, DateTime? RegisteredDate = null, string output = null)
        {
            var data = _userService.Add_To_Service_Source(new Add_To_Service_Source_Request() { AuthKey = AuthKey, Group_Prefix = Group_Prefix, WS_Password = WS_Password, WS_UserName = WS_UserName, Acc_Number = Acc_Number, RegisteredDate = RegisteredDate, Service_Source = Service_Source, Area_Code = Area_Code });
            return FN_Add_To_Service_Source(data, output);
        }

        [NonAction]
        private IHttpActionResult FN_Add_To_Service_Source(Add_To_Service_Source_Return vm, string output)
        {
            if (string.Equals(output, "text", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                {
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Add_To_Service_Source_Response).GetProperties().ToList(), vm.WsResult), Configuration.Formatters.JsonFormatter);
                }
                return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Add_To_Service_Source_Return).GetProperties().ToList(), vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "csv", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm.WsResult), Configuration.Formatters.JsonFormatter);
                else
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "json", StringComparison.OrdinalIgnoreCase))
            {
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "xml", StringComparison.OrdinalIgnoreCase))
            {
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.XmlFormatter);
            }
            else
            {
                return Ok(vm);
            }
        }
        #endregion add_to_service_source

        #region 12 update_account


        [Route("api/webservices/update_account")]
        [HttpPost]
        public IHttpActionResult add_to_service_source(Update_Account_Request _request, string output = null)
        {
            Update_Account_Return data = _accountService.update_account(_request);
            return FN_Update_Account(data, output);
        }

        [Route("api/webservices/update_account")]
        [HttpGet]
        public IHttpActionResult update_account(string AuthKey, string WS_UserName, string WS_Password, string Group_Prefix, int Acc_Number, DateTime? New_Expiry, string AccountType = null, string CallerID = null, string Active0In1 = null, string output = null)
        {
            var data = _accountService.update_account(new Update_Account_Request() { AuthKey = AuthKey, Group_Prefix = Group_Prefix, WS_Password = WS_Password, WS_UserName = WS_UserName, Acc_Number = Acc_Number, AccountType = AccountType, Active0In1 = Active0In1, New_Expiry = New_Expiry, CallerID = CallerID });
            return FN_Update_Account(data, output);
        }

        [NonAction]
        private IHttpActionResult FN_Update_Account(Update_Account_Return vm, string output)
        {
            if (string.Equals(output, "text", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                {
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Update_Account_Response).GetProperties().ToList(), vm.WsResult), Configuration.Formatters.JsonFormatter);
                }
                return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Update_Account_Return).GetProperties().ToList(), vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "csv", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm.WsResult), Configuration.Formatters.JsonFormatter);
                else
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "json", StringComparison.OrdinalIgnoreCase))
            {
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "xml", StringComparison.OrdinalIgnoreCase))
            {
                //return Ok(XmlSerializer.SerializeToString(vm.WsResult));
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.XmlFormatter);
            }
            else
            {
                return Ok(vm);
            }
        }

        #endregion update_account

        #region 13 update_user_minute 
        [Route("api/webservices/update_user_minute")]
        [HttpPost]
        public IHttpActionResult update_user_minute(Update_User_Minute_Request _request, string output = null)
        {
            Update_User_Minute_Return data = _userService.update_user_minute(_request);
            return FN_Update_User_Minute(data, output);
        }

        [Route("api/webservices/update_user_minute")]
        [HttpGet]
        public IHttpActionResult update_user_minute(string AuthKey, string WS_UserName, string WS_Password, string Group_Prefix, int Acc_Number, int Minutes_In_Package, DateTime? RegisteredDate=null, string output = null)
        {
            var data = _userService.update_user_minute(new Update_User_Minute_Request() { AuthKey = AuthKey, Group_Prefix = Group_Prefix, WS_Password = WS_Password, WS_UserName = WS_UserName, Acc_Number = Acc_Number, Minutes_In_Package = Minutes_In_Package, RegisteredDate = RegisteredDate });
            return FN_Update_User_Minute(data, output);
        }

        [NonAction]
        private IHttpActionResult FN_Update_User_Minute(Update_User_Minute_Return vm, string output)
        {
            if (string.Equals(output, "text", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                {
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Update_User_Minute_Response).GetProperties().ToList(), vm.WsResult), Configuration.Formatters.JsonFormatter);
                }
                return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Update_User_Minute_Return).GetProperties().ToList(), vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "csv", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm.WsResult), Configuration.Formatters.JsonFormatter);
                else
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "json", StringComparison.OrdinalIgnoreCase))
            {
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "xml", StringComparison.OrdinalIgnoreCase))
            {
                //return Ok(XmlSerializer.SerializeToString(vm.WsResult));
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.XmlFormatter);
            }
            else
            {
                return Ok(vm);
            }
        }
        #endregion update_user_minute

        #region 14 validate

        [Route("api/webservices/validate")]
        [HttpPost]
        public IHttpActionResult validate(Validate_Request _request, string output = null)
        {
            Validate_Return data = _accountService.validate(_request);
            return FN_Validate(data, output);
        }

        [Route("api/webservices/validate")]
        [HttpGet]
        public IHttpActionResult validate(string AuthKey, string WS_UserName, string WS_Password, string Group_Prefix, int Acc_Number, string PassCode, string output = null)
        {
            var data = _accountService.validate(new Validate_Request() { AuthKey = AuthKey, Group_Prefix = Group_Prefix, WS_Password = WS_Password, WS_UserName = WS_UserName, Acc_Number = Acc_Number, PassCode = PassCode });
            return FN_Validate(data, output);
        }

        [NonAction]
        private IHttpActionResult FN_Validate(Validate_Return vm, string output)
        {
            if (string.Equals(output, "text", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                {
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Validate_Response).GetProperties().ToList(), vm.WsResult), Configuration.Formatters.JsonFormatter);
                }
                return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Validate_Return).GetProperties().ToList(), vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "csv", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm.WsResult), Configuration.Formatters.JsonFormatter);
                else
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "json", StringComparison.OrdinalIgnoreCase))
            {
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "xml", StringComparison.OrdinalIgnoreCase))
            {
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.XmlFormatter);
            }
            else
            {
                return Ok(vm);
            }
        }

        #endregion validate

        #region 15 get_member_minutes 

        [Route("api/webservices/get_member_minutes")]
        [HttpPost]
        public IHttpActionResult get_member_minutes(Get_Member_Minutes_Request _request, string output = null)
        {
            Get_Member_Minutes_Return data = _memberService.get_member_minutes(_request);
            return FN_Get_Member_Minutes(data, output);
        }

        [Route("api/webservices/get_member_minutes")]
        [HttpGet]
        public IHttpActionResult get_member_minutes(string AuthKey, string WS_UserName, string WS_Password, string Group_Prefix, int Acc_Number, string output = null)
        {
            var data = _memberService.get_member_minutes(new Get_Member_Minutes_Request() { AuthKey = AuthKey, Group_Prefix = Group_Prefix, WS_Password = WS_Password, WS_UserName = WS_UserName, Acc_Number = Acc_Number });
            return FN_Get_Member_Minutes(data, output);
        }

        [NonAction]
        private IHttpActionResult FN_Get_Member_Minutes(Get_Member_Minutes_Return vm, string output)
        {
            if (string.Equals(output, "text", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                {
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Get_Member_Minutes_Response).GetProperties().ToList(), vm.WsResult), Configuration.Formatters.JsonFormatter);
                }
                return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Get_Member_Minutes_Return).GetProperties().ToList(), vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "csv", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm.WsResult), Configuration.Formatters.JsonFormatter);
                else
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "json", StringComparison.OrdinalIgnoreCase))
            {
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "xml", StringComparison.OrdinalIgnoreCase))
            {
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.XmlFormatter);
            }
            else
            {
                return Ok(vm);
            }
        }

        #endregion get_member_minutes

        #region 16 process_mobile_charge

        [Route("api/webservices/process_mobile_charge")]
        [HttpPost]
        public IHttpActionResult process_mobile_charge(Process_Mobile_Charge_Request _request, string output = null)
        {
            Process_Mobile_Charge_Return data = _accountService.process_mobile_charge(_request);
            return FN_Process_Mobile_Charge(data, output);
        }

        [Route("api/webservices/process_mobile_charge")]
        [HttpGet]
        public IHttpActionResult process_mobile_charge(string AuthKey, string WS_UserName, string WS_Password, string Group_Prefix, int Acc_Number, string SubscriberNo, int PassCode, int SMS_Id, string TicketId, int CarrierId, double ChargeAmount, string output = null)
        {
            var data = _accountService.process_mobile_charge(new Process_Mobile_Charge_Request() { AuthKey = AuthKey, Group_Prefix = Group_Prefix, WS_Password = WS_Password, WS_UserName = WS_UserName, Acc_Number = Acc_Number, CarrierId = CarrierId, ChargeAmount = ChargeAmount, PassCode = PassCode, SMS_Id = SMS_Id, SubscriberNo = SubscriberNo, TicketId = TicketId });
            return FN_Process_Mobile_Charge(data, output);
        }

        [NonAction]
        private IHttpActionResult FN_Process_Mobile_Charge(Process_Mobile_Charge_Return vm, string output)
        {
            if (string.Equals(output, "text", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                {
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Process_Mobile_Charge_Response).GetProperties().ToList(), vm.WsResult), Configuration.Formatters.JsonFormatter);
                }
                return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Process_Mobile_Charge_Return).GetProperties().ToList(), vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "csv", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm.WsResult), Configuration.Formatters.JsonFormatter);
                else
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "json", StringComparison.OrdinalIgnoreCase))
            {
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "xml", StringComparison.OrdinalIgnoreCase))
            {
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.XmlFormatter);
            }
            else
            {
                return Ok(vm);
            }
        }

        #endregion process_mobile_charge

        #region 17 insert_login_log 
        [Route("api/webservices/insert_login_log")]
        [HttpPost]
        public IHttpActionResult insert_login_log(Insert_Login_Log_Request _request, string output = null)
        {
            Insert_Login_Log_Return data = _accountService.insert_login_log(_request);
            return FN_Insert_Login_Log(data, output);
        }

        [Route("api/webservices/insert_login_log")]
        [HttpGet]
        public IHttpActionResult insert_login_log(string AuthKey, string WS_UserName, string WS_Password, string Session, string CC_UserName = null, string CC_IPAddress = null, DateTime? DateIn = null, string TimeIn = null, DateTime? LastTimeStamp = null, string output = null)
        {
            var data = _accountService.insert_login_log(new Insert_Login_Log_Request() { AuthKey = AuthKey, WS_Password = WS_Password, WS_UserName = WS_UserName, CC_IPAddress = CC_IPAddress, LastTimeStamp = LastTimeStamp, Session = Session, TimeIn = TimeIn, DateIn = DateIn, CC_UserName = CC_UserName });
            return FN_Insert_Login_Log(data, output);
        }

        [NonAction]
        private IHttpActionResult FN_Insert_Login_Log(Insert_Login_Log_Return vm, string output)
        {
            if (string.Equals(output, "text", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                {
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Insert_Login_Log_Response).GetProperties().ToList(), vm.WsResult), Configuration.Formatters.JsonFormatter);
                }
                return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Insert_Login_Log_Return).GetProperties().ToList(), vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "csv", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm.WsResult), Configuration.Formatters.JsonFormatter);
                else
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "json", StringComparison.OrdinalIgnoreCase))
            {
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "xml", StringComparison.OrdinalIgnoreCase))
            {
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.XmlFormatter);
            }
            else
            {
                return Ok(vm);
            }
        }
        #endregion insert_login_log

        #region 18 update_login_log 
        [Route("api/webservices/update_login_log")]
        [HttpPost]
        public IHttpActionResult update_login_log(Update_Login_Log_Request _request, string output = null)
        {
            Update_Login_Log_Return data = _accountService.update_login_log(_request);
            return FN_Update_Login_Log(data, output);
        }

        [Route("api/webservices/update_login_log")]
        [HttpGet]
        public IHttpActionResult update_login_log(string AuthKey, string WS_UserName, string WS_Password, string Session, DateTime? DateOut = null, string TimeOut = null, DateTime? LastTimeStamp = null, string output = null)
        {
            var data = _accountService.update_login_log(new Update_Login_Log_Request() { AuthKey = AuthKey, WS_Password = WS_Password, WS_UserName = WS_UserName, LastTimeStamp = LastTimeStamp, Session = Session, DateOut = DateOut, TimeOut = TimeOut });
            return FN_Update_Login_Log(data, output);
        }

        [NonAction]
        private IHttpActionResult FN_Update_Login_Log(Update_Login_Log_Return vm, string output)
        {
            if (string.Equals(output, "text", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                {
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Update_Login_Log_Response).GetProperties().ToList(), vm.WsResult), Configuration.Formatters.JsonFormatter);
                }
                return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Update_Login_Log_Return).GetProperties().ToList(), vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "csv", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm.WsResult), Configuration.Formatters.JsonFormatter);
                else
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "json", StringComparison.OrdinalIgnoreCase))
            {
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "xml", StringComparison.OrdinalIgnoreCase))
            {
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.XmlFormatter);
            }
            else
            {
                return Ok(vm);
            }
        }
        #endregion update_login_log

        #region 19 admin_web_screening
        [Route("api/webservices/admin_web_screening")]
        [HttpPost]
        public IHttpActionResult admin_web_screening(Admin_Web_Screening_Request _request, string output = null)
        {
            Admin_Web_Screening_Return data = _accountService.admin_web_screening(_request, System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["Adminscreen"].ToString()));
            return FN_Admin_Web_Screening(data, output);
        }

        [Route("api/webservices/admin_web_screening")]
        [HttpGet]
        public IHttpActionResult admin_web_screening(string AuthKey, string WS_UserName, string WS_Password, string Group_Prefix, int Acc_Number, int App1Del2, string output = null)
        {
            var data = _accountService.admin_web_screening(new Admin_Web_Screening_Request() { AuthKey = AuthKey, WS_Password = WS_Password, WS_UserName = WS_UserName, Acc_Number = Acc_Number, Group_Prefix = Group_Prefix, App1Del2 = App1Del2 }, System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["Adminscreen"].ToString()));
            return FN_Admin_Web_Screening(data, output);
        }

        [NonAction]
        private IHttpActionResult FN_Admin_Web_Screening(Admin_Web_Screening_Return vm, string output)
        {
            if (string.Equals(output, "text", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                {
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Admin_Web_Screening_Response).GetProperties().ToList(), vm.WsResult), Configuration.Formatters.JsonFormatter);
                }
                return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Admin_Web_Screening_Return).GetProperties().ToList(), vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "csv", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm.WsResult), Configuration.Formatters.JsonFormatter);
                else
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "json", StringComparison.OrdinalIgnoreCase))
            {
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "xml", StringComparison.OrdinalIgnoreCase))
            {
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.XmlFormatter);
            }
            else
            {
                return Ok(vm);
            }
        }
        #endregion admin_web_screening

        #region 20 getchargeamount 
        [Route("api/webservices/getchargeamount")]
        [HttpPost]
        public IHttpActionResult getchargeamount(Getchargeamount_Request _request, string output = null)
        {
            Getchargeamount_Return data = _accountService.getchargeamount(_request);
            return FN_Getchargeamount(data, output);
        }

        [Route("api/webservices/getchargeamount")]
        [HttpGet]
        public IHttpActionResult getchargeamount(string AuthKey, string WS_UserName, string WS_Password, int Area_Code, int Plan_Id, string output = null)
        {
            var data = _accountService.getchargeamount(new Getchargeamount_Request() { AuthKey = AuthKey, WS_Password = WS_Password, WS_UserName = WS_UserName, Area_Code = Area_Code, Plan_Id = Plan_Id });
            return FN_Getchargeamount(data, output);
        }

        [NonAction]
        private IHttpActionResult FN_Getchargeamount(Getchargeamount_Return vm, string output)
        {
            if (string.Equals(output, "text", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                {
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Getchargeamount_Response).GetProperties().ToList(), vm.WsResult), Configuration.Formatters.JsonFormatter);
                }
                return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Getchargeamount_Return).GetProperties().ToList(), vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "csv", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm.WsResult), Configuration.Formatters.JsonFormatter);
                else
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "json", StringComparison.OrdinalIgnoreCase))
            {
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "xml", StringComparison.OrdinalIgnoreCase))
            {
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.XmlFormatter);
            }
            else
            {
                return Ok(vm);
            }
        }
        #endregion getchargeamount

        #region 21 delete_completeaccount

        [Route("api/webservices/delete_completeaccount")]
        [HttpPost]
        public IHttpActionResult delete_completeaccount(Delete_Completeaccount_Request _request, string output = null)
        {
            Delete_Completeaccount_Return data = _accountService.delete_completeaccount(_request);
            return FN_Delete_Completeaccount(data, output);
        }

        [Route("api/webservices/delete_completeaccount")]
        [HttpGet]
        public IHttpActionResult delete_completeaccount(string AuthKey, string WS_UserName, string WS_Password, string Group_Prefix, int Acc_Number, string output = null)
        {
            var data = _accountService.delete_completeaccount(new Delete_Completeaccount_Request() { AuthKey = AuthKey, WS_Password = WS_Password, WS_UserName = WS_UserName, Acc_Number = Acc_Number, Group_Prefix = Group_Prefix });
            return FN_Delete_Completeaccount(data, output);
        }

        [NonAction]
        private IHttpActionResult FN_Delete_Completeaccount(Delete_Completeaccount_Return vm, string output)
        {
            if (string.Equals(output, "text", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                {
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Delete_Completeaccount_Response).GetProperties().ToList(), vm.WsResult), Configuration.Formatters.JsonFormatter);
                }
                return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Delete_Completeaccount_Return).GetProperties().ToList(), vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "csv", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm.WsResult), Configuration.Formatters.JsonFormatter);
                else
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "json", StringComparison.OrdinalIgnoreCase))
            {
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "xml", StringComparison.OrdinalIgnoreCase))
            {
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.XmlFormatter);
            }
            else
            {
                return Ok(vm);
            }
        }

        #endregion delete_completeaccount

        #region 22 read_misc
        [Route("api/webservices/read_misc")]
        [HttpPost]
        public IHttpActionResult read_misc(Read_Misc_Request _request, string output = null)
        {
            Read_Misc_Return data = _accountService.read_misc(_request);
            return FN_Read_Misc(data, output);
        }

        [Route("api/webservices/read_misc")]
        [HttpGet]
        public IHttpActionResult read_misc(string AuthKey, string WS_UserName, string WS_Password, string output = null)
        {
            var data = _accountService.read_misc(new Read_Misc_Request() { AuthKey = AuthKey, WS_Password = WS_Password, WS_UserName = WS_UserName });
            return FN_Read_Misc(data, output);
        }

        [NonAction]
        private IHttpActionResult FN_Read_Misc(Read_Misc_Return vm, string output)
        {
            if (string.Equals(output, "text", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                {
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Read_Misc_Response).GetProperties().ToList(), vm.WsResult), Configuration.Formatters.JsonFormatter);
                }
                return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Read_Misc_Return).GetProperties().ToList(), vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "csv", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm.WsResult), Configuration.Formatters.JsonFormatter);
                else
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "json", StringComparison.OrdinalIgnoreCase))
            {
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "xml", StringComparison.OrdinalIgnoreCase))
            {
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.XmlFormatter);
            }
            else
            {
                return Ok(vm);
            }
        }
        #endregion read_misc

        #region 23 set_misc 
        [Route("api/webservices/set_misc")]
        [HttpPost]
        public IHttpActionResult set_misc(Set_Misc_Request _request, string output = null)
        {
            Set_Misc_Return data = _accountService.set_misc(_request);
            return FN_Set_Misc(data, output);
        }

        [Route("api/webservices/set_misc")]
        [HttpGet]
        public IHttpActionResult set_misc(string AuthKey, string WS_UserName, string WS_Password, string SettingName, string SettingValue, string output = null)
        {
            var data = _accountService.set_misc(new Set_Misc_Request() { AuthKey = AuthKey, WS_Password = WS_Password, WS_UserName = WS_UserName, SettingName = SettingName, SettingValue = SettingValue });
            return FN_Set_Misc(data, output);
        }

        [NonAction]
        private IHttpActionResult FN_Set_Misc(Set_Misc_Return vm, string output)
        {
            if (string.Equals(output, "text", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                {
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Set_Misc_Response).GetProperties().ToList(), vm.WsResult), Configuration.Formatters.JsonFormatter);
                }
                return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Set_Misc_Return).GetProperties().ToList(), vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "csv", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm.WsResult), Configuration.Formatters.JsonFormatter);
                else
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "json", StringComparison.OrdinalIgnoreCase))
            {
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "xml", StringComparison.OrdinalIgnoreCase))
            {
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.XmlFormatter);
            }
            else
            {
                return Ok(vm);
            }
        }
        #endregion set_misc

        #region 24 set_primary_apiserver 

        [Route("api/webservices/set_primary_apiserver")]
        [HttpPost]
        public IHttpActionResult set_primary_apiserver(Set_Primary_Apiserver_Request _request, string output = null)
        {
            Set_Primary_Apiserver_Return data = _accountService.set_primary_apiserver(_request);
            return FN_Set_Primary_Apiserver(data, output);
        }

        [Route("api/webservices/set_primary_apiserver")]
        [HttpGet]
        public IHttpActionResult set_primary_apiserver(string AuthKey, string WS_UserName, string WS_Password, string ActiveServerIP, string output = null)
        {
            var data = _accountService.set_primary_apiserver(new Set_Primary_Apiserver_Request() { AuthKey = AuthKey, WS_Password = WS_Password, WS_UserName = WS_UserName, ActiveServerIP = ActiveServerIP });
            return FN_Set_Primary_Apiserver(data, output);
        }

        [NonAction]
        private IHttpActionResult FN_Set_Primary_Apiserver(Set_Primary_Apiserver_Return vm, string output)
        {
            if (string.Equals(output, "text", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                {
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Set_Primary_Apiserver_Response).GetProperties().ToList(), vm.WsResult), Configuration.Formatters.JsonFormatter);
                }
                return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Set_Primary_Apiserver_Return).GetProperties().ToList(), vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "csv", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm.WsResult), Configuration.Formatters.JsonFormatter);
                else
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "json", StringComparison.OrdinalIgnoreCase))
            {
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "xml", StringComparison.OrdinalIgnoreCase))
            {
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.XmlFormatter);
            }
            else
            {
                return Ok(vm);
            }
        }
        #endregion set_primary_apiserver

        #region 25 check_geo_location 
        [Route("api/webservices/check_geo_location")]
        [HttpPost]
        public IHttpActionResult check_geo_location(Check_Geo_Location_Request _request, string output = null)
        {
            Check_Geo_Location_Return data = _userService.check_geo_location(_request);
            return FN_Check_Geo_Location(data, output);
        }

        [Route("api/webservices/check_geo_location")]
        [HttpGet]
        public IHttpActionResult check_geo_location(string AuthKey, string WS_UserName, string WS_Password, string Client_IP_Location, string output = null)
        {
            var data = _userService.check_geo_location(new Check_Geo_Location_Request() { AuthKey = AuthKey, WS_Password = WS_Password, WS_UserName = WS_UserName, Client_IP_Location = Client_IP_Location });
            return FN_Check_Geo_Location(data, output);
        }

        [NonAction]
        private IHttpActionResult FN_Check_Geo_Location(Check_Geo_Location_Return vm, string output)
        {
            if (string.Equals(output, "text", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                {
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Check_Geo_Location_Response).GetProperties().ToList(), vm.WsResult), Configuration.Formatters.JsonFormatter);
                }
                return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Check_Geo_Location_Return).GetProperties().ToList(), vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "csv", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm.WsResult), Configuration.Formatters.JsonFormatter);
                else
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "json", StringComparison.OrdinalIgnoreCase))
            {
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "xml", StringComparison.OrdinalIgnoreCase))
            {
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.XmlFormatter);
            }
            else
            {
                return Ok(vm);
            }
        }
        #endregion check_geo_location

        #region 26 get_node3_accesspoint_ip 
        [Route("api/webservices/get_node3_accesspoint_ip")]
        [HttpPost]
        public IHttpActionResult get_node3_accesspoint_ip(Get_Node3_Accesspoint_Ip_Request _request, string output = null)
        {
            Get_Node3_Accesspoint_Ip_Return data = _userService.get_node3_accesspoint_ip(_request);
            return FN_Get_Node3_Accesspoint_Ip(data, output);
        }

        [Route("api/webservices/get_node3_accesspoint_ip")]
        [HttpGet]
        public IHttpActionResult get_node3_accesspoint_ip(string AuthKey, string WS_UserName, string WS_Password, string output = null)
        {
            var data = _userService.get_node3_accesspoint_ip(new Get_Node3_Accesspoint_Ip_Request() { AuthKey = AuthKey, WS_Password = WS_Password, WS_UserName = WS_UserName });
            return FN_Get_Node3_Accesspoint_Ip(data, output);
        }

        [NonAction]
        private IHttpActionResult FN_Get_Node3_Accesspoint_Ip(Get_Node3_Accesspoint_Ip_Return vm, string output)
        {
            if (string.Equals(output, "text", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                {
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Get_Node3_Accesspoint_Ip_Response).GetProperties().ToList(), vm.WsResult), Configuration.Formatters.JsonFormatter);
                }
                return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Get_Node3_Accesspoint_Ip_Return).GetProperties().ToList(), vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "csv", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm.WsResult), Configuration.Formatters.JsonFormatter);
                else
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "json", StringComparison.OrdinalIgnoreCase))
            {
                //return Json(vm);
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "xml", StringComparison.OrdinalIgnoreCase))
            {
                //return Ok(XmlSerializer.SerializeToString(vm.WsResult));
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.XmlFormatter);
            }
            else
            {
                return Ok(vm);
            }
        }
        #endregion get_node3_accesspoint_ip

        #region 27 update_customer_master Update_Customer_Master
        [Route("api/webservices/update_customer_master")]
        [HttpPost]
        public IHttpActionResult update_customer_master(Update_Customer_Master_Request _request, string output = null)
        {
            Add_To_Customer_Master_Return data = _customerService.Add_To_Customer_Master(_request);
            Update_Customer_Master_Return rtn = new Update_Customer_Master_Return() { Count = data.Count, ErrorMessage = data.ErrorMessage, WsResult = data.WsResult };
            return FN_Update_Customer_Master(rtn, output);
        }

        [Route("api/webservices/update_customer_master")]
        [HttpGet]
        public IHttpActionResult update_customer_master(string AuthKey, string WS_UserName, string WS_Password, string Group_Prefix, int Acc_Number, string First_Name = null, string Last_Name = null, string WebUserName = null, string WebPassword = null, string CustomerAddress = null, string CustomerCity = null, string CustomerState = null, string CustomerZip_Code = null, string CustomerCountry = null, string CustomerEmail_Address = null, DateTime? RegisteredDate = null, string output = null)
        {
            var data = _customerService.Add_To_Customer_Master(new Add_To_Customer_Master_Request() { AuthKey = AuthKey, Group_Prefix = Group_Prefix, WS_Password = WS_Password, WS_UserName = WS_UserName, Acc_Number = Acc_Number, RegisteredDate = RegisteredDate, CustomerAddress = CustomerAddress, CustomerCity = CustomerCity, CustomerCountry = CustomerCountry, CustomerEmail_Address = CustomerEmail_Address, CustomerState = CustomerState, CustomerZip_Code = CustomerZip_Code, First_Name = First_Name, Last_Name = Last_Name, WebPassword = WebPassword, WebUserName = WebUserName });

            Update_Customer_Master_Return rtn = new Update_Customer_Master_Return() { Count = data.Count, ErrorMessage = data.ErrorMessage, WsResult = data.WsResult };
            return FN_Update_Customer_Master(rtn, output);
        }

        [NonAction]
        private IHttpActionResult FN_Update_Customer_Master(Update_Customer_Master_Return vm, string output)
        {
            if (string.Equals(output, "text", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                {
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Update_Customer_Master_Response).GetProperties().ToList(), vm.WsResult), Configuration.Formatters.JsonFormatter);
                }
                return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Update_Customer_Master_Return).GetProperties().ToList(), vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "csv", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm.WsResult), Configuration.Formatters.JsonFormatter);
                else
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "json", StringComparison.OrdinalIgnoreCase))
            {
                //return Json(vm);
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "xml", StringComparison.OrdinalIgnoreCase))
            {
                //return Ok(XmlSerializer.SerializeToString(vm.WsResult));
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.XmlFormatter);
            }
            else
            {
                return Ok(vm);
            }
        }
        #endregion update_customer_master

        #region 28 add_complete_paid_account

        [Route("api/webservices/add_complete_paid_account")]
        [HttpPost]
        public IHttpActionResult add_complete_paid_account(Add_Complete_Paid_Account_Request _request, string output = null)
        {
            Add_Complete_Paid_Account_Return data = _accountService.add_complete_paid_account(_request);
            return FN_Add_Complete_Paid_Account(data, output);
        }

        [Route("api/webservices/add_complete_paid_account")]
        [HttpGet]
        public IHttpActionResult add_complete_paid_account(string AuthKey, string WS_UserName, string WS_Password, string Group_Prefix, int Acc_Number, string PassCode, DateTime? PlanExpiresOn, string AccountType, int Minutes_In_Package, DateTime? Old_Expiry, DateTime? New_Expiry, int Plan_Id, int Plan_Amount, int Plan_Validity, string Package_Description, int Service_Source, string Area_Code, int Charged_Amount = 0, string CallerId = null, string Active0In1 = null, string CustomerFirstName = null, string CustomerLastName = null, string WebUserName = null, string WebPassword = null, string CustomerAddress = null, string CustomerCity = null, string CustomerState = null, string CustomerZip_Code = null, string CustomerCountry = null, string CustomerEmail_Address = null, string FULL_CC_NUMBER = null, DateTime? CC_EXPDATE = null, string CVC = null, short Response_Code = 0, string Response_Reason_Code = null, string Response_Reason_Text = null, string Approval_Code = null, string AVS_Result_Code = null, int Transaction_Id = 0, string Payment_Type_Text = null, DateTime? RegisteredDate = null, string output = null)
        {
            var data = _accountService.add_complete_paid_account(new Add_Complete_Paid_Account_Request() { AuthKey = AuthKey, WS_Password = WS_Password, WS_UserName = WS_UserName, Group_Prefix = Group_Prefix, AccountType = AccountType, Active0In1 = Active0In1, Approval_Code = Approval_Code, Area_Code = Area_Code, AVS_Result_Code = AVS_Result_Code, CallerId = CallerId, CC_EXPDATE = CC_EXPDATE, CustomerAddress = CustomerAddress, CustomerCity = CustomerCity, CustomerEmail_Address = CustomerEmail_Address, CustomerFirstName = CustomerFirstName, CustomerLastName = CustomerLastName, CustomerState = CustomerState, CustomerZip_Code = CustomerZip_Code, CustomerCountry = CustomerCountry, CVC = CVC, FULL_CC_NUMBER = FULL_CC_NUMBER, Minutes_In_Package = Minutes_In_Package, New_Expiry = New_Expiry, Old_Expiry = Old_Expiry, Package_Description = Package_Description, PassCode = PassCode, Payment_Type_Text = Payment_Type_Text, PlanExpiresOn = PlanExpiresOn, Plan_Amount = Plan_Amount, Plan_Id = Plan_Id, Plan_Validity = Plan_Validity, RegisteredDate = RegisteredDate, Response_Code = Response_Code, Response_Reason_Code = Response_Reason_Code, Response_Reason_Text = Response_Reason_Text, Service_Source = Service_Source, Transaction_Id = Transaction_Id, WebPassword = WebPassword, WebUserName = WebUserName, Acc_Number = Acc_Number, Charged_Amount = Charged_Amount });
            return FN_Add_Complete_Paid_Account(data, output);
        }

        [NonAction]
        private IHttpActionResult FN_Add_Complete_Paid_Account(Add_Complete_Paid_Account_Return vm, string output)
        {
            if (string.Equals(output, "text", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                {
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Add_Complete_Paid_Account_Response).GetProperties().ToList(), vm.WsResult), Configuration.Formatters.JsonFormatter);
                }
                return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Add_Complete_Paid_Account_Return).GetProperties().ToList(), vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "csv", StringComparison.OrdinalIgnoreCase))
            {
                if (vm.WsResult != null)
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm.WsResult), Configuration.Formatters.JsonFormatter);
                else
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "json", StringComparison.OrdinalIgnoreCase))
            {
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "xml", StringComparison.OrdinalIgnoreCase))
            {
                return Content(HttpStatusCode.OK, vm, Configuration.Formatters.XmlFormatter);
            }
            else
            {
                return Ok(vm);
            }
        }

        #endregion add_complete_paid_account
    }
}
