namespace Home_Shoppe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelCart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        IdCart = c.String(nullable: false, maxLength: 20),
                        UserID = c.String(maxLength: 20),
                        IdProduct = c.String(maxLength: 20),
                        NameProduct = c.String(),
                        Price = c.Double(),
                        Quantity = c.Int(),
                        color = c.String(),
                        total = c.Double(),
                    })
                .PrimaryKey(t => t.IdCart);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Carts");
        }
    }
}
