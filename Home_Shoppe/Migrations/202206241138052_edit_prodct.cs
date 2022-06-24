namespace Home_Shoppe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_prodct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "QuantityInStock", c => c.Int());
            AlterColumn("dbo.Product", "Status", c => c.Int());
            AlterColumn("dbo.Product", "Views", c => c.Int());
            AlterColumn("dbo.Product", "Sold", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "Sold", c => c.Int(nullable: false));
            AlterColumn("dbo.Product", "Views", c => c.Int(nullable: false));
            AlterColumn("dbo.Product", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.Product", "QuantityInStock");
        }
    }
}
