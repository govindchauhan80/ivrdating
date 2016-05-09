namespace ivrdating.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ivrdating.misc")]
    public partial class misc
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string SettingName { get; set; }

        [Required]
        [StringLength(100)]
        public string SettingValue { get; set; }

        public short ForWeb { get; set; }
    }
}
