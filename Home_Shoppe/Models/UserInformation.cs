using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Home_Shoppe.Models
{
    public class UserInformation
    {
        [Key]
        [StringLength(20)]
        public string IdUser { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string NameUser { get; set; }

        
        public double Phone { get; set; }

        public string Address { get; set; }

    }
}