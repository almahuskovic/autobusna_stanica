using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Podaci.Klase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models.Stajalista;

namespace WebApplication1.Controllers
{
    public class StajalistaController : Controller
    {
        private readonly ApplicationDbContext db;
        public StajalistaController(ApplicationDbContext Db)
        {
            db = Db;
        }

        public IActionResult Prikaz(int LinijaID)
        {
            Linija linija = db.Linija.Find(LinijaID);

            List<StajalistePrikazVM.Row> Stajalista = db.Stajalista
                .Select(s => new StajalistePrikazVM.Row
                {
                    StajaistaID = s.StajaistaID,
                    LinijaID = s.LinijaID,
                    Linija = s.Linija.OznakaLinije,
                    GradID = s.GradID,
                    Grad = s.Grad.Naziv,
                    SatnicaStizanja = s.SatnicaStizanja,
                    RedniBrojStajalista = s.RedniBrojStajalista

                }).ToList();
            StajalistePrikazVM s = new StajalistePrikazVM();
            s.Stajalista = Stajalista;
            //s.OznakaLinije = linija.OznakaLinije;
            s._linijaID = LinijaID;


            return View(s);
        }


        public IActionResult Obrisi(int StajalisteID)
        {
            Stajalista stajaliste = db.Stajalista.Find(StajalisteID);
            db.Remove(stajaliste);
            db.SaveChanges();

            return Redirect("/Stajalista/Prikaz");
        }

        public IActionResult Uredi(int LinijaID,int StajalisteID)
        {
            List<SelectListItem> gradovi = db.Grad.OrderBy(g => g.Naziv)
                .Select(g => new SelectListItem
                {
                    Text = g.Naziv,
                    Value = g.GradID.ToString()
                }).ToList();

            StajalisteUrediVM stajaliste = StajalisteID == 0 ? new StajalisteUrediVM() :
                db.Stajalista.Where(s => s.StajaistaID == StajalisteID)
                .Select(s => new StajalisteUrediVM()
                {
                    StajaistaID=s.StajaistaID,
                    LinijaID=s.LinijaID,
                    Linija=s.Linija.OznakaLinije,
                    GradID=s.GradID,
                    Grad=s.Grad.Naziv,
                    SatnicaStizanja=s.SatnicaStizanja,
                    RedniBrojStajalista=s.RedniBrojStajalista
                }).Single();
            stajaliste.Gradovi = gradovi;
            stajaliste._linijaID = LinijaID;

            return View("Uredi",stajaliste);
        }

        public IActionResult Snimi(StajalisteUrediVM x)
        {
            Stajalista stajaliste;
            if (x.StajaistaID == 0)
            {
                stajaliste = new Stajalista();
                db.Add(stajaliste);
            }
            else
            {
                stajaliste = db.Stajalista.Find(x.StajaistaID);
            }
            stajaliste.LinijaID = x.LinijaID;
            stajaliste.GradID = x.GradID;
            stajaliste.RedniBrojStajalista = x.RedniBrojStajalista;
            stajaliste.SatnicaStizanja = x.SatnicaStizanja;

            db.SaveChanges();
            return Redirect("/Stajalista/Prikaz");
        }

    }
}
