using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Domain.VM
{
    [DataContract(Namespace ="")]
    public class Get_Member_Minutes_Response
    {
        [DataMember]
        public DateTime Acc_RegisteredOn { get; set; }
        [DataMember]
        public DateTime Acc_ExpiryDate { get; set; }
        [DataMember]
        public string Acc_AccountType { get; set; }
        [DataMember]
        public int Acc_RegisMinutes { get; set; }
        [DataMember]
        public int Acc_GuestMinutes { get; set; }
        [DataMember]
        public string Gender { get; set; }
    }
}
