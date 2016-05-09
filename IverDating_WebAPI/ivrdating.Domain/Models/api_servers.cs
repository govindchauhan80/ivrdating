namespace ivrdating.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ivrdating.api_servers")]
    public partial class api_servers
    {
        [Key]
        public int API_Id { get; set; }

        [Required]
        [StringLength(20)]
        public string ip_address { get; set; }

        [Column(TypeName = "uint")]
        public long ip_priority { get; set; }
    }
}
