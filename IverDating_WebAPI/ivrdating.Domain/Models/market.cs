namespace ivrdating.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ivrdating.market")]
    public partial class market
    {
        public int Id { get; set; }

        public int Hub_Definition_Id { get; set; }

        [Required]
        [StringLength(6)]
        public string ShortName { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public short AreaCode { get; set; }

        [Required]
        [StringLength(8)]
        public string TimeZone { get; set; }

        [Required]
        [StringLength(8)]
        public string GMT_Offset { get; set; }

        public int City_Id { get; set; }

        public int State_Id { get; set; }

        public int Country_Id { get; set; }

        public int TimeZone_Id { get; set; }

        public short Language_E1_S2 { get; set; }

        public short Priority { get; set; }

        public decimal Tax_Perc { get; set; }

        [Required]
        [StringLength(20)]
        public string AccessNumber_ANI { get; set; }

        public short Default_Market { get; set; }
    }
}
