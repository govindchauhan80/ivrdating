namespace ivrdating.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ivrdating.acc_number_web")]
    public partial class acc_number_web
    {
        public int Id { get; set; }

        public int Acc_Number { get; set; }

        [Column(TypeName = "enum")]
        [Required]
        [StringLength(65532)]
        public string Grp_Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Subscriber_Mobile { get; set; }

        public int ShortCode { get; set; }

        public DateTime AllocatedOn { get; set; }
    }
}
