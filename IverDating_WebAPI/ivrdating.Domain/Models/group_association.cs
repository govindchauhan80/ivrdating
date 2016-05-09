namespace ivrdating.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ivrdating.group_association")]
    public partial class group_association
    {
        [Key]
        [Column(TypeName = "enum")]
        [StringLength(65532)]
        public string Grp_Id { get; set; }

        [Required]
        [StringLength(3)]
        public string Grp_Prefix { get; set; }

        [Required]
        [StringLength(100)]
        public string Grp_Name { get; set; }
    }
}
