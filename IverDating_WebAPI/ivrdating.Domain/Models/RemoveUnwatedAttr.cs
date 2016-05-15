using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Domain
{
    #region paymentdetail
    [MetadataType(typeof(Custom_paymentdetail))]
    public partial class paymentdetail
    {
    }
    public class Custom_paymentdetail
    {
        public string pd_callerid { get; set; }
        public string Dnis { get; set; }
        public string TollFree { get; set; }
    }

    #endregion paymentdetail

    #region  public partial class account
    [MetadataType(typeof(Account_Custom))]
    public partial class account
    {

    }
    public class Account_Custom
    {
        public string PassCode { get; set; }
        public string callerid { get; set; }
        public string Gender { get; set; }
        public string LookingFor { get; set; }
        public string ScreenStatus_0N2D1S3Ok { get; set; }
        public string AdminScreening_0Q1Ok { get; set; }
        public string ProfileExists1 { get; set; }
        public string Callout_Flag { get; set; }
        public string Callout_No { get; set; }
        public string Callout_Start { get; set; }
        public string Callout_End { get; set; }
        public string DeadAccount1 { get; set; }
        public string Active0In1 { get; set; }
        public string AccountType { get; set; }
    }
    #endregion public partial class account
}
