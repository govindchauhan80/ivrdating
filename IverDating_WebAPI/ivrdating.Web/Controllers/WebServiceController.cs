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
using ivrdating.Web.Validation;

namespace ivrdating.Web.Controllers
{
    [ivrdating.Web.Validation.Validator]
    public class WebServiceController : ApiController
    {
        AccountService _accountService;
        MemberService _memberService;
        public static string validationError = string.Empty;
        public WebServiceController()
        {
            _accountService = new AccountService();
            _memberService = new MemberService();
        }

        [Route("api/webservices/get_accounts")]
        [HttpGet]
        public IHttpActionResult get_accounts()
        {
            return Ok(_accountService.GetAll());
        }

        [Route("api/webservices/get_member_details")]
        [HttpPost]
        public IHttpActionResult get_member_details(GetMemberDetailsRequest _Request, string output = null)
        {
            if (string.IsNullOrEmpty(WebServiceController.validationError))
            {
                return GetMemberDetail(output, new ReturnData { Count = 0, ErrorMessage = WebServiceController.validationError, WsResult = null });
            }
            ReturnData vm = _memberService.GetMemberDetails(_Request);
            return GetMemberDetail(output, vm);
        }

        [Route("api/webservices/get_member_details")]
        [HttpGet]
        public IHttpActionResult get_member_details(string AuthKey, string WS_UserName, string WS_Password, string Group_Prefix, string CustomerEmail_Address, string PassCode, int Acc_Number, string CallerId, string output = null)
        {
            if (!string.IsNullOrEmpty(WebServiceController.validationError))
            {
                return GetMemberDetail(output, new ReturnData { Count = 0, ErrorMessage = WebServiceController.validationError, WsResult = null });
            }
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




        //// GET: api/WebService
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/WebService/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/WebService
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/WebService/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/WebService/5
        //public void Delete(int id)
        //{
        //}
    }
}
