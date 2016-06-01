using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Domain.VM
{
    public class Add_Complete_Paid_Account_Request : RequestBase
    {
        public int Acc_Number { get; set; }
        public string PassCode { get; set; }
        public DateTime? PlanExpiresOn { get; set; }
        public string AccountType { get; set; }
        public int Minutes_In_Package { get; set; }
        public DateTime? Old_Expiry { get; set; }
        public DateTime? New_Expiry { get; set; }
        public int Plan_Id { get; set; }
        public decimal Plan_Amount { get; set; }
        public int Charged_Amount { get; set; }
        public int Plan_Validity { get; set; }
        public string Package_Description { get; set; }
        public int Service_Source { get; set; }
        public string Area_Code { get; set; }
        public string CallerId { get; set; }
        public string Active0In1 { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string WebUserName { get; set; }
        public string WebPassword { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerState { get; set; }
        public string CustomerZip_Code { get; set; }
        public string CustomerCountry { get; set; }
        public string CustomerEmail_Address { get; set; }
        public string FULL_CC_NUMBER { get; set; }
        public DateTime? CC_EXPDATE { get; set; }
        public string CVC { get; set; }
        public short Response_Code { get; set; }
        public string Response_Reason_Code { get; set; }
        public string Response_Reason_Text { get; set; }
        public string Approval_Code { get; set; }
        public string AVS_Result_Code { get; set; }
        public int Transaction_Id { get; set; }
        public string Payment_Type_Text { get; set; }
        public DateTime? RegisteredDate { get; set; }
    }
}
