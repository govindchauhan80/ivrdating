using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Domain.VM
{
    public class Get_New_Acc_Number_Request : RequestBase
    {
        public string CallerId { get; set; }
    }
}
