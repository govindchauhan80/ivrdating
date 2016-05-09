namespace ivrdating.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ivrdating.servicesource")]
    public partial class servicesource
    {
        public int Id { get; set; }

        public int Acc_Number { get; set; }

        [Column(TypeName = "enum")]
        [Required]
        [StringLength(65532)]
        public string Grp_Id { get; set; }

        public int Source { get; set; }

        [Required]
        [StringLength(10)]
        public string AreaCode { get; set; }

        [Column(TypeName = "date")]
        public DateTime OnDate { get; set; }
    }
}
