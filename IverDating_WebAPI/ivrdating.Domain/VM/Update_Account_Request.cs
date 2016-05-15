using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Domain.VM
{
    public class Update_Account_Request : RequestBase
    {
        public int Acc_Number { get; set; }
        public string CallerID { get; set; }
        public string AccountType { get; set; }
        public string Active0In1 { get; set; }
        public DateTime? New_Expiry { get; set; }
    }
}
