namespace Home_Shoppe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addusers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InformationUsers",
                c => new
                    {
                        IdUser = c.String(nullable: false, maxLength: 20),
                        Email = c.String(maxLength: 50),
                        NameUser = c.String(maxLength: 50),
                        Phone = c.Double(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.IdUser);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.InformationUsers");
        }
    }
}
