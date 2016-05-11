using ivrdating.Domain;
using ivrdating.Domain.VM;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ivrdating.Persistent.Repositories
{
    public class CustomerRepository
    {
        ivrdating.Domain.ivrdating _context;
        public CustomerRepository()
        {
            _context = new ivrdating.Domain.ivrdating();
        }

        public Add_To_Customer_Master_Response Add_To_Customer_Master(Add_To_Customer_Master_Request _request)
        {
            Add_To_Customer_Master_Response response = null;

            string Grp_id = CommonRepositories.GetGroupID(_request.Group_Prefix);
            int l_AId = 0;
            string l_PassCode = "";

            account ac = _context.accounts.Where(x => x.Acc_Number == _request.Acc_Number && x.Grp_Id == Grp_id).FirstOrDefault();

            if (ac != null)
            {
                l_AId = ac.Id;
                l_PassCode = ac.PassCode;

                //CHECK Customer_Master Table

                customer_master csm = _context.customer_master.Where(x => x.AId == l_AId).FirstOrDefault();
                if (csm != null)
                {
                    //Record found, update it
                    if (!string.IsNullOrEmpty(_request.First_Name))
                    {
                        csm.First_Name = _request.First_Name;
                    }
                    if (!string.IsNullOrEmpty(_request.Last_Name))
                    {
                        csm.Last_Name = _request.Last_Name;
                    }
                    if (!string.IsNullOrEmpty(_request.CustomerAddress))
                    {
                        csm.Address = _request.CustomerAddress;
                    }

                    if (!string.IsNullOrEmpty(_request.CustomerCity))
                    {
                        csm.City = _request.CustomerCity;
                    }
                    if (!string.IsNullOrEmpty(_request.CustomerState))
                    {
                        csm.State_Name = _request.CustomerState;
                    }
                    if (!string.IsNullOrEmpty(_request.CustomerZip_Code))
                    {
                        csm.Zip_Code = _request.CustomerZip_Code;
                    }
                    if (!string.IsNullOrEmpty(_request.CustomerCountry))
                    {
                        csm.Country = _request.CustomerCountry.Length > 20 ? _request.CustomerCountry.Substring(20) : _request.CustomerCountry;
                    }
                    _context.SaveChanges();
                }
                else {
                    //Record not found, add it

                    customer_master csAdd = new customer_master();
                    csAdd.Address = string.IsNullOrEmpty(_request.CustomerAddress) ? " " : _request.CustomerAddress;
                    csAdd.AId = l_AId;
                    csAdd.City = string.IsNullOrEmpty(_request.CustomerCity) ? " " : _request.CustomerCity;
                    csAdd.Country= string.IsNullOrEmpty(_request.CustomerCountry) ? " " : _request.CustomerCountry.Length>20?_request.CustomerCountry.Substring(20):_request.CustomerCountry;
                    csAdd.Email_Address= string.IsNullOrEmpty(_request.CustomerEmail_Address) ? " " : _request.CustomerEmail_Address;
                    csAdd.First_Name= string.IsNullOrEmpty(_request.First_Name) ? " " : _request.First_Name;
                    csAdd.Last_Name= string.IsNullOrEmpty(_request.Last_Name) ? " " : _request.Last_Name;
                    csAdd.RegisteredOn = (DateTime)_request.RegisteredDate;
                    csAdd.State_Name= string.IsNullOrEmpty(_request.CustomerState) ? " " : _request.CustomerState;
                    csAdd.WebPassword= string.IsNullOrEmpty(_request.WebPassword) ? " " : _request.WebPassword;
                    csAdd.WebUserName= string.IsNullOrEmpty(_request.WebUserName) ? " " : _request.WebUserName;
                    csAdd.Zip_Code= string.IsNullOrEmpty(_request.CustomerZip_Code) ? " " : _request.CustomerZip_Code;

                    _context.customer_master.Add(csAdd);
                    _context.SaveChanges();
                }

            }
            else {
                throw new Exception("Account Number does not exist in account table");
            }
            response = new Add_To_Customer_Master_Response() { Acc_Number = _request.Acc_Number };
            return response;
        }
    }
}
