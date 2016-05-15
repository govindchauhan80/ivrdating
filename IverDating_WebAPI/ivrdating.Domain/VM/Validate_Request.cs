using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Domain.VM
{
    public class Validate_Request:RequestBase
    {
        public int Acc_Number { get; set; }
        public string PassCode { get; set; }
    }
}
