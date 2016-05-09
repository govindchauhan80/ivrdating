using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Domain.VM
{
    public class RequestBase
    {
        public string AuthKey { get; set; }
        public string WS_UserName { get; set; }
        public string WS_Password { get; set; }
        public string Group_Prefix { get; set; }
    }
}
