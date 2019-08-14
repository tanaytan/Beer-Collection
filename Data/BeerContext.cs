using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beer_Collection.Data
{
    //public class BeerContext : DbContext
    //{
    //    public BeerContext(DbContextOptions<BeerContext> options) : base(options)
    //    {
    //    }

    //    public DbSet<Beer> Beers { get; set; }
    //}

    public class BeerContext : DbContext
    {
        public DbSet<Beer> Beers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=beerdb;Trusted_Connection=True;");
        }
    }
}

