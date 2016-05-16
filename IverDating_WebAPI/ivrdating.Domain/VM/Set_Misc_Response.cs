using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Domain.VM
{
    [DataContract(Namespace ="")]
   public class Set_Misc_Response
    {
       [DataMember]
        public string Status { get; set; }
    }
}
