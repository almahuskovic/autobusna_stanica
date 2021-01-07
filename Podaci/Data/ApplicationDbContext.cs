using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Podaci.Klase;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : IdentityDbContext<Korisnik>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<ObavijestKategorija> ObavijestKategorija { get; set; }
        public DbSet<Drzava> Drzava { get; set; }
        public DbSet<Grad> Grad { get; set; }
        public DbSet<Obavijest> Obavijest { get; set; }
        public DbSet<Vozilo> Vozilo { get; set; }
        public DbSet<Linija> Linija { get; set; }
        public DbSet<Vozac> Vozac { get; set; }
        public DbSet<TipKarte> TipKarte{ get; set; }
        public DbSet<VrstaPopusta> VrstaPopusta{ get; set; }
        public DbSet<Karta> Karta{ get; set; }
        public DbSet<Stajalista> Stajalista{ get; set; }
        //public DbSet<Kartica> Kartica{ get; set; }
    }
}
