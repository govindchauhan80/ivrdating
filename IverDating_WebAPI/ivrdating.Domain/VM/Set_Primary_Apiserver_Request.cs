using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Domain.VM
{
   public class Set_Primary_Apiserver_Request: RequestBaseWithOutGp
    {
        public string ActiveServerIP { get; set; }
    }
}
