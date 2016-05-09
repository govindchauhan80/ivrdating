namespace ivrdating.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ivrdating.liveusers")]
    public partial class liveuser
    {
        public int Id { get; set; }

        public int Acc_Number { get; set; }

        [Column(TypeName = "enum")]
        [Required]
        [StringLength(65532)]
        public string Grp_Id { get; set; }

        [Column(TypeName = "enum")]
        [Required]
        [StringLength(65532)]
        public string AcctType { get; set; }

        public DateTime LoginOn { get; set; }

        [Column(TypeName = "enum")]
        [Required]
        [StringLength(65532)]
        public string Gender { get; set; }

        [Column(TypeName = "enum")]
        [Required]
        [StringLength(65532)]
        public string LookingFor { get; set; }

        public int Port { get; set; }

        [Column(TypeName = "enum")]
        [Required]
        [StringLength(65532)]
        public string CrossConnectFlag { get; set; }

        [Column(TypeName = "enum")]
        [Required]
        [StringLength(65532)]
        public string Request2Connect { get; set; }

        [Required]
        [StringLength(20)]
        public string Ani { get; set; }

        [Required]
        [StringLength(20)]
        public string Dnis { get; set; }

        public DateTime LastRequestedAt { get; set; }

        [Column(TypeName = "enum")]
        [Required]
        [StringLength(65532)]
        public string Profile1Msg2 { get; set; }

        public int a_Id { get; set; }

        public DateTime a_RegisteredOn { get; set; }

        [Column(TypeName = "date")]
        public DateTime a_ExpiryDate { get; set; }

        public DateTime a_AccRegisteredOn { get; set; }

        [Column(TypeName = "enum")]
        [Required]
        [StringLength(65532)]
        public string a_AccountType { get; set; }

        public DateTime a_LastLogon { get; set; }

        public DateTime c_Last_Change { get; set; }

        [Column(TypeName = "enum")]
        [Required]
        [StringLength(65532)]
        public string c_Screen0123 { get; set; }

        [Column(TypeName = "enum")]
        [Required]
        [StringLength(65532)]
        public string c_ProfileListen10 { get; set; }

        public short c_ANI_StateId { get; set; }

        public short c_DNIS_StateId { get; set; }

        public short c_ANI_CityId { get; set; }

        public short c_DNIS_CityId { get; set; }

        [Column(TypeName = "enum")]
        [Required]
        [StringLength(65532)]
        public string ScreeningNotification { get; set; }

        [Column(TypeName = "enum")]
        [Required]
        [StringLength(65532)]
        public string ProfileExists1 { get; set; }

        public int Market_Id { get; set; }

        public int Priority { get; set; }

        public int Hub_Definition_Id { get; set; }

        public int Hub_Id { get; set; }
    }
}
