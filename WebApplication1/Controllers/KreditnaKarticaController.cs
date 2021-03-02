using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Podaci.Klase;
using WebApplication1.Data;
using WebApplication1.Helper;
using WebApplication1.Models.Karta;

namespace WebApplication1.Controllers
{
    //[EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class KreditnaKarticaController : Controller
    {
        private readonly ApplicationDbContext db;
        public KreditnaKarticaController(ApplicationDbContext Db)
        {
            db = Db;
        }

        [HttpGet]
        public IActionResult KreditnaKarticaPrikaz()
        {
            try
            {
                var kartice = new List<KreditnaKarticaPrikazVM.KarticaRedovi>();
                if (db.KreditnaKartica.Where(k => k.Kupac.Id == HttpContext.LogiraniKorisnik().Id).Count() > 0)
                {
                    kartice = db.KreditnaKartica.Where(k => k.Kupac.Id == HttpContext.LogiraniKorisnik().Id).Select(k => new KreditnaKarticaPrikazVM.KarticaRedovi
                    {
                        kreditnaKarticaID = k.KreditnaKarticaID,
                        brojKartice = k.BrojKartice,
                        datumIsteka = k.DatumIsteka,
                        imeVlasnika = k.ImeVlasnikaKartice,
                        verKod = k.VerifikacijskiKod
                    }).ToList();
                }
                var listak = db.KreditnaKartica.Where(k => k.Kupac.Id == HttpContext.LogiraniKorisnik().Id).Select(k => new SelectListItem
                {
                    Value = k.KreditnaKarticaID.ToString(),
                    Text = k.BrojKartice
                }).ToList();
                var m = new KreditnaKarticaPrikazVM
                {
                    Kartice = listak,
                    KarticeKupca = kartice
                };
                return Json(m);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
 
           
            //ako je view onda moze da otvori sa get, a ne moze da ucita ispod onog, a kad je partial onda ucita, al ne otvori vamo fak

        }

        public IActionResult KreditnaKarticaObrisi(int KarticaID)
        {
            KreditnaKartica v = db.KreditnaKartica.Find(KarticaID);
            foreach (var k in db.Karta)
            {
                if (k.KKarticaID == KarticaID)
                {
                    k.KKarticaID = null;
                }
            }
            db.SaveChanges();
            //db.Remove(v);
            db.SaveChanges();

            return RedirectToAction("Kupovina");
        }
        public IActionResult KreditnaKarticaUredi(int KarticaID)
        {
            KreditnaKarticaUrediVM v = KarticaID == 0 ? new KreditnaKarticaUrediVM() :
                db.KreditnaKartica.Where(v => v.KreditnaKarticaID == KarticaID)
                .Select(v => new KreditnaKarticaUrediVM
                {
                    ImeVlasnika = v.ImeVlasnikaKartice,
                    VerKod = v.VerifikacijskiKod,
                    DatumIsteka = v.DatumIsteka,
                    BrojKartice = v.BrojKartice
                }).Single();

            return View(v);

        }
        public IActionResult KreditnaKarticaSnimi(KreditnaKarticaUrediVM x)
        {
            KreditnaKartica kartica;
            if (x.KreditnaKarticaID == 0)
            {
                kartica = new KreditnaKartica();
                db.Add(kartica);
            }
            else
            {
                kartica = db.KreditnaKartica.Find(x.KreditnaKarticaID);
            }
            kartica.ImeVlasnikaKartice = x.ImeVlasnika;
            kartica.VerifikacijskiKod = x.VerKod;
            kartica.DatumIsteka = x.DatumIsteka;
            kartica.BrojKartice = x.BrojKartice;
            kartica.Kupac = (Kupac)HttpContext.LogiraniKorisnik();

            db.SaveChanges();
            return Redirect("/Karta/KreditnaKarticaPrikaz");
        }
    }
}