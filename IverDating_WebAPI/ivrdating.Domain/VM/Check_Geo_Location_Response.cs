using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Domain.VM
{
    [DataContract(Namespace = "")]
    public class Check_Geo_Location_Response
    {
        [DataMember]
        public string geo_country { get; set; }
        [DataMember]
        public string geo_stateprov { get; set; }
        [DataMember]
        public string geo_city { get; set; }
        [DataMember]
        public string geo_areacode { get; set; }
    }
}
