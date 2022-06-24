namespace Home_Shoppe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaaaaaa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "IdProduct", "dbo.Product");
            AddForeignKey("dbo.Carts", "IdProduct", "dbo.Product", "IdProduct", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "IdProduct", "dbo.Product");
            AddForeignKey("dbo.Carts", "IdProduct", "dbo.Product", "IdProduct");
        }
    }
}
