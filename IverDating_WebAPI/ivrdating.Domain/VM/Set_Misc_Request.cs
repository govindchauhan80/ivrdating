using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Domain.VM
{
   public class Set_Misc_Request: RequestBaseWithOutGp
    {
        public string SettingName { get; set; }
        public string SettingValue { get; set; }
    }
}
