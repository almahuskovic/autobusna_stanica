using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Podaci.Klase;
using WebApplication1.Data;
using WebApplication1.Models.Karta;

namespace WebApplication1.Controllers
{
    public class KartaController : Controller
    {
        private readonly ApplicationDbContext db;
        public KartaController(ApplicationDbContext Db)
        {
            db = Db;
        }
        public IActionResult Prikaz()
        {
            var m = db.Karta.Select(k => new KartaPrikazVM.Row()
            {
                KartaID=k.KartaID,
                Datum=k.Datum,
                VaziDo=k.VaziDo,
                VaziOd=k.VaziOd,
                Sjediste=k.Sjediste,
                BrojPutnika=k.BrojPutnika,
                VrstaPopusta=k.VrstaPopusta.Naziv,
                TipKarte=k.TipKarte.Naziv,
                IsRezervisana=k.IsRezervisana
            }).ToList();
            KartaPrikazVM karte = new KartaPrikazVM();
            karte.karte = m;
            return View(karte);
        }
        public IActionResult Obrisi(int KartaID)
        {
            Karta k = db.Karta.Find(KartaID);
            db.Remove(k);
            db.SaveChanges();
            return Redirect("/Karta/Prikaz");
        }
        public IActionResult Uredi(int KartaID)
        {
            List<SelectListItem> tip = db.TipKarte.OrderBy(n=>n.Naziv).Select(t => new SelectListItem
            {
                Text = t.Naziv,
                Value = t.TipKarteID.ToString()
            }).ToList();
            List<SelectListItem> popust = db.VrstaPopusta.OrderBy(n => n.Naziv).Select(p => new SelectListItem
            {
                Text=p.Naziv,
                Value=p.VrstaPopustaID.ToString()
            }).ToList();

            KartaUrediVM m;
            if (KartaID == 0)
            {
                m = new KartaUrediVM()
                {
                    VrstaPopusta = popust,
                    TipKarte=tip,
                    Datum=DateTime.Now,
                };
            }
            else
            {
                m = db.Karta.Where(k => k.KartaID == KartaID).Select(t => new KartaUrediVM()
                {
                    KartaID=t.KartaID,
                    VaziDo=t.VaziDo,
                    VaziOd=t.VaziOd,
                    Sjediste=t.Sjediste,
                    BrojPutnika=t.BrojPutnika,
                    VrstaPopustaID=t.VrstaPopustaID,
                    TipKarteID=t.TipKarteID,
                    VrstaPopusta = popust,
                    TipKarte = tip,
                }).SingleOrDefault();
            } 
            return View(m);
        }
        public IActionResult Snimi(KartaUrediVM x)
        {
            Karta k;
            if (x.KartaID == 0)
            {
                k = new Karta();
                db.Karta.Add(k);
            }
            else
            {
                k = db.Karta.Find(x.KartaID);
            }
            k.TipKarteID = x.TipKarteID;
            k.Sjediste = x.Sjediste;
            k.VaziDo = x.VaziDo;
            k.VaziOd = x.VaziOd;
            k.Datum = x.Datum;
            k.BrojPutnika = x.BrojPutnika;
            k.VrstaPopustaID = x.VrstaPopustaID;

            db.SaveChanges();
            return Redirect("/Karta/Prikaz");
        }
        public IActionResult Plati(KartaUrediVM x)
        {
            
            return Redirect("/Karta/Prikaz");
        }
    }
}