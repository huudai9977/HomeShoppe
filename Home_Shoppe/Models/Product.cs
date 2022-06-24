namespace Home_Shoppe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public class Product
    {
        [Key]
        [StringLength(20)]
        public string IdProduct { get; set; }

        [StringLength(20)]
        public string IdCategory { get; set; }


        public string NameProduct { get; set; }

        [DefaultValue(0)]
        public double? Price { get; set; }

        [DataType(DataType.Text)]
        public string ProductDetails { get; set; }

        [DataType(DataType.Text)]
        public string Description { get; set; }

        [DefaultValue(0)]
        public int Status { get; set; }

        [DefaultValue("N'New'")] 
        public String New { get; set; }

        [DefaultValue(0)]
        public int Views { get; set; }

        [DefaultValue(0)]
        public int Sold { get; set; }

        [StringLength(50)]
        public string Image1 { get; set; }

        [StringLength(50)]
        public string Image2 { get; set; }

        [StringLength(50)]
        public string Image3 { get; set; }

        [StringLength(50)]
        public string Image4 { get; set; }

        [StringLength(50)]
        public string Image5 { get; set; }

        [StringLength(50)]
        public string Image6 { get; set; }

        public virtual ICollection<ProductTag> ProductTags { get; set; }

        public virtual ICollection<ProductReview> ProductReviews { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }

        public virtual Category Category { get; set; }

        

    }
}
