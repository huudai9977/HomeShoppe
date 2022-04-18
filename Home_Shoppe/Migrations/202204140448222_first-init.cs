namespace Home_Shoppe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstinit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        IdCategory = c.String(nullable: false, maxLength: 20),
                        NameCategory = c.String(nullable: false, maxLength: 100),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCategory);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        IdProduct = c.String(nullable: false, maxLength: 20),
                        IdCategories = c.String(maxLength: 20),
                        IdProductionCompany = c.String(maxLength: 20),
                        NameProduct = c.String(),
                        Price = c.Double(),
                        ProductDetails = c.String(),
                        Description = c.String(),
                        Status = c.Int(nullable: false),
                        New = c.String(),
                        Views = c.Int(nullable: false),
                        Sold = c.Int(nullable: false),
                        Image1 = c.String(maxLength: 50),
                        Image2 = c.String(maxLength: 50),
                        Image3 = c.String(maxLength: 50),
                        Image4 = c.String(maxLength: 50),
                        Image5 = c.String(maxLength: 50),
                        Image6 = c.String(maxLength: 50),
                        Category_IdCategory = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.IdProduct)
                .ForeignKey("dbo.ProductionCompany", t => t.IdProductionCompany, cascadeDelete: true)
                .ForeignKey("dbo.Category", t => t.Category_IdCategory, cascadeDelete: true)
                .Index(t => t.IdProductionCompany)
                .Index(t => t.Category_IdCategory);
            
            CreateTable(
                "dbo.ProductionCompany",
                c => new
                    {
                        IdProductionCompany = c.String(nullable: false, maxLength: 20),
                        NameProductionCompany = c.String(nullable: false, maxLength: 100),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdProductionCompany);
            
            CreateTable(
                "dbo.ProductReview",
                c => new
                    {
                        IdProductReview = c.String(nullable: false, maxLength: 20),
                        IdProduct = c.String(maxLength: 20),
                        Rate = c.Single(nullable: false),
                        Summary = c.String(),
                        Review = c.String(),
                    })
                .PrimaryKey(t => t.IdProductReview)
                .ForeignKey("dbo.Product", t => t.IdProduct, cascadeDelete: true)
                .Index(t => t.IdProduct);
            
            CreateTable(
                "dbo.ProductTag",
                c => new
                    {
                        IdProductTag = c.String(nullable: false, maxLength: 20),
                        IdProduct = c.String(maxLength: 20),
                        Tag = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.IdProductTag)
                .ForeignKey("dbo.Product", t => t.IdProduct, cascadeDelete: true)
                .Index(t => t.IdProduct);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        IdContect = c.String(nullable: false, maxLength: 20),
                        name = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        CompanyName = c.String(maxLength: 50),
                        Subject = c.String(),
                    })
                .PrimaryKey(t => t.IdContect);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "Category_IdCategory", "dbo.Category");
            DropForeignKey("dbo.ProductTag", "IdProduct", "dbo.Product");
            DropForeignKey("dbo.ProductReview", "IdProduct", "dbo.Product");
            DropForeignKey("dbo.Product", "IdProductionCompany", "dbo.ProductionCompany");
            DropIndex("dbo.ProductTag", new[] { "IdProduct" });
            DropIndex("dbo.ProductReview", new[] { "IdProduct" });
            DropIndex("dbo.Product", new[] { "Category_IdCategory" });
            DropIndex("dbo.Product", new[] { "IdProductionCompany" });
            DropTable("dbo.Contact");
            DropTable("dbo.ProductTag");
            DropTable("dbo.ProductReview");
            DropTable("dbo.ProductionCompany");
            DropTable("dbo.Product");
            DropTable("dbo.Category");
        }
    }
}
