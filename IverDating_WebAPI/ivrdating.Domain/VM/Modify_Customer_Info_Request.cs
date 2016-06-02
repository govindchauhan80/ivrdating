using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Domain.VM
{
    public class Modify_Customer_Info_Request : RequestBase
    {
        public int Acc_Number { get; set; }
        public string PassCode { get; set; }
        public string CallerId { get; set; }
        public string WebPassword { get; set; }
    }
}
