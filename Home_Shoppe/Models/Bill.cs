using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Home_Shoppe.Models
{
    public class Bill
    {
        [Key]
        [StringLength(20)]
        public string IdBill { get; set; }

        [StringLength(20)]
        public string UserID { get; set; }

        public string ReceiverName { get; set; }

        public string Phone { get; set; }

        public string DiliveryAddress { get; set; }

        public string Note{ get; set; }

        public DateTime Time { get; set; }

        public int? TotalQuantity { get; set; }

        public string Status { get; set; }

        public double? TotalPayment { get; set; }


        public List<Cart> carts { get; set; }
    }
}