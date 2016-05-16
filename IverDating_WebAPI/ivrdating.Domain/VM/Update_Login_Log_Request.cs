using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Domain.VM
{
    public class Update_Login_Log_Request:RequestBase
    {
        [Obsolete("This property has been deprecated and should no longer be used.", true)]

        public new string Group_Prefix { get; set; }

        public string Session { get; set; }
        public DateTime? DateOut { get; set; }
        public string TimeOut { get; set; }
        public DateTime? LastTimeStamp { get; set; }
    }
}
