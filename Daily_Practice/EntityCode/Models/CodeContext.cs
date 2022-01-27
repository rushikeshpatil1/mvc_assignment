using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using EntityCode.Models;
using EntityCode.Migrations;

namespace EntityCode.Models
{
    public class CodeContext : DbContext
    {
        public CodeContext() : base("conn")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CodeContext, Configuration>());

        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}