using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Domain.VM
{
    public class Check_Geo_Location_Request: RequestBaseWithOutGp
    {
        public string Client_IP_Location { get; set; }
    }
}
