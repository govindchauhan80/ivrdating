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
    public class Member_Forgot_Passcode_Return : ReturnBase
    {
        [DataMember]
        public Member_Forgot_Passcode_Response WsResult { get; set; }
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
    [DataContract(Namespace = "")]
    public class Add_To_User_Minute_Return : ReturnBase
    {
        [DataMember]
        public Add_To_User_Minute_Response WsResult { get; set; }
    }
    [DataContract(Namespace = "")]
    public class Add_To_Payment_Details_Return : ReturnBase
    {
        [DataMember]
        public Add_To_Payment_Details_Response WsResult { get; set; }
    }

    [DataContract(Namespace = "")]
    public class Add_To_Service_Source_Return : ReturnBase
    {
        [DataMember]
        public Add_To_Service_Source_Response WsResult { get; set; }
    }
    [DataContract(Namespace = "")]
    public class Update_Account_Return : ReturnBase
    {
        [DataMember]
        public Update_Account_Response WsResult { get; set; }
    }
    [DataContract(Namespace = "")]
    public class Update_User_Minute_Return : ReturnBase
    {
        [DataMember]
        public Update_User_Minute_Response WsResult { get; set; }
    }
    public class Validate_Return : ReturnBase
    {
        [DataMember]
        public Validate_Response WsResult { get; set; }
    }
    [DataContract(Namespace = "")]
    public class Get_Member_Minutes_Return : ReturnBase
    {
        [DataMember]
        public Get_Member_Minutes_Response WsResult { get; set; }
    }
    [DataContract(Namespace = "")]
    public class Process_Mobile_Charge_Return : ReturnBase
    {
        [DataMember]
        public Process_Mobile_Charge_Response WsResult { get; set; }
    }
    [DataContract(Namespace = "")]
    public class Insert_Login_Log_Return : ReturnBase
    {
        [DataMember]
        public Insert_Login_Log_Response WsResult { get; set; }
    }
    [DataContract(Namespace = "")]
    public class Update_Login_Log_Return : ReturnBase
    {
        [DataMember]
        public Update_Login_Log_Response WsResult { get; set; }
    }
    [DataContract(Namespace = "")]
    public class Admin_Web_Screening_Return : ReturnBase
    {
        [DataMember]
        public Admin_Web_Screening_Response WsResult { get; set; }
    }
    [DataContract(Namespace = "")]
    public class Getchargeamount_Return : ReturnBase
    {
        [DataMember]
        public Getchargeamount_Response WsResult { get; set; }
    }
    [DataContract(Namespace = "")]
    public class Delete_Completeaccount_Return : ReturnBase
    {
        [DataMember]
        public Delete_Completeaccount_Response WsResult { get; set; }
    }
    [DataContract(Namespace = "")]
    public class Read_Misc_Return : ReturnBase
    {
        [DataMember]
        public Read_Misc_Response WsResult { get; set; }
    }

    [DataContract(Namespace = "")]
    public class Set_Misc_Return : ReturnBase
    {
        [DataMember]
        public Set_Misc_Response WsResult { get; set; }
    }

    [DataContract(Namespace = "")]
    public class Set_Primary_Apiserver_Return : ReturnBase
    {
        [DataMember]
        public Set_Primary_Apiserver_Response WsResult { get; set; }
    }
    [DataContract(Namespace = "")]
    public class Check_Geo_Location_Return : ReturnBase
    {
        [DataMember]
        public Check_Geo_Location_Response WsResult { get; set; }
    }


    [DataContract(Namespace = "")]
    public class Get_Node3_Accesspoint_Ip_Return : ReturnBase
    {
        [DataMember]
        public Get_Node3_Accesspoint_Ip_Response WsResult { get; set; }
    }

    [DataContract(Namespace = "")]
    public class Update_Customer_Master_Return : Add_To_Customer_Master_Return
    {

    }

    [DataContract(Namespace = "")]
    public class Add_Complete_Paid_Account_Return : ReturnBase
    {
        [DataMember]
        public Add_Complete_Paid_Account_Response WsResult { get; set; }
    }

    [DataContract(Namespace = "")]
    public class Modify_Customer_Info_Return : ReturnBase
    {
        [DataMember]
        public Modify_Customer_Info_Response WsResult { get; set; }
    }
}
