using ivrdating.Domain;
using ivrdating.Domain.VM;
using ivrdating.Log;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace ivrdating.Persistent.Repositories
{
    public class CustomerRepository
    {
        ivrdating.Domain.ivrdating _context;
        LogRequestResponse _logRequestResponse;
        public CustomerRepository()
        {
            _context = new ivrdating.Domain.ivrdating();

            _logRequestResponse = new LogRequestResponse();
            if (CommonRepositories.debugMode.Equals("On", StringComparison.OrdinalIgnoreCase))
                _context.Database.Log = s => _logRequestResponse.LogData(s, "Warn");
        }

        public Add_To_Customer_Master_Response Add_To_Customer_Master(Add_To_Customer_Master_Request _request)
        {
            _context.Configuration.ValidateOnSaveEnabled = false;
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
                    bool isOneRecUpdated = false;
                    //Record found, update it
                    if (!string.IsNullOrEmpty(_request.First_Name))
                    {
                        csm.First_Name = _request.First_Name;
                        isOneRecUpdated = true;
                    }
                    if (!string.IsNullOrEmpty(_request.Last_Name))
                    {
                        csm.Last_Name = _request.Last_Name;
                        isOneRecUpdated = true;
                    }
                    if (!string.IsNullOrEmpty(_request.CustomerAddress))
                    {
                        csm.Address = _request.CustomerAddress;
                        isOneRecUpdated = true;
                    }

                    if (!string.IsNullOrEmpty(_request.CustomerCity))
                    {
                        csm.City = _request.CustomerCity;
                        isOneRecUpdated = true;
                    }
                    if (!string.IsNullOrEmpty(_request.CustomerState))
                    {
                        csm.State_Name = _request.CustomerState;
                        isOneRecUpdated = true;
                    }
                    if (!string.IsNullOrEmpty(_request.CustomerZip_Code))
                    {
                        csm.Zip_Code = _request.CustomerZip_Code;
                        isOneRecUpdated = true;
                    }
                    if (!string.IsNullOrEmpty(_request.CustomerCountry))
                    {

                        csm.Country = _request.CustomerCountry.Length > 20 ? _request.CustomerCountry.Substring(0, 20) : _request.CustomerAddress;
                        isOneRecUpdated = true;
                    }
                    if (!string.IsNullOrEmpty(_request.CustomerEmail_Address))
                    {
                        csm.Email_Address = _request.CustomerEmail_Address;
                        isOneRecUpdated = true;
                    }
                    if (!string.IsNullOrEmpty(_request.WebPassword))
                    {
                        csm.WebPassword = _request.WebPassword;
                        isOneRecUpdated = true;
                    }

                   // _context.SaveChanges();
                    if (isOneRecUpdated)
                    {
                        //csm.ModifiedOn = DateTime.Now.ToString("yyyy/mm/dd hh:mm:ss");
                        csm.RegisteredOn = Convert.ToDateTime(((DateTime)_request.RegisteredDate).ToString("yyyy/MM/dd"));
                        
                    }

                    _context.SaveChanges();
                    if (isOneRecUpdated)
                    {
                        using (var con = new ivrdating.Domain.ivrdating())
                        {
                            int rs = con.Database.ExecuteSqlCommand("update customer_master set ModifiedOn = @mod where AId = @id", new object[] { new MySqlParameter("@mod", DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss")), new MySqlParameter("@id", l_AId) });
                        }
                    }
                }
                else
                {
                    //Record not found, add it

                    customer_master csAdd = new customer_master();
                    csAdd.Address = string.IsNullOrEmpty(_request.CustomerAddress) ? "" : _request.CustomerAddress;
                    csAdd.AId = l_AId;
                    csAdd.City = string.IsNullOrEmpty(_request.CustomerCity) ? "" : _request.CustomerCity;
                    csAdd.Country = string.IsNullOrEmpty(_request.CustomerCountry) ? "" : _request.CustomerCountry.Length > 20 ? _request.CustomerCountry.Substring(20) : _request.CustomerCountry;
                    csAdd.Email_Address = string.IsNullOrEmpty(_request.CustomerEmail_Address) ? "" : _request.CustomerEmail_Address;
                    csAdd.First_Name = string.IsNullOrEmpty(_request.First_Name) ? "" : _request.First_Name;
                    csAdd.Last_Name = string.IsNullOrEmpty(_request.Last_Name) ? "" : _request.Last_Name;
                    csAdd.RegisteredOn = (DateTime)_request.RegisteredDate;
                    csAdd.State_Name = string.IsNullOrEmpty(_request.CustomerState) ? "" : _request.CustomerState;
                    csAdd.WebPassword = string.IsNullOrEmpty(_request.WebPassword) ? "" : _request.WebPassword;
                    csAdd.WebUserName = string.IsNullOrEmpty(_request.WebUserName) ? "" : _request.WebUserName;
                    csAdd.Zip_Code = string.IsNullOrEmpty(_request.CustomerZip_Code) ? "" : _request.CustomerZip_Code;

                    _context.customer_master.Add(csAdd);
                    _context.SaveChanges();
                }

            }
            else
            {
                throw new Exception("Account Number does not exist in account table");
            }
            response = new Add_To_Customer_Master_Response() { Acc_Number = _request.Acc_Number };
            return response;
        }
    }
}
