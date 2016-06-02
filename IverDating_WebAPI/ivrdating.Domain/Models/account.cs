namespace ivrdating.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ivrdating.account")]
    public partial class account
    {
        public int Id { get; set; }

        public int Acc_Number { get; set; }

        [Required]
        [StringLength(4)]
        public string PassCode { get; set; }

        [Required]
        [StringLength(15)]
        public string callerid { get; set; }

        public DateTime RegisteredOn { get; set; }

        [Column(TypeName = "date")]
        public DateTime ExpiryDate { get; set; }

        [Column(TypeName = "enum")]
        [Required]
        [StringLength(65532)]
        public string Grp_Id { get; set; }

        public DateTime AccRegisteredOn { get; set; }

        [Column(TypeName = "enum")]
        [Required]
        [StringLength(65532)]
        public string AccountType { get; set; }

        [Column(TypeName = "enum")]
        [Required]
        [StringLength(65532)]
        public string Gender { get; set; }

        [Column(TypeName = "enum")]
        [Required]
        [StringLength(65532)]
        public string LookingFor { get; set; }

        [Column(TypeName = "enum")]
        [Required]
        [StringLength(65532)]
        public string ScreenStatus_0N2D1S3Ok { get; set; }

        [Column(TypeName = "enum")]
        [Required]
        [StringLength(65532)]
        public string AdminScreening_0Q1Ok { get; set; }

        public int ANI_StateId { get; set; }

        public int DNIS_StateId { get; set; }

        public int ANI_CityId { get; set; }

        public int DNIS_CityId { get; set; }

        [Column(TypeName = "enum")]
        [Required]
        [StringLength(65532)]
        public string ProfileExists1 { get; set; }

        public int Market_Id { get; set; }

        public int HUB_Definition_Id { get; set; }

        [Column(TypeName = "enum")]
        [Required]
        [StringLength(65532)]
        public string Callout_Flag { get; set; }

        [Required]
        [StringLength(15)]
        public string Callout_No { get; set; }

        [Required]
        [StringLength(10)]
        public string Callout_Start { get; set; }

        [Required]
        [StringLength(10)]
        public string Callout_End { get; set; }

        //public DateTime LastLogon { get; set; }

        //public DateTime LastGreetingRecordedOn { get; set; }

        [Column(TypeName = "enum")]
        [Required]
        [StringLength(65532)]
        public string Active0In1 { get; set; }

        [Column(TypeName = "enum")]
        [Required]
        [StringLength(65532)]
        public string DeadAccount1 { get; set; }

        public long NumberOfCalls { get; set; }

        public long TotalCallDuration { get; set; }
    }
}
