namespace EntityCode.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EntityCode.Models.CodeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EntityCode.Models.CodeContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Brands.AddOrUpdate(new Models.Brand() { BrandID = 1, BrandName = "Realme" });
            context.Categories.AddOrUpdate(new Models.Category() { CategoryID = 1, CategoryName = "Electronics" });
            context.Products.AddOrUpdate(new Models.Product() { ProductID = 1, ProductName = "Realme 6 pro", CategoryID = 1, DateOfPurchase = DateTime.Now, Active = true, BrandID = 1, Photo = null, Price = 18000, AvailabilityStatus = "InStock" });
        }
    }
}
