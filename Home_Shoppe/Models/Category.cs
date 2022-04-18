namespace Home_Shoppe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public class Category
    {
        [Key]
        [StringLength(20)]
        public string IdCategory { get; set; }

        [Required(ErrorMessage = "NameCategory {0} is required")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "NameCategory")]
        [DataType(DataType.Text)]
        public string NameCategory { get; set; }


        public virtual ICollection<Product> Products { get; set; }
    }
}
