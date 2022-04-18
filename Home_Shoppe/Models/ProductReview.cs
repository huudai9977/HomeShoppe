using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Home_Shoppe.Models
{
    [Table("ProductReview")]
    public class ProductReview
    {
        [Key]
        [StringLength(20)]
        public string IdProductReview { get; set; }

        [StringLength(20)]
        public string IdProduct { get; set; }


        public float Rate { get; set; }

        [DataType(DataType.Text)]
        public string Summary { get; set; }

        [DataType(DataType.Text)]
        public string Review { get; set; }

        public virtual Product Product { get; set; }


    }
}