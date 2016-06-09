using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Domain.VM
{
    public class Update_Login_Log_Request: RequestBaseWithOutGp
    {
       
        public string Session { get; set; }
        public string DateOut { get; set; }
        public string TimeOut { get; set; }
        public string LastTimeStamp { get; set; }
    }
}
