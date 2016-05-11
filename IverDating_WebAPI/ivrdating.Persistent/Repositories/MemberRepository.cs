using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ivrdating.Domain.VM;
using ivrdating.Domain;
using ivrdating.Models;

namespace ivrdating.Persistent.Repositories
{
    public class MemberRepository
    {
        ivrdating.Domain.ivrdating _context;
        public MemberRepository()
        {
            _context = new ivrdating.Domain.ivrdating();
        }

        public GetMemberDetailsResponse GetMemberDetails(GetMemberDetailsRequest request)
        {
            // GetMemberDetailsResponse _memberDetailVM = new MemberDetailVM();
            var groupAssociation = (from ga in _context.group_association where ga.Grp_Prefix == request.Group_Prefix select ga).FirstOrDefault();

            string id = CommonRepositories.GetGroupID(request.Group_Prefix);

            var query = (from ac in _context.accounts
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

            if (!string.IsNullOrEmpty(request.CustomerEmail_Address))
            {

                return query.Where(a => a.Email_Address == request.CustomerEmail_Address && a.Grp_Id == id).SingleOrDefault<GetMemberDetailsResponse>();
            }
            else
            {
                if (request.Acc_Number > 0)
                {
                    return query.Where(a => a.Acc_Number == request.Acc_Number && a.Grp_Id == id).SingleOrDefault<GetMemberDetailsResponse>();
                }
                else
                {
                    return query.Where(a => a.CallerId == request.CallerId && a.PassCode == request.PassCode && a.Grp_Id == id).SingleOrDefault<GetMemberDetailsResponse>();
                }
            }
        }
    }
}
