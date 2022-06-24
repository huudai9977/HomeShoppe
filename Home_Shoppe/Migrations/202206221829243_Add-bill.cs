namespace Home_Shoppe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addbill : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        IdBill = c.String(nullable: false, maxLength: 20),
                        UserID = c.String(maxLength: 20),
                        ReceiverName = c.String(),
                        DiliveryAddress = c.String(),
                        Note = c.String(),
                        TotalQuantity = c.Int(),
                        Status = c.String(),
                        TotalPayment = c.Double(),
                    })
                .PrimaryKey(t => t.IdBill);
            
            AddColumn("dbo.Carts", "Bill_IdBill", c => c.String(maxLength: 20));
            CreateIndex("dbo.Carts", "Bill_IdBill");
            AddForeignKey("dbo.Carts", "Bill_IdBill", "dbo.Bills", "IdBill");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "Bill_IdBill", "dbo.Bills");
            DropIndex("dbo.Carts", new[] { "Bill_IdBill" });
            DropColumn("dbo.Carts", "Bill_IdBill");
            DropTable("dbo.Bills");
        }
    }
}
