namespace ivrdating.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ivrdating.login_log")]
    public partial class login_log
    {
        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(100)]
        public string SessionNo { get; set; }

        [StringLength(30)]
        public string IPAddress { get; set; }

        [StringLength(20)]
        public string TimeIn { get; set; }

        [StringLength(20)]
        public string TimeOut { get; set; }

        [StringLength(20)]
        public string DateIn { get; set; }

        [StringLength(20)]
        public string DateOut { get; set; }

        public DateTime? LastTimeStamp { get; set; }

        [Key]
        public int LogId { get; set; }
    }
}
