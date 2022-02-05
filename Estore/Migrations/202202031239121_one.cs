namespace Estore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class one : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.products", "VendorID", "dbo.vendors");
            DropIndex("dbo.products", new[] { "VendorID" });
            AlterColumn("dbo.products", "ProductName", c => c.String(nullable: false));
            AlterColumn("dbo.products", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.products", "DateOfPurchase", c => c.DateTime(nullable: false));
            AlterColumn("dbo.products", "AvailabilityStatus", c => c.String(nullable: false));
            AlterColumn("dbo.products", "VendorID", c => c.Long(nullable: false));
            AlterColumn("dbo.products", "Photo", c => c.String(nullable: false));
            CreateIndex("dbo.products", "VendorID");
            AddForeignKey("dbo.products", "VendorID", "dbo.vendors", "VendorID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.products", "VendorID", "dbo.vendors");
            DropIndex("dbo.products", new[] { "VendorID" });
            AlterColumn("dbo.products", "Photo", c => c.String());
            AlterColumn("dbo.products", "VendorID", c => c.Long());
            AlterColumn("dbo.products", "AvailabilityStatus", c => c.String());
            AlterColumn("dbo.products", "DateOfPurchase", c => c.DateTime());
            AlterColumn("dbo.products", "Price", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.products", "ProductName", c => c.String());
            CreateIndex("dbo.products", "VendorID");
            AddForeignKey("dbo.products", "VendorID", "dbo.vendors", "VendorID");
        }
    }
}
