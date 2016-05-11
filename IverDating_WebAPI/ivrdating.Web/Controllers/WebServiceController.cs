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

        [Route("api/webservices/get_accounts")]
        [HttpGet]
        public IHttpActionResult get_accounts()
        {
            return Ok(_accountService.GetAll());
        }
        #region  get_member_details
        [Route("api/webservices/get_member_details")]
        [HttpPost]
        public IHttpActionResult get_member_details(GetMemberDetailsRequest _Request, string output = null)
        {
            ReturnData vm = _memberService.GetMemberDetails(_Request);
            return GetMemberDetail(output, vm);
        }

        [Route("api/webservices/get_member_details")]
        [HttpGet]
        public IHttpActionResult get_member_details(string AuthKey, string WS_UserName, string WS_Password, string Group_Prefix, string CustomerEmail_Address, string PassCode, int Acc_Number, string CallerId, string output = null)
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
                return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToCsv(vm.WsResult), Configuration.Formatters.JsonFormatter);
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

        #region Get_New_Acc_Number
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
        public IHttpActionResult Get_New_Acc_Number(string AuthKey, string WS_UserName, string WS_Password, string Group_Prefix, string CallerId, string output = null)
        {
            var data = _accountService.Get_New_Acc_Number(new Get_New_Acc_Number_Request() { AuthKey = AuthKey, CallerId = CallerId, Group_Prefix = Group_Prefix, WS_Password = WS_Password, WS_UserName = WS_UserName });
            return FN_Get_New_Acc_Number(data, output);

        }

        [NonAction]
        private IHttpActionResult FN_Get_New_Acc_Number(Get_New_Acc_Number_Return vm, string output)
        {
            if (string.Equals(output, "text", StringComparison.OrdinalIgnoreCase))
            {
                //return Ok(Helper.ExtensionMethods.SerializeToPlainText(typeof(MemberDetailVM).GetProperties().ToList(), vm.WsResult));
                return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Get_New_Acc_Number_Return).GetProperties().ToList(), vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "csv", StringComparison.OrdinalIgnoreCase))
            {
                // return Ok(CsvSerializer.SerializeToCsv(new List<MemberDetailVM> { vm.WsResult }));
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

        #region get_n_activate_new_acc_number
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

        #region activate_acc_number 

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

        private IHttpActionResult FN_Activate_Acc_Number(Activate_Acc_Number_Return vm, string output)
        {
            if (string.Equals(output, "text", StringComparison.OrdinalIgnoreCase))
            {
                //return Ok(Helper.ExtensionMethods.SerializeToPlainText(typeof(MemberDetailVM).GetProperties().ToList(), vm.WsResult));
                if (vm.WsResult != null)
                {
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Activate_Acc_Number_Response).GetProperties().ToList(), vm.WsResult), Configuration.Formatters.JsonFormatter);
                }
                return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Activate_Acc_Number_Return).GetProperties().ToList(), vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "csv", StringComparison.OrdinalIgnoreCase))
            {
                // return Ok(CsvSerializer.SerializeToCsv(new List<MemberDetailVM> { vm.WsResult }));
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

        #region deactivate_acc_number 


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

        private IHttpActionResult FN_Deactivate_Acc_Number(Deactivate_Acc_Number_Return vm, string output)
        {
            if (string.Equals(output, "text", StringComparison.OrdinalIgnoreCase))
            {
                //return Ok(Helper.ExtensionMethods.SerializeToPlainText(typeof(MemberDetailVM).GetProperties().ToList(), vm.WsResult));
                if (vm.WsResult != null)
                {
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Deactivate_Acc_Number_Response).GetProperties().ToList(), vm.WsResult), Configuration.Formatters.JsonFormatter);
                }
                return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Deactivate_Acc_Number_Return).GetProperties().ToList(), vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "csv", StringComparison.OrdinalIgnoreCase))
            {
                // return Ok(CsvSerializer.SerializeToCsv(new List<MemberDetailVM> { vm.WsResult }));
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
        #endregion deactivate_acc_number

        #region add_new_account 

        [Route("api/webservices/add_new_account")]
        [HttpPost]
        public IHttpActionResult add_new_account(Add_New_Account_Request _request, string output = null)
        {
            var data = _accountService.Add_New_Account(_request);
            return FN_Add_New_Account(data, output);
        }

        [Route("api/webservices/add_new_account")]
        [HttpGet]
        public IHttpActionResult add_new_account(string AuthKey, string WS_UserName, string WS_Password, string Group_Prefix, int Acc_Number, string PassCode, string CallerId, DateTime? RegisteredDate, DateTime? PlanExpiresOn, string AccountType, string Active0In1, string output = null)
        {
            var data = _accountService.Add_New_Account(new Add_New_Account_Request() { AuthKey = AuthKey, Group_Prefix = Group_Prefix, WS_Password = WS_Password, WS_UserName = WS_UserName, Acc_Number = Acc_Number, AccountType = AccountType, Active0In1 = Active0In1, CallerId = CallerId, PassCode = PassCode, PlanExpiresOn = PlanExpiresOn, RegisteredDate = RegisteredDate });
            return FN_Add_New_Account(data, output);
        }

        private IHttpActionResult FN_Add_New_Account(Add_New_Account_Return vm, string output)
        {
            if (string.Equals(output, "text", StringComparison.OrdinalIgnoreCase))
            {
                //return Ok(Helper.ExtensionMethods.SerializeToPlainText(typeof(MemberDetailVM).GetProperties().ToList(), vm.WsResult));
                if (vm.WsResult != null)
                {
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Add_New_Account_Response).GetProperties().ToList(), vm.WsResult), Configuration.Formatters.JsonFormatter);
                }
                return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Add_New_Account_Return).GetProperties().ToList(), vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "csv", StringComparison.OrdinalIgnoreCase))
            {
                // return Ok(CsvSerializer.SerializeToCsv(new List<MemberDetailVM> { vm.WsResult }));
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
        #endregion add_new_account

        #region add_to_customer_master 

        [Route("api/webservices/add_to_customer_master")]
        [HttpPost]
        public IHttpActionResult add_to_customer_master(Add_To_Customer_Master_Request _request, string output = null)
        {
            var data = _customerService.Add_To_Customer_Master(_request);
            return FN_Add_To_Customer_Master(data, output);
        }

        [Route("api/webservices/add_to_customer_master")]
        [HttpGet]
        public IHttpActionResult add_to_customer_master(string AuthKey, string WS_UserName, string WS_Password, string Group_Prefix, int Acc_Number, string First_Name, string Last_Name, string WebUserName, string WebPassword, string CustomerAddress, string CustomerCity, string CustomerState, string CustomerZip_Code, string CustomerCountry, string CustomerEmail_Address, DateTime? RegisteredDate, string output = null)
        {
            var data = _customerService.Add_To_Customer_Master(new Add_To_Customer_Master_Request() { AuthKey = AuthKey, Group_Prefix = Group_Prefix, WS_Password = WS_Password, WS_UserName = WS_UserName, Acc_Number = Acc_Number, RegisteredDate = RegisteredDate, CustomerAddress = CustomerAddress, CustomerCity = CustomerCity, CustomerCountry = CustomerCountry, CustomerEmail_Address = CustomerEmail_Address, CustomerState = CustomerState, CustomerZip_Code = CustomerZip_Code, First_Name = First_Name, Last_Name = Last_Name, WebPassword = WebPassword, WebUserName = WebUserName });
            return FN_Add_To_Customer_Master(data, output);
        }

        private IHttpActionResult FN_Add_To_Customer_Master(Add_To_Customer_Master_Return vm, string output)
        {
            if (string.Equals(output, "text", StringComparison.OrdinalIgnoreCase))
            {
                //return Ok(Helper.ExtensionMethods.SerializeToPlainText(typeof(MemberDetailVM).GetProperties().ToList(), vm.WsResult));
                if (vm.WsResult != null)
                {
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Add_To_Customer_Master_Response).GetProperties().ToList(), vm.WsResult), Configuration.Formatters.JsonFormatter);
                }
                return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Add_To_Customer_Master_Return).GetProperties().ToList(), vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "csv", StringComparison.OrdinalIgnoreCase))
            {
                // return Ok(CsvSerializer.SerializeToCsv(new List<MemberDetailVM> { vm.WsResult }));
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
        #endregion add_to_customer_master

        #region add_to_user_minute

        [Route("api/webservices/add_to_user_minute")]
        [HttpPost]
        public IHttpActionResult add_to_user_minute(Add_To_User_Minute_Request _request, string output = null)
        {
            var data = _userService.Add_To_User_Minute(_request);
            return FN_Add_To_User_Minute(data, output);
        }

        [Route("api/webservices/add_to_user_minute")]
        [HttpGet]
        public IHttpActionResult add_to_user_minute(string AuthKey, string WS_UserName, string WS_Password, string Group_Prefix, int Acc_Number, DateTime? RegisteredDate, int Seconds_In_Package, string output = null)
        {
            var data = _userService.Add_To_User_Minute(new Add_To_User_Minute_Request() { AuthKey = AuthKey, Group_Prefix = Group_Prefix, WS_Password = WS_Password, WS_UserName = WS_UserName, Acc_Number = Acc_Number, RegisteredDate = RegisteredDate, Seconds_In_Package = Seconds_In_Package });
            return FN_Add_To_User_Minute(data, output);
        }

        private IHttpActionResult FN_Add_To_User_Minute(Add_To_User_Minute_Return vm, string output)
        {
            if (string.Equals(output, "text", StringComparison.OrdinalIgnoreCase))
            {
                //return Ok(Helper.ExtensionMethods.SerializeToPlainText(typeof(MemberDetailVM).GetProperties().ToList(), vm.WsResult));
                if (vm.WsResult != null)
                {
                    return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Add_To_User_Minute_Response).GetProperties().ToList(), vm.WsResult), Configuration.Formatters.JsonFormatter);
                }
                return Content(HttpStatusCode.OK, ExtensionMethods.SerializeToPlainText(typeof(Add_To_User_Minute_Return).GetProperties().ToList(), vm), Configuration.Formatters.JsonFormatter);
            }
            else if (string.Equals(output, "csv", StringComparison.OrdinalIgnoreCase))
            {
                // return Ok(CsvSerializer.SerializeToCsv(new List<MemberDetailVM> { vm.WsResult }));
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

        #endregion add_to_user_minute
    }
}
