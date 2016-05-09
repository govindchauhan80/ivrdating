using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Domain.VM
{
    public class GetMemberDetailsRequest : RequestBase
    {
        public string CustomerEmail_Address { get; set; }
        public string PassCode { get; set; }
        public int Acc_Number { get; set; }
        public string CallerId { get; set; }
    }
}
