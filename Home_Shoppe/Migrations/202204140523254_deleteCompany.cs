namespace Home_Shoppe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteCompany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "IdProductionCompany", "dbo.ProductionCompany");
            DropIndex("dbo.Product", new[] { "IdProductionCompany" });
            DropColumn("dbo.Product", "IdProductionCompany");
            DropTable("dbo.ProductionCompany");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductionCompany",
                c => new
                    {
                        IdProductionCompany = c.String(nullable: false, maxLength: 20),
                        NameProductionCompany = c.String(nullable: false, maxLength: 100),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdProductionCompany);
            
            AddColumn("dbo.Product", "IdProductionCompany", c => c.String(maxLength: 20));
            CreateIndex("dbo.Product", "IdProductionCompany");
            AddForeignKey("dbo.Product", "IdProductionCompany", "dbo.ProductionCompany", "IdProductionCompany", cascadeDelete: true);
        }
    }
}
