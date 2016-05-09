namespace ivrdating.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ivrdating.paymentdetails")]
    public partial class paymentdetail
    {
        public int Id { get; set; }

        public int Acc_Number { get; set; }

        [Column(TypeName = "enum")]
        [Required]
        [StringLength(65532)]
        public string Grp_Id { get; set; }

        public DateTime RegistrationOn { get; set; }

        [Column(TypeName = "date")]
        public DateTime LastExpiry { get; set; }

        [Column(TypeName = "date")]
        public DateTime NewExpiry { get; set; }

        public int PlanTakenID { get; set; }

        [StringLength(1)]
        public string FIRST_ONE_CC { get; set; }

        [StringLength(4)]
        public string LAST_FOUR_CC { get; set; }

        [StringLength(6)]
        public string EXP_DATE { get; set; }

        [StringLength(50)]
        public string FULL_CC_NUMBER { get; set; }

        [StringLength(50)]
        public string CVC { get; set; }

        [StringLength(10)]
        public string ZipCode { get; set; }

        public short ResponseCode { get; set; }

        [Required]
        [StringLength(200)]
        public string ResponseReasonCode { get; set; }

        [Required]
        [StringLength(200)]
        public string ResponseText { get; set; }

        [Required]
        [StringLength(20)]
        public string ApprovalCode { get; set; }

        [Required]
        [StringLength(20)]
        public string AVSResultCode { get; set; }

        [Required]
        [StringLength(20)]
        public string TransactionID { get; set; }

        [StringLength(50)]
        public string registeredby { get; set; }

        [Required]
        [StringLength(10)]
        public string Amount { get; set; }

        public decimal Tax_Perc_Amount { get; set; }

        public decimal AppFee_Static_Amount { get; set; }

        public decimal AppFee_Perc_Amount { get; set; }

        public int packagevalidity { get; set; }

        public int MinInPackage { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [Required]
        [StringLength(15)]
        public string pd_callerid { get; set; }

        public int Market_Id { get; set; }

        public long Archieve_AccNumber { get; set; }

        [Required]
        [StringLength(20)]
        public string Dnis { get; set; }

        [Required]
        [StringLength(20)]
        public string TollFree { get; set; }

        public DateTime TollFree_DateStamp { get; set; }

        [Required]
        [StringLength(200)]
        public string Source_Description { get; set; }
    }
}
