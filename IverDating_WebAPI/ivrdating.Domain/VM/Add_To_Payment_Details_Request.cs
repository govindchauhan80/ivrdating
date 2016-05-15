using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Domain.VM
{
   public class Add_To_Payment_Details_Request:RequestBase
    {
        public DateTime? New_Expiry { get; set; }
        public DateTime? Old_Expiry { get; set; }
        public int Plan_Id { get; set; }
        public string Plan_Amount { get; set; }
        public int Plan_Validity { get; set; }
        public int Minutes_In_Package { get; set; }
        public string Package_Description { get; set; }
        public string FULL_CC_NUMBER { get; set; }
        public string CC_EXPDATE { get; set; }
        public string CVC { get; set; }
        public short Response_Code { get; set; }
        public string Response_Reason_Code { get; set; }
        public string Response_Reason_Text { get; set; }
        public string Approval_Code { get; set; }
        public string AVS_Result_Code { get; set; }
        public string Transaction_Id { get; set; }
        public string Payment_Type_Text { get; set; }
        public int Acc_Number { get; set; }
        public DateTime? RegisteredDate { get; set; }
        public int Charged_Amount { get; set; }
        public string CallerId { get; set; }
    }
}
