namespace ivrdating.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ivrdating.action_queue")]
    public partial class action_queue
    {
        public int ID { get; set; }

        public DateTime QDateTimeStamp { get; set; }

        
        //public DateTime ProcessedAt { get; set; }

        [Column(TypeName = "enum")]
        [Required]
        [StringLength(65532)]
        public string Function1Table2 { get; set; }

        [Required]
        [StringLength(50)]
        public string FuncTable_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Field_Name { get; set; }

        public int Acc_Number { get; set; }

        [Column(TypeName = "enum")]
        [Required]
        [StringLength(65532)]
        public string Grp_Id { get; set; }

        public int Port { get; set; }

        [Required]
        [StringLength(200)]
        public string WhereClause { get; set; }

        [Required]
        [StringLength(20)]
        public string Action { get; set; }

        [Column(TypeName = "enum")]
        [Required]
        [StringLength(65532)]
        public string Q0A1S2F3 { get; set; }
    }
}
