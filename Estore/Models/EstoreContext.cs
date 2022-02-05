using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Configuration;
using Estore.Migrations;

namespace Estore.Models
{
    public class EstoreContext : DbContext
    {
        public EstoreContext() : base("conn")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EstoreContext, Migrations.Configuration>()); 

        }
        public DbSet<vendors> vendors { get; set; }

        public System.Data.Entity.DbSet<Estore.Models.products> products { get; set; }
    }
}