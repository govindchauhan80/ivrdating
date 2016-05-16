using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Domain.VM
{
    [DataContract(Namespace = "")]
    public class Insert_Login_Log_Response
    {
        [DataMember]
        public string OK { get; set; }
    }
}
