namespace Estore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class four : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.products", "Photo", c => c.String());
            AlterColumn("dbo.vendors", "VendorName", c => c.String(nullable: false));
            AlterColumn("dbo.vendors", "Email", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.vendors", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.vendors", "VendorName", c => c.String());
            AlterColumn("dbo.products", "Photo", c => c.String(nullable: false));
        }
    }
}
