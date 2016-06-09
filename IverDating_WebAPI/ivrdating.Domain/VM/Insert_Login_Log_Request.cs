using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Domain.VM
{
    public class Insert_Login_Log_Request : RequestBaseWithOutGp
    {
        
        public string Session { get; set; }
        public string CC_UserName { get; set; }
        public string CC_IPAddress { get; set; }
        public string DateIn { get; set; }
        public string TimeIn { get; set; }
        public DateTime? LastTimeStamp { get; set; }
    }
}
