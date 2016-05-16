using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Domain.VM
{
    public class Delete_Completeaccount_Request:RequestBase
    {
        public int Acc_Number { get; set; }
    }
}
