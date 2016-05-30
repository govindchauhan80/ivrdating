using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ivrdating.Domain.VM;
using ivrdating.Domain;
using ivrdating.Models;
using ivrdating.Log;

namespace ivrdating.Persistent.Repositories
{
    public class MemberRepository
    {
        ivrdating.Domain.ivrdating _context;
        LogRequestResponse _logRequestResponse;
      
        public MemberRepository()
        {
            _context = new ivrdating.Domain.ivrdating();
            _logRequestResponse = new LogRequestResponse();

            if (CommonRepositories.debugMode.Equals("On", StringComparison.OrdinalIgnoreCase))
                _context.Database.Log = s => _logRequestResponse.LogData(s, "Warn");
        }

        public GetMemberDetailsResponse GetMemberDetails(GetMemberDetailsRequest request)
        {
            // GetMemberDetailsResponse _memberDetailVM = new MemberDetailVM();
            var groupAssociation = (from ga in _context.group_association where ga.Grp_Prefix == request.Group_Prefix select ga).FirstOrDefault();

            string id = CommonRepositories.GetGroupID(request.Group_Prefix);
            IEnumerable<GetMemberDetailsResponse> query;
            if (string.IsNullOrEmpty(request.CustomerEmail_Address))
            {
                query = (from ac in _context.accounts
                         join cust in _context.customer_master on ac.Id equals cust.AId
                         into a from n in a.DefaultIfEmpty()
                         select new GetMemberDetailsResponse
                         {
                             Acc_Number = ac.Acc_Number,
                             PassCode = ac.PassCode,
                             CallerId = ac.callerid,
                             AccountType = ac.AccountType,
                             ExpiryDate = ac.ExpiryDate,
                             Grp_Id = ac.Grp_Id,
                             Email_Address = n.Email_Address,
                             First_Name = n.First_Name,
                             Last_Name = n.Last_Name,
                             address = n.Address,
                             City = n.City,
                             State_Name = n.State_Name,
                             zip_code = n.Zip_Code,
                             Country = n.Country

                         });
               // _context.Database.Log = s => _logRequestResponse.LogData(s, "Info");
            }
            else
            {
                query = (from ac in _context.accounts
                         join cust in _context.customer_master on ac.Id equals cust.AId
                         select new GetMemberDetailsResponse
                         {
                             Acc_Number = ac.Acc_Number,
                             PassCode = ac.PassCode,
                             CallerId = ac.callerid,
                             AccountType = ac.AccountType,
                             ExpiryDate = ac.ExpiryDate,
                             Grp_Id = ac.Grp_Id,
                             Email_Address = cust.Email_Address,
                             First_Name = cust.First_Name,
                             Last_Name = cust.Last_Name,
                             address = cust.Address,
                             City = cust.City,
                             State_Name = cust.State_Name,
                             zip_code = cust.Zip_Code,
                             Country = cust.Country

                         });
             //   _context.Database.Log = s => _logRequestResponse.LogData(s, "Info");
            }
            if (!string.IsNullOrEmpty(request.CustomerEmail_Address))
            {

                var output =  query.Where(a => a.Email_Address == request.CustomerEmail_Address && a.Grp_Id == id).SingleOrDefault<GetMemberDetailsResponse>();

                _logRequestResponse.LogData(string.Format("query.Where(a => a.Email_Address == {0} && a.Grp_Id == {1}).SingleOrDefault<GetMemberDetailsResponse>()", request.CustomerEmail_Address,id), "Info");

                return output;
            }
            else
            {
                if (request.Acc_Number > 0)
                {
                    var output = query.Where(a => a.Acc_Number == request.Acc_Number && a.Grp_Id == id).SingleOrDefault<GetMemberDetailsResponse>();
                    //_logRequestResponse.LogData(output.ToString(), "Debug");
                    _logRequestResponse.LogData(string.Format("query.Where(a => a.Acc_Number == {0} && a.Grp_Id == {1}).SingleOrDefault<GetMemberDetailsResponse>()", request.Acc_Number, id), "Info");
                    return output;
                }
                else
                {
                    var output = query.Where(a => a.CallerId == request.CallerId && a.PassCode == request.PassCode && a.Grp_Id == id).SingleOrDefault<GetMemberDetailsResponse>();
                    _logRequestResponse.LogData(string.Format("query.Where(a => a.CallerId == request.CallerId && a.PassCode == {0} && a.Grp_Id == {1}).SingleOrDefault<GetMemberDetailsResponse>()", request.PassCode, id), "Info");
                    //_logRequestResponse.LogData(output.ToString(), "Debug");

                    return output;
                }
            }
            
        }

        public Member_Forgot_Passcode_Response member_forgot_passcode(Member_Forgot_Passcode_Request request)
        {
            var data = this.GetMemberDetails(request);
            if (data != null)
            {
                return new Member_Forgot_Passcode_Response() { Acc_Number = data.Acc_Number, CallerId = data.CallerId, Email_Address = data.Email_Address, PassCode = data.PassCode };
            }

            return null;
        }

        public Get_Member_Minutes_Response get_member_minutes(Get_Member_Minutes_Request _request)
        {
            Get_Member_Minutes_Response response = null;
            string Grp_id = CommonRepositories.GetGroupID(_request.Group_Prefix);

            account ac = _context.accounts.Where(x => x.Acc_Number == _request.Acc_Number).FirstOrDefault();
            if (ac != null)
            {
                user_minute um = _context.user_minute.Where(x => x.Acc_Number == _request.Acc_Number && x.Grp_Id == Grp_id).FirstOrDefault();

                if (um == null)
                {
                    response = new Get_Member_Minutes_Response() { Acc_RegisMinutes = -11, Acc_GuestMinutes = -11 };
                }
                else
                {
                    int RegisteredMinutesLeft = (um.R_Seconds) - (um.R_UsedSeconds) / 60;
                    int GuestMinutesLeft = (um.G_Seconds) - (um.G_UsedSeconds) / 60;
                    response = new Get_Member_Minutes_Response() { Acc_AccountType = ac.AccountType, Acc_ExpiryDate = ac.ExpiryDate, Acc_GuestMinutes = GuestMinutesLeft, Acc_RegisMinutes = RegisteredMinutesLeft, Acc_RegisteredOn = ac.RegisteredOn, Gender = ac.Gender };
                }
            }


            return response;
        }
    }
}
