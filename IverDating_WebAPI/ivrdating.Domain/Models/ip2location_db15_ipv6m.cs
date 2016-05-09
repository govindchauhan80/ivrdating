namespace ivrdating.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ivrdating.ip2location_db15_ipv6m")]
    public partial class ip2location_db15_ipv6m
    {
        public int Id { get; set; }

        [Column(TypeName = "varbinary")]
        [Required]
        public byte[] ip_start { get; set; }

        [Column(TypeName = "varbinary")]
        [Required]
        public byte[] ip_end { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(2)]
        public string country { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(80)]
        public string country_name { get; set; }

        [Required]
        [StringLength(80)]
        public string stateprov { get; set; }

        [Required]
        [StringLength(80)]
        public string city { get; set; }

        [StringLength(30)]
        public string AreaCode { get; set; }
    }
}
