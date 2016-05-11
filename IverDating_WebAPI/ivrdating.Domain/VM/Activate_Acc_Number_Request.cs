using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Domain.VM
{

    public class Activate_Acc_Number_Request : RequestBase
    {
        public int Acc_Number { get; set; }
    }
}
