﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Domain.VM
{
    [DataContract(Namespace = "")]
    public class Admin_Web_Screening_Response
    {
        [DataMember]
        public string OK { get; set; }
    }
}