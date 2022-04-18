namespace Home_Shoppe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editProduct : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Product", name: "Category_IdCategory", newName: "IdCategory");
            RenameIndex(table: "dbo.Product", name: "IX_Category_IdCategory", newName: "IX_IdCategory");
            DropColumn("dbo.Product", "IdCategories");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "IdCategories", c => c.String(maxLength: 20));
            RenameIndex(table: "dbo.Product", name: "IX_IdCategory", newName: "IX_Category_IdCategory");
            RenameColumn(table: "dbo.Product", name: "IdCategory", newName: "Category_IdCategory");
        }
    }
}
