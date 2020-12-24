using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Podaci;
using Podaci.Klase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using WebApplication1.Models.Obavijest;

namespace WebApplication1.Controllers
{
    public class ObavijestObavijestKategorijaController : Controller
    {
        MojDbContext db = new MojDbContext();

        public IActionResult Prikaz()
        {
            List<ObavijestPrikazVM.Row> obavijesti = db.Obavijest.OrderByDescending(d=>d.DatumObjave).Select(o => new ObavijestPrikazVM.Row
            {
                ObavijestID = o.ObavijestID,
                Naslov = o.Naslov,
                Podnaslov = o.Podnaslov,
                Opis = o.Opis,
                DatumObjave = o.DatumObjave,
                ObavijestKategorija = o.ObavijestKategorija.Naziv,
                Slika = KonvertovanjeSlike.GetImageBase64(o.Slika)
            }).ToList();
            ObavijestPrikazVM m = new ObavijestPrikazVM();
            m.obavijesti = obavijesti;

            return View(m);
        }
       
        public IActionResult Uredi(int ObavijestID)
        {
            List<SelectListItem> ok = db.ObavijestKategorija.OrderBy(n => n.Naziv).Select(k => new SelectListItem
            {
                Text = k.Naziv,
                Value = k.ObavijestKategorijaID.ToString()
            }).ToList();

            ObavijestDodajVM m;
            if (ObavijestID == 0)
            {
                m = new ObavijestDodajVM
                {
                    DatumObjave = DateTime.Now,
                    Kategorije = ok,
                };
            }
            else
            {
                
                m = db.Obavijest.Where(o => o.ObavijestID == ObavijestID).Select(k => new ObavijestDodajVM
                {
                    ObavijestID = k.ObavijestID,
                    Naslov = k.Naslov,
                    Podnaslov = k.Podnaslov,
                    Opis = k.Opis,
                    DatumObjave = DateTime.Now,
                    KategorijaID = k.ObavijestKategorijaID,
                    Kategorije = ok,
                    Slika = KonvertovanjeSlike.GetImageBase64(k.Slika)
                }).Single();
            }
            return View(m);
        }
        [HttpPost]
        public IActionResult Snimi(ObavijestDodajVM x, IFormFile file)
        {
            Obavijest o;
            if (x.ObavijestID == 0)
            {
                o = new Obavijest();
                db.Add(o);
            }
            else
            {
                o = db.Obavijest.Find(x.ObavijestID);
               
            }
            o.Naslov = x.Naslov;
            o.Podnaslov = x.Podnaslov;
            o.Opis = x.Opis;
            o.DatumObjave = x.DatumObjave;
            o.ObavijestKategorijaID = x.KategorijaID;

            var newSlika = KonvertovanjeSlike.GetImageByteArray(file);
            if (newSlika != null)
            {
                o.Slika = newSlika;
            }

            db.SaveChanges();
            return Redirect("/ObavijestObavijestKategorija/Prikaz");
        }
        public IActionResult Obrisi(int ObavijestID)
        {
            Obavijest o = db.Obavijest.Find(ObavijestID);
            db.Remove(o);
            db.SaveChanges();
            return Redirect("/ObavijestObavijestKategorija/Prikaz");
        }
        
    }
}