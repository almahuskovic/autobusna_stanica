using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Podaci;
using Podaci.Klase;
using WebApplication1.Models.TipUposlenika;

namespace WebApplication1.Controllers
{
    public class TipUposlenikaController : Controller
    {
        MojDbContext db = new MojDbContext();
        public IActionResult Prikaz()
        {
            var m = db.TipUposlenika.
               Select(ob => new TipUposlenikaPrikazVM
               {
                   TipUposlenikaID = ob.TipUposlenikaID,
                   Naziv = ob.Naziv
               })
               .ToList();
            return View(m);
        }
        public IActionResult Uredi(int TipUposlenikaID)
        {
            TipUposlenikaUrediVM m;
            if (TipUposlenikaID == 0)
            {
                m = new TipUposlenikaUrediVM();
            }
            else
            {
                m = db.TipUposlenika.Where(o => o.TipUposlenikaID == TipUposlenikaID)
               .Select(ob => new TipUposlenikaUrediVM
               {
                   Naziv = ob.Naziv
               }).Single();
            }
            return View(m);
        }
        public IActionResult Snimi(TipUposlenikaUrediVM x)
        {
            TipUposlenika m;
            if (x.TipUposlenikaID == 0)
            {
                m = new TipUposlenika();
                db.Add(m);
            }
            else
            {
                m = db.TipUposlenika.Where(o => o.TipUposlenikaID == x.TipUposlenikaID).SingleOrDefault();
            }
            m.Naziv = x.Naziv;
            db.SaveChanges();
            return Redirect("/TipUposlenika/Prikaz");
        }
        public IActionResult Obrisi(int TipUposlenikaID)
        {
            var m = db.TipUposlenika.Find(TipUposlenikaID);
            db.Remove(m);
            db.SaveChanges();
            return Redirect("/TipUposlenika/Prikaz");
        }
    }
}