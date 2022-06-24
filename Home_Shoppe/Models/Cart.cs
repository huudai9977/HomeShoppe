using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Home_Shoppe.Models
{
    public class Cart
    {
        [Key]
        [StringLength(20)]
        public string IdCart { get; set; }

        [StringLength(20)]
        public string UserID { get; set; }

        [StringLength(20)]
        public string IdProduct { get; set; }

        public double? Price { get; set; }

        public int? Quantity{ get; set; }

        public string Color { get; set; }

        public double? Total { get; set; }

        public string IdBill { get; set; }

        public virtual Product Product { get; set; }



    }
}