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
            ReturnData _wsResponse = new ReturnData();
            var data = _memberRepository.GetMemberDetails(request);

            if (data != null)
            {
                _wsResponse.Count = 1;
                _wsResponse.ErrorMessage = null;
                _wsResponse.WsResult = data;
            }
            return _wsResponse;
        }
    }
}
