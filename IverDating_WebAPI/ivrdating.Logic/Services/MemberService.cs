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

        public ReturnData GetMemberDetails(GetMemberDetailsRequest request)
        {
            if (request.Acc_Number <= 0)
            {
                return new ReturnData() { Count = 0, ErrorMessage = "No incoming Search Parameter (Function Get_Member_Details)", WsResult = null };
            }
            string validRequest = CommonRepositories.ValidateRequest(request);
            if (!validRequest.Equals("OK"))
            {
                return new ReturnData() { Count = 0, ErrorMessage = validRequest, WsResult = null };
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
    }
}
