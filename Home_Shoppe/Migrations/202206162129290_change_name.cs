namespace Home_Shoppe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_name : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.InformationUsers", newName: "UserInformations");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.UserInformations", newName: "InformationUsers");
        }
    }
}
