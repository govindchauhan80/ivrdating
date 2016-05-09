using ivrdating.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Domain.VM
{
    [DataContract(Namespace = "")]
    public class ReturnData
    {
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }
        [DataMember]
        public GetMemberDetailsResponse WsResult { get; set; }
    }
}
