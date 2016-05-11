using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Domain.VM
{
    public class Add_To_Customer_Master_Request:RequestBase
    {
        public int Acc_Number { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string WebUserName { get; set; }
        public string WebPassword { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerState { get; set; }
        public string CustomerZip_Code { get; set; }
        public string CustomerCountry { get; set; }
        public string CustomerEmail_Address { get; set; }
        public DateTime? RegisteredDate { get; set; }
    }
}
