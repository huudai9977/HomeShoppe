namespace Home_Shoppe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductTag")]
    public class ProductTag
    {
        [Key]
        [StringLength(20)]
        public string IdProductTag { get; set; }

        [StringLength(20)]
        public string IdProduct { get; set; }

        [StringLength(50)]
        public string Tag { get; set; }

        public virtual Product Product { get; set; }
    }
}
