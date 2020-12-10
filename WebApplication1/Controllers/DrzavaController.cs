using Microsoft.AspNetCore.Mvc;
using Podaci;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DrzavaController : Controller
    {

        public IActionResult Prikaz(string pretraga)
        {
            MojDbContext db = new MojDbContext();

            
            List<DrzavaPrikazVM.Row> Drzave = db.Drzava
                .Where(d=> pretraga==null || d.Naziv.StartsWith(pretraga))
                .Select(x => new DrzavaPrikazVM.Row
            {
                DrzavaID = x.DrzavaID,
                Naziv = x.Naziv
            }).ToList();
            DrzavaPrikazVM d = new DrzavaPrikazVM();
            d.Drzave=Drzave;
            d.pretraga = pretraga;
           
            return View(d);
        }


        public IActionResult Obrisi(int DrzavaID)
        {
            MojDbContext db = new MojDbContext();

            Drzava d = db.Drzava.Find(DrzavaID);
            db.Remove(d);
            db.SaveChanges();

            TempData["PorukaInfo"] = "Uspjesno obrisana drzava " + d.Naziv;
            return Redirect("/Drzava/Prikaz");        
        }


        public IActionResult Uredi(int DrzavaID)
        {
            MojDbContext db = new MojDbContext();

            DrzavaDodajVM d = DrzavaID == 0 ? new DrzavaDodajVM() :
              db.Drzava.Where(w => w.DrzavaID == DrzavaID)
              .Select(x => new DrzavaDodajVM
              {
                  DrzavaID = x.DrzavaID,
                  Naziv = x.Naziv,
              }).Single();

            return View("Uredi", d);
        }

        public IActionResult Snimi (DrzavaDodajVM x)
        {
            MojDbContext db = new MojDbContext();

            Drzava drzava;
            if (x.DrzavaID == 0)
            {
                drzava = new Drzava();
                db.Add(drzava);
            }
            else
            {
                drzava = db.Drzava.Find(x.DrzavaID);

            }
            drzava.Naziv = x.Naziv;

            db.SaveChanges();
            return Redirect("/Drzava/Prikaz");

        }
    }
}


