using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Domain.VM
{
    [DataContract(Namespace ="")]
    public class Get_Node3_Accesspoint_Ip_Response
    {
        [DataMember]
        public string ip_address { get; set; }
    }
}
