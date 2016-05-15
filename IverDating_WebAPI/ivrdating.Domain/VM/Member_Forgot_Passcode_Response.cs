using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Domain.VM
{
    [DataContract(Namespace = "")]
    public class Member_Forgot_Passcode_Response
    {
        [DataMember]
        public int Acc_Number { get; set; }
        [DataMember]
        public string PassCode { get; set; }
        [DataMember]
        public string CallerId { get; set; }
        [DataMember]
        public string Email_Address { get; set; }
    }
}
