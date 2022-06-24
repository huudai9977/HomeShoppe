namespace Home_Shoppe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_ModelCart : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Carts", "IdProduct");
            AddForeignKey("dbo.Carts", "IdProduct", "dbo.Product", "IdProduct");
            DropColumn("dbo.Carts", "NameProduct");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carts", "NameProduct", c => c.String());
            DropForeignKey("dbo.Carts", "IdProduct", "dbo.Product");
            DropIndex("dbo.Carts", new[] { "IdProduct" });
        }
    }
}
