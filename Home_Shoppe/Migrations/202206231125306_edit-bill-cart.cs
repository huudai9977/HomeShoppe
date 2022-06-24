namespace Home_Shoppe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editbillcart : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Carts", name: "Bill_IdBill", newName: "IdBill");
            RenameIndex(table: "dbo.Carts", name: "IX_Bill_IdBill", newName: "IX_IdBill");
            AddColumn("dbo.Bills", "Phone", c => c.String());
            AddColumn("dbo.Bills", "Time", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bills", "Time");
            DropColumn("dbo.Bills", "Phone");
            RenameIndex(table: "dbo.Carts", name: "IX_IdBill", newName: "IX_Bill_IdBill");
            RenameColumn(table: "dbo.Carts", name: "IdBill", newName: "Bill_IdBill");
        }
    }
}
