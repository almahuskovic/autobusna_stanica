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
        public DbSet<Obavijest> Obavijest { get; set; }
        public DbSet<Vozilo> Vozilo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=app.fit.ba,1431; 
                                            Database=db_AutobusnaStanica;
                                            Trusted_Connection=false; 
                                            User ID=db_AutobusnaStanica;
                                            Password=SisterStres2020;
                                            MultipleActiveResultSets=true;");
        }
    }
}
