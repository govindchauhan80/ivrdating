using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Domain.VM
{
    public class Getchargeamount_Request : RequestBaseWithOutGp
    {
        public string Area_Code { get; set; }
        public int Plan_Id { get; set; }
    }
}
