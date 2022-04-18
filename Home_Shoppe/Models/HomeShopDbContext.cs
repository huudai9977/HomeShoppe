

namespace Home_Shoppe.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;
    public class HomeShopDbContext :  DbContext
    {
        public HomeShopDbContext()
            : base("name=HomeShoppeDB")
        {
            
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductTag> ProductTags { get; set; }

        

        protected override void OnModelCreating(DbModelBuilder contextBuilder)
        {

          


            contextBuilder.Entity<Product>().HasMany
                 (x => x.ProductReviews).WithOptional
                 (x => x.Product).WillCascadeOnDelete();
            contextBuilder.Entity<Product>().HasMany
                 (x => x.ProductTags).WithOptional
                 (x => x.Product).WillCascadeOnDelete();
            contextBuilder.Entity<Category>().HasMany
                 (x => x.Products).WithOptional
                 (x => x.Category).WillCascadeOnDelete();
            

        }
    }
}