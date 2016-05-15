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

        public Add_To_Service_Source_Response Add_To_Service_Source(Add_To_Service_Source_Request _request)
        {
            Add_To_Service_Source_Response response = null;

            string Grp_id = CommonRepositories.GetGroupID(_request.Group_Prefix);

            servicesource sc = new servicesource();

            sc.Acc_Number = _request.Acc_Number;
            sc.AreaCode = _request.Area_Code;
            sc.Grp_Id = Grp_id;
            sc.OnDate = (DateTime)_request.RegisteredDate;
            sc.Source = _request.Service_Source;

            _context.servicesources.Add(sc);
            _context.SaveChanges();

            response = new Add_To_Service_Source_Response() { Acc_Number = _request.Acc_Number };

            return response;
        }

        public Update_User_Minute_Response update_user_minute(Update_User_Minute_Request _request)
        {
            string Grp_id = CommonRepositories.GetGroupID(_request.Group_Prefix);
            user_minute um = _context.user_minute.Where(x => x.Acc_Number == _request.Acc_Number && x.Grp_Id == Grp_id).FirstOrDefault();
            if (um != null)
            {
                um.R_Seconds = _request.Minutes_In_Package * 60;
                um.LastDateTimeStamp = (DateTime)_request.RegisteredDate;
            }
            else {
                user_minute new_Um = new user_minute();
                new_Um.Acc_Number = _request.Acc_Number;
                new_Um.Grp_Id = Grp_id;
                new_Um.G_Seconds = 0;
                new_Um.G_UsedSeconds = 0;
                new_Um.R_Seconds = _request.Minutes_In_Package * 60;
                new_Um.R_UsedSeconds = 0;
                new_Um.CreateDateTimeStamp = DateTime.Now;
                new_Um.LastDateTimeStamp = DateTime.Now;
                _context.user_minute.Add(new_Um);
            }
            _context.SaveChanges();
            return new Update_User_Minute_Response() {Acc_Number=_request.Acc_Number };
        }
    }
}
