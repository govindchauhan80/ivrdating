using ivrdating.Domain.VM;
using ivrdating.Models;
using ivrdating.Persistent.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Logic.Services
{
    public class MemberService
    {
        MemberRepository _memberRepository;
        public MemberService()
        {
            _memberRepository = new MemberRepository();
        }

        public ReturnData get_member_details(GetMemberDetailsRequest request)
        {

            string validRequest = CommonRepositories.ValidateRequest(request);

            if (!validRequest.Equals("OK"))
            {
                return new ReturnData() { Count = 0, ErrorMessage = validRequest, WsResult = null };
            }

            if (request.Acc_Number == -2)
            {
                return new ReturnData() { Count = 0, ErrorMessage = "Invalid Acc_Number it can 6 digit numeric only", WsResult = null };
            }
            if (request.Acc_Number <= 0 && string.IsNullOrEmpty(request.CallerId) && string.IsNullOrEmpty(request.CustomerEmail_Address) && string.IsNullOrEmpty(request.PassCode))
            {
                return new ReturnData() { Count = 0, ErrorMessage = "CAN NOT SEARCH CUSTOMER DETAILS, INCOMPLETE SEARCH CRITERIA", WsResult = null };
            }

            
            if (!string.IsNullOrEmpty(request.CallerId))
            {
                double ps = 0;

                if (double.TryParse(request.CallerId, out ps))
                {
                    if (ps <= 999999999 || ps > 9999999999)
                    {
                        ps = 0;
                    }
                }
                if (ps == 0)
                {
                    return new ReturnData { Count = 0, ErrorMessage = "Invalid CallerId it has 10 digit numeric only", WsResult = null };
                }
            }

            if (!string.IsNullOrEmpty(request.CustomerEmail_Address) && !CommonRepositories.IsValidEmailAddress(request.CustomerEmail_Address))
            {
                return new ReturnData() { Count = 0, ErrorMessage = "Invalid email address", WsResult = null };
            }
            ReturnData _wsResponse = new ReturnData();
            var data = _memberRepository.GetMemberDetails(request);

            if (data != null)
            {
                _wsResponse.Count = 1;
                _wsResponse.ErrorMessage = null;
                _wsResponse.WsResult = data;
            }
            else
            {
                return new ReturnData() { Count = 0, ErrorMessage = "No matching account found (Function Get_Member_Details)", WsResult = null };
            }
            return _wsResponse;
        }

        public Member_Forgot_Passcode_Return member_forgot_passcode(Member_Forgot_Passcode_Request request)
        {
            string validRequest = CommonRepositories.ValidateRequest(request);
            if (!validRequest.Equals("OK"))
            {
                return new Member_Forgot_Passcode_Return() { Count = 0, ErrorMessage = validRequest, WsResult = null };
            }
            if (request.Acc_Number == -2)
            {
                return new Member_Forgot_Passcode_Return() { Count = 0, ErrorMessage = "Invalid Acc_Number it can 6 digit numeric only", WsResult = null };
            }
            if (request.Acc_Number == 0 && string.IsNullOrEmpty(request.CallerId) && string.IsNullOrEmpty(request.CustomerEmail_Address) && string.IsNullOrEmpty(request.PassCode))
            {
                return new Member_Forgot_Passcode_Return() { Count = 0, ErrorMessage = "CAN NOT SEARCH CUSTOMER DETAILS, INCOMPLETE SEARCH CRITERIA", WsResult = null };
            }

           


            //if (request.Acc_Number < 0)
            //{
            //    return new Member_Forgot_Passcode_Return() { Count = 0, ErrorMessage = "Invalid Acc_Number", WsResult = null };
            //}

            if (!string.IsNullOrEmpty(request.CallerId))
            {
                double ps = 0;

                if (double.TryParse(request.CallerId, out ps))
                {
                    if (ps <= 999999999 || ps > 9999999999)
                    {
                        ps = 0;
                    }
                }
                if (ps == 0)
                {
                    return new Member_Forgot_Passcode_Return { Count = 0, ErrorMessage = "Invalid CallerId it has 10 digit numeric only", WsResult = null };
                }
            }

            if (!string.IsNullOrEmpty(request.CustomerEmail_Address) && !CommonRepositories.IsValidEmailAddress(request.CustomerEmail_Address))
            {
                return new Member_Forgot_Passcode_Return() { Count = 0, ErrorMessage = "Invalid email address", WsResult = null };
            }
            Member_Forgot_Passcode_Return _wsResponse = new Member_Forgot_Passcode_Return();
            Member_Forgot_Passcode_Response data = _memberRepository.member_forgot_passcode(request);

            if (data != null)
            {
                _wsResponse.Count = 1;
                _wsResponse.ErrorMessage = null;
                _wsResponse.WsResult = data;
            }
            else
            {
                return new Member_Forgot_Passcode_Return() { Count = 0, ErrorMessage = "No matching account found", WsResult = null };
            }
            return _wsResponse;
        }

        public Get_Member_Minutes_Return get_member_minutes(Get_Member_Minutes_Request _request)
        {
            string validRequest = CommonRepositories.ValidateRequest(_request);
            if (validRequest.Equals("OK"))
            {
                validRequest = "";
            }
            if (validRequest == "" && _request.Acc_Number <= 0)
            {
                return new Get_Member_Minutes_Return() { Count = 0, ErrorMessage = "Invalid Acc_Number it can 6 digit numeric only", WsResult = null };
            }
            if (validRequest != "")
            {
                return new Get_Member_Minutes_Return() { Count = 0, ErrorMessage = validRequest, WsResult = null };
            }
            else
            {
                Get_Member_Minutes_Response data = _memberRepository.get_member_minutes(_request);

                if (data == null)
                {
                    return new Get_Member_Minutes_Return() { Count = 0, ErrorMessage = "No record found" };
                }


                if (data.Acc_GuestMinutes == -11 && data.Acc_RegisMinutes == -11)
                {
                    return new Get_Member_Minutes_Return() { Count = 0, ErrorMessage = "No entries under User_Minute" };
                }
                else
                {
                    return new Get_Member_Minutes_Return() { Count = 1, ErrorMessage = null, WsResult = data };
                }

            }
        }
    }
}
