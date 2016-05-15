using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Domain.VM
{
    public class Add_To_Service_Source_Request:RequestBase
    {
        public int Acc_Number { get; set; }
        public int Service_Source { get; set; }
        public string Area_Code { get; set; }
        public DateTime? RegisteredDate { get; set; }
    }
}
