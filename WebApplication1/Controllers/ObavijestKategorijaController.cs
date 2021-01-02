using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Podaci;
using WebApplication1.Data;
//using WebApplication1.Models;
using WebApplication1.Models.ObavijestKategorija;

namespace WebApplication1.Controllers
{
    public class ObavijestKategorijaController : Controller
    {
        //MojDbContext db = new MojDbContext();
        private readonly ApplicationDbContext db;
        public ObavijestKategorijaController(ApplicationDbContext Db)
        {
            Db = db;
        }
        public IActionResult Prikaz()
        {
            var m = db.ObavijestKategorija.
                Select(ob => new ObavijestKategorijaPrikazVM
                {
                    ObavijestID = ob.ObavijestKategorijaID,
                    Naziv = ob.Naziv
                })
                .ToList();
            return View(m);
        }
        public IActionResult Uredi(int ObavijestID)
        {
            ObavijestKategorijaUrediVM m;
            if (ObavijestID == 0)
            {
                m = new ObavijestKategorijaUrediVM();
            }
            else
            {
                m = db.ObavijestKategorija.Where(o => o.ObavijestKategorijaID == ObavijestID)
               .Select(ob => new ObavijestKategorijaUrediVM
               {
                   Naziv = ob.Naziv
               }).Single();
            }

            return View(m);
        }
        public IActionResult Snimi(ObavijestKategorijaUrediVM x)
        {
            ObavijestKategorija m;
            if (x.ObavijestID == 0)
            {
                m = new ObavijestKategorija();
                db.Add(m);
            }
            else
            {
                m = db.ObavijestKategorija.Where(o => o.ObavijestKategorijaID == x.ObavijestID).SingleOrDefault();
            }
            m.Naziv = x.Naziv;
            db.SaveChanges();
            return Redirect("/ObavijestKategorija/Prikaz");
        }
        public IActionResult Obrisi(int ObavijestID)
        {
            var m=db.ObavijestKategorija.Find(ObavijestID);
            db.Remove(m);
            db.SaveChanges();
            return Redirect("/ObavijestKategorija/Prikaz");
        }
    }
}