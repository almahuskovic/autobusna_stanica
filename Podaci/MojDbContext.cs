using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Podaci.Klase;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication1;

namespace Podaci
{
    public class MojDbContext:DbContext
    {
        public DbSet<ObavijestKategorija> ObavijestKategorija { get; set; }
        public DbSet<Drzava> Drzava { get; set; }
        public DbSet<Grad> Grad { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=AMRA\MSSQLSERVER_OLAP; Database=BUS_STANICA;
                        Trusted_Connection=true; MultipleActiveResultSets=true;");
        }
    }
}
