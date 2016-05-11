using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Domain.VM
{

    [DataContract(Namespace = "")]
    public class Add_To_Customer_Master_Response
    {
        [DataMember]
        public int Acc_Number { get; set; }
    }
}
