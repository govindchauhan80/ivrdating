using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Domain.VM
{
    public class Add_To_User_Minute_Request : RequestBase
    {
        public int Acc_Number { get; set; }
        public int Minutes_In_Package { get; set; }
        public DateTime? RegisteredDate { get; set; }
    }
}
