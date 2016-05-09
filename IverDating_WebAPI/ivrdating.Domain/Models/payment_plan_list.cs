namespace ivrdating.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ivrdating.payment_plan_list")]
    public partial class payment_plan_list
    {
        public int Id { get; set; }

        public int Payment_Plan_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public double Amount { get; set; }

        public short Validity_In_Days { get; set; }

        public short Minutes { get; set; }

        public short Bonus_Minutes_Renewal { get; set; }

        public short Bonus_Minutes_Automatic { get; set; }

        [Required]
        [StringLength(12)]
        public string Payment_Type { get; set; }

        public short New1_Recharge2 { get; set; }

        public short Default_Plan { get; set; }

        [Required]
        [StringLength(50)]
        public string FileName { get; set; }

        [Required]
        [StringLength(50)]
        public string FileName_S { get; set; }

        public short Use_In_Main_IVR { get; set; }

        public decimal ApplicableFee_Static { get; set; }

        public decimal ApplicableFee_Perc { get; set; }
    }
}
