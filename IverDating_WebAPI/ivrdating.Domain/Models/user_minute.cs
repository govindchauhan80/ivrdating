namespace ivrdating.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ivrdating.user_minute")]
    public partial class user_minute
    {
        public int Id { get; set; }

        public int Acc_Number { get; set; }

        [Column(TypeName = "enum")]
        [Required]
        [StringLength(65532)]
        public string Grp_Id { get; set; }

        public int G_Seconds { get; set; }

        public int G_UsedSeconds { get; set; }

        public int R_Seconds { get; set; }

        public int R_UsedSeconds { get; set; }

        public int Balance_Seconds { get; set; }

        public int Balance_Minutes { get; set; }

        public int Released_Minutes { get; set; }

        public DateTime? CreateDateTimeStamp { get; set; }

        public DateTime? LastDateTimeStamp { get; set; }

        [StringLength(100)]
        public string Description { get; set; }
    }
}
