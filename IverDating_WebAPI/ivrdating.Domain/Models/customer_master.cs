namespace ivrdating.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ivrdating.customer_master")]
    public partial class customer_master
    {
        public int Id { get; set; }

        public int AId { get; set; }

        [Required]
        [StringLength(20)]
        public string First_Name { get; set; }

        [Required]
        [StringLength(20)]
        public string Last_Name { get; set; }

        [Required]
        [StringLength(60)]
        public string WebUserName { get; set; }

        [Required]
        [StringLength(10)]
        public string WebPassword { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [Required]
        [StringLength(20)]
        public string City { get; set; }

        [Required]
        [StringLength(20)]
        public string State_Name { get; set; }

        [Required]
        [StringLength(10)]
        public string Zip_Code { get; set; }

        [Required]
        [StringLength(20)]
        public string Country { get; set; }

        [Required]
        [StringLength(40)]
        public string Email_Address { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
