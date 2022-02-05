namespace Estore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.products",
                c => new
                    {
                        ProductID = c.Long(nullable: false, identity: true),
                        ProductName = c.String(),
                        Price = c.Decimal(precision: 18, scale: 2),
                        DateOfPurchase = c.DateTime(),
                        AvailabilityStatus = c.String(),
                        VendorID = c.Long(),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.vendors", t => t.VendorID)
                .Index(t => t.VendorID);
            
            CreateTable(
                "dbo.vendors",
                c => new
                    {
                        VendorID = c.Long(nullable: false, identity: true),
                        VendorName = c.String(),
                        Address = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Contact = c.String(nullable: false),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.VendorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.products", "VendorID", "dbo.vendors");
            DropIndex("dbo.products", new[] { "VendorID" });
            DropTable("dbo.vendors");
            DropTable("dbo.products");
        }
    }
}
