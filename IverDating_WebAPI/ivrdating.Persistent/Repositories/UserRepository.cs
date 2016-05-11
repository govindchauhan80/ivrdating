using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ivrdating.Domain.VM;
using ivrdating.Domain;

namespace ivrdating.Persistent.Repositories
{
    public class UserRepository
    {

        ivrdating.Domain.ivrdating _context;
        public UserRepository()
        {
            _context = new Domain.ivrdating();
        }
        public Add_To_User_Minute_Response Add_To_User_Minute(Add_To_User_Minute_Request _request)
        {
            Add_To_User_Minute_Response response = null;
            string Grp_id = CommonRepositories.GetGroupID(_request.Group_Prefix);
            user_minute um = new user_minute();
            um.Acc_Number = _request.Acc_Number;
            um.R_Seconds = _request.Seconds_In_Package * 60;
            um.Grp_Id = Grp_id;
            um.CreateDateTimeStamp = _request.RegisteredDate;
            um.LastDateTimeStamp = _request.RegisteredDate;

            _context.user_minute.Add(um);
            _context.SaveChanges();
            response = new Add_To_User_Minute_Response() { Acc_Number = _request.Acc_Number };
            return response;
        }
    }
}
