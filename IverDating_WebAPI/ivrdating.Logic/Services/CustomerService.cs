using ivrdating.Persistent.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ivrdating.Domain.VM;

namespace ivrdating.Logic.Services
{
    public class CustomerService
    {
        CustomerRepository _customerRepository;
        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
        }

        public Add_To_Customer_Master_Return Add_To_Customer_Master(Add_To_Customer_Master_Request _request)
        {
            string validRequest = CommonRepositories.ValidateRequest(_request);
            if (!validRequest.Equals("OK"))
            {

                return new Add_To_Customer_Master_Return() { Count = 0, ErrorMessage = validRequest, WsResult = null };
            }
            if (!string.IsNullOrEmpty(_request.CustomerEmail_Address) && !CommonRepositories.IsValidEmailAddress(_request.CustomerEmail_Address))
            {
                return new Add_To_Customer_Master_Return() { Count = 0, ErrorMessage = "Invalid email address", WsResult = null };
            }
            if (_request.Acc_Number <= 0)
            {
                return new Add_To_Customer_Master_Return() { Count = 0, ErrorMessage = "Account_Number not define", WsResult = null };
            }
            if (_request.RegisteredDate == null)
            {
                _request.RegisteredDate = DateTime.Now;
            }

            try
            {
                Add_To_Customer_Master_Response data = _customerRepository.Add_To_Customer_Master(_request);

                if (data != null)
                {
                    return new Add_To_Customer_Master_Return() { Count = 1, ErrorMessage = null, WsResult = data };
                }

                else
                {
                    return new Add_To_Customer_Master_Return() { Count = 0, ErrorMessage = "", WsResult = null };
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "Account Number does not exist in account table" || ex.Message.ToString().Contains("Validation failed for one or more entities"))
                {
                    return new Add_To_Customer_Master_Return() { Count = 0, ErrorMessage = ex.Message, WsResult = null };
                }
                else
                {
                    throw ex;
                }
            }
        }
    }
}
