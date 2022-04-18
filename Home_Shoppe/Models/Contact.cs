namespace Home_Shoppe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contact")]
    public class Contact
    {
        [Key]
        [StringLength(20)]
        public string IdContect { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string CompanyName { get; set; }

        [DataType(DataType.Text)]
        public string Subject { get; set; }
    }
}
