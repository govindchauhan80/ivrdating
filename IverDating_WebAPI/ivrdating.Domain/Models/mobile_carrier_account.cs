namespace ivrdating.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ivrdating.mobile_carrier_account")]
    public partial class mobile_carrier_account
    {
        public int Id { get; set; }

        public int Acc_Number { get; set; }

        [Required]
        [StringLength(4)]
        public string PassCode { get; set; }

        [Required]
        [StringLength(15)]
        public string Ani { get; set; }

        [Column(TypeName = "enum")]
        [Required]
        [StringLength(65532)]
        public string Grp_Id { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime LastCalledOn { get; set; }

        public DateTime ExpiryDate { get; set; }
    }
}
