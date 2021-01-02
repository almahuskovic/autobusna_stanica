using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Podaci.Klase;
using WebApplication1.Data;
using WebApplication1.Models.Vozac;

namespace WebApplication1.Controllers
{
    public class VozacController : Controller
    {
        private readonly ApplicationDbContext db;
        public VozacController(ApplicationDbContext Db)
        {
            db = Db;
        }
        public IActionResult Prikaz(string Pretraga)
        {
            var vozaci = db.Vozac.Where(x=>Pretraga==null || x.Ime.StartsWith(Pretraga) || x.Prezime.StartsWith(Pretraga))
                .Select(v => new VozacPrikazVM.Row()
            {
                VozacID=v.VozacID,
                Ime=v.Ime,
                Prezime=v.Prezime,
                DatumZaposlenja=v.DatumZaposlenja,
                DatumRodjenja=v.DatumRodjenja,
                BrojVozacke=v.BrojVozacke
            }).ToList();
            VozacPrikazVM m=new VozacPrikazVM();
            m.Vozaci= vozaci;
           return View(m);
        }
        public IActionResult Uredi(int VozacID)
        {
            VozacUrediVM.Row m;
            if(VozacID==0)
            {
                m = new VozacUrediVM.Row();
                m.DatumRodjenja = DateTime.Now.Date;
                m.DatumZaposlenja = DateTime.Now.Date;
            }
            else
            {
                m = db.Vozac.Where(v => v.VozacID == VozacID).Select(x => new VozacUrediVM.Row()
                {
                    VozacID=x.VozacID,
                    BrojVozacke=x.BrojVozacke,
                    DatumRodjenja=x.DatumRodjenja.Date,
                    DatumZaposlenja=x.DatumZaposlenja.Date,
                    Ime=x.Ime,
                    Prezime=x.Prezime
                }).Single();
            }
            return View(m);
        }

        public IActionResult Snimi(VozacUrediVM.Row x)
        {
            Vozac v;
            if (x.VozacID == 0)
            {
                v = new Vozac();
                db.Add(v);
            }
            else
            {
                v = db.Vozac.Find(x.VozacID);
            }
            v.VozacID = x.VozacID;
            v.BrojVozacke = x.BrojVozacke;
            v.DatumRodjenja = x.DatumRodjenja;
            v.DatumZaposlenja = x.DatumZaposlenja;
            v.Ime = x.Ime;
            v.Prezime = x.Prezime;
            db.SaveChanges();
            return Redirect("/Vozac/Prikaz");
        }

        public IActionResult Obrisi(int VozacID)
        {
            Vozac v = db.Vozac.Find(VozacID);
            db.Remove(v);
            db.SaveChanges();
            return Redirect("/Vozac/Prikaz");
        }

    }
}