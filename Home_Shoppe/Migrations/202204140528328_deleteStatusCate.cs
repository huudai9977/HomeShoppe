namespace Home_Shoppe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteStatusCate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Category", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Category", "Status", c => c.Int(nullable: false));
        }
    }
}
