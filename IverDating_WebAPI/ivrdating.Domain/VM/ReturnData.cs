﻿using ivrdating.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Domain.VM
{

    [DataContract(Namespace = "")]
    public class ReturnBase
    {
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }

    }

    [DataContract(Namespace = "")]
    public class ReturnData : ReturnBase
    {
        [DataMember]
        public GetMemberDetailsResponse WsResult { get; set; }
    }

    [DataContract(Namespace = "")]
    public class Get_New_Acc_Number_Return : ReturnBase
    {
        [DataMember]
        public Get_New_Acc_Number_Response WsResult { get; set; }
    }

    [DataContract(Namespace = "")]
    public class Get_N_Activate_New_Acc_Number_Return : ReturnBase
    {
        [DataMember]
        public Get_N_Activate_New_Acc_Number_Response WsResult { get; set; }
    }
    [DataContract(Namespace = "")]
    public class Activate_Acc_Number_Return : ReturnBase
    {
        [DataMember]
        public Activate_Acc_Number_Response WsResult { get; set; }
    }
    [DataContract(Namespace = "")]
    public class Deactivate_Acc_Number_Return : ReturnBase
    {
        [DataMember]
        public Deactivate_Acc_Number_Response WsResult { get; set; }
    }

    [DataContract(Namespace = "")]
    public class Add_New_Account_Return : ReturnBase
    {
        [DataMember]
        public Add_New_Account_Response WsResult { get; set; }
    }
    [DataContract(Namespace = "")]
    public class Add_To_Customer_Master_Return : ReturnBase
    {
        [DataMember]
        public Add_To_Customer_Master_Response WsResult { get; set; }
    }
    public class Add_To_User_Minute_Return : ReturnBase
    {
        public Add_To_User_Minute_Response WsResult { get; set; }
    }

}