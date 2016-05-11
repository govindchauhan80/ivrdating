using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Domain.VM
{
    public class Add_New_Account_Request : RequestBase
    {
        public int Acc_Number { get; set; }
        public string PassCode { get; set; }
        public string CallerId { get; set; }
        public DateTime? RegisteredDate { get; set; }
        public DateTime? PlanExpiresOn { get; set; }
        public string AccountType { get; set; }
        public string Active0In1 { get; set; }
    }
}
