using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Podaci.Klase;
using WebApplication1.Data;
using WebApplication1.Models.TipKarte;

namespace WebApplication1.Controllers
{
    public class TipKarteController : Controller
    {
        private readonly ApplicationDbContext db;
        public TipKarteController(ApplicationDbContext Db)
        {
            db = Db;
        }
        public IActionResult Prikaz()
        {
            var m = db.TipKarte.Select(k => new TipKartePrikazVM()
            {
                TipKarteID=k.TipKarteID,
                Naziv=k.Naziv
            }).ToList();
            return View(m);
        }
        public IActionResult Obrisi(int TipKarteID)
        {
            TipKarte k = db.TipKarte.Find(TipKarteID);
            db.Remove(k);
            db.SaveChanges();
            return Redirect("/TipKarte/Prikaz/");
        }
        public IActionResult Uredi(int TipKarteID)
        {
            TipKarteUrediVM m;
            if (TipKarteID == 0)
            {
                m = new TipKarteUrediVM();
            }
            else
            {
                m = db.TipKarte.Where(k => k.TipKarteID == TipKarteID).Select(i=>new TipKarteUrediVM() { 
                    Naziv=i.Naziv,
                    TipKarteID=i.TipKarteID
                }).SingleOrDefault();
            }
            return View(m);
        }
        public IActionResult Snimi(TipKarteUrediVM m)
        {
            TipKarte karta;
            if (m.TipKarteID == 0)
            {
                karta = new TipKarte();
                db.TipKarte.Add(karta);
            }
            else
            {
                karta = db.TipKarte.Find(m.TipKarteID);
            }
            karta.Naziv = m.Naziv;
            karta.TipKarteID = m.TipKarteID;
            db.SaveChanges();
            return Redirect("/TipKarte/Prikaz");
        }
    }
}