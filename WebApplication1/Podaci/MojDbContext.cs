using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication1;

namespace Podaci
{
    public class MojDbContext:DbContext
    {
        public DbSet<ObavijestKategorija> ObavijestKategorija { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost; Database=BUS_STANICA;
                        Trusted_Connection=true; MultipleActiveResultSets=true;");
        }
    }
}
