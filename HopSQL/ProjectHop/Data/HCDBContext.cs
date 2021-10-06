using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mods;
//using Npgsql.EntityFrameworkCore;

namespace Data
{
    public class HCDBContext : DbContext
    {
        public HCDBContext() : base() { }
        public HCDBContext (DbContextOptions<HCDBContext> options) : base(options) {  }

        public DbSet<Beer> Beers { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Inventory> Inventories { get; set; }

        public DbSet<LineItem> LineItems { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Store> Stores { get; set; }


    }
}
