﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Domain.VM
{
    [DataContract(Namespace ="")]
    public class Read_Misc_Response
    {
        [DataMember]
        public string Setting { get; set; }
    }
}