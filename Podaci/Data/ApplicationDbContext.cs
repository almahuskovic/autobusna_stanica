using System;
using System.Collections.Generic;
using System.Linq;
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Linija>()
             .Property(e => e.DaniUSedmici)
             .HasConversion(
                 v => string.Join(',', v),
                 v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

            //za cascade
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<LinijaVozilo>()
            .HasKey(x => new { x.LinijaID, x.VoziloID });

            modelBuilder.Entity<LinijaVozilo>()
                .HasOne(x => x.Linija)
                .WithMany(y => y.Vozilo)
                .HasForeignKey(y => y.LinijaID);

            modelBuilder.Entity<LinijaVozilo>()
                .HasOne(x => x.Vozilo)
                .WithMany(y =>y.Linija)
                .HasForeignKey(y => y.VoziloID);

            modelBuilder.Entity<LinijaVozac>()
            .HasKey(x => new { x.LinijaID, x.VozacID });

            modelBuilder.Entity<LinijaVozac>()
               .HasOne(x => x.Linija)
               .WithMany(y => y.Vozac)
               .HasForeignKey(y => y.LinijaID);

            modelBuilder.Entity<LinijaVozac>()
                .HasOne(x => x.Vozac)
                .WithMany(y => y.Linija)
                .HasForeignKey(y => y.VozacID);

            modelBuilder.Entity<KartaKupac>()
            .HasKey(x => new { x.KartaID, x.KupacID });

            modelBuilder.Entity<KartaKupac>()
               .HasOne(x => x.Karta)
               .WithMany(y => y.Kupac)
               .HasForeignKey(y => y.KartaID);

            modelBuilder.Entity<KartaKupac>()
                .HasOne(x => x.Kupac)
                .WithMany(y => y.Karta)
                .HasForeignKey(y => y.KupacID);
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
        public DbSet<Cijena> Cijena { get; set; }
        public DbSet<KreditnaKartica> KreditnaKartica { get; set; }
        public DbSet<Kupac> Kupac { get; set; }
        public DbSet<Menadzer> Menadzer { get; set; }
        public DbSet<LinijaVozilo> LinijaVozilo { get; set; }
        public DbSet<LinijaVozac> LinijaVozac { get; set; }
        public DbSet<KartaKupac> KartaKupac { get; set; }
    }
}
