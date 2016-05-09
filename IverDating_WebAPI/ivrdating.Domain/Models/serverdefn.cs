namespace ivrdating.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ivrdating.serverdefns")]
    public partial class serverdefn
    {
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string ServerId { get; set; }

        public int PortStart { get; set; }

        public int PortStop { get; set; }

        [Required]
        [StringLength(100)]
        public string IPADDRESS { get; set; }
    }
}
