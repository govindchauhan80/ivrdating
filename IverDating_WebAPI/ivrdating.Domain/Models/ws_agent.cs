namespace ivrdating.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ivrdating.ws_agent")]
    public partial class ws_agent
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string WS_Username { get; set; }

        [Required]
        [StringLength(50)]
        public string WS_Password { get; set; }

        [Required]
        [StringLength(50)]
        public string AuthKey { get; set; }

        [Required]
        [StringLength(50)]
        public string IP_Address { get; set; }

        public DateTime First_Access_On { get; set; }

        public DateTime Last_Access_On { get; set; }
    }
}
