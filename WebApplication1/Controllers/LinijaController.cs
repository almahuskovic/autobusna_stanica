using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Podaci;
using Podaci.Klase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class LinijaController : Controller
    {
        private readonly ApplicationDbContext db;
        public LinijaController(ApplicationDbContext Db)
        {
            db = Db;
        }


        public IActionResult Prikaz(string pretraga)
        {
            List<LinijaPrikazVM.Row> Linije = db.Linija
                .Where(l => pretraga == null || l.OznakaLinije.ToLower().StartsWith(pretraga.ToLower()) 
                                             || l.GradPolaska.Naziv.ToLower().StartsWith(pretraga.ToLower()) 
                                             || l.GradDolaska.Naziv.ToLower().StartsWith(pretraga.ToLower()))
                .Select(l => new LinijaPrikazVM.Row
                {
                    LinijaID = l.LinijaID,
                    OznakaLinije = l.OznakaLinije,
                    GradDolaskaGradID = l.GradDolaskaGradID,
                    GradDolaska = l.GradDolaska.Naziv,
                    GradPolaskaGradID = l.GradPolaskaGradID,
                    GradPolaska = l.GradPolaska.Naziv,

                    Ponedjeljak=l.Ponedjeljak,
                    Utorak=l.Utorak,
                    Srijeda=l.Srijeda,
                    Cetvrtak=l.Cetvrtak,
                    Petak=l.Petak,
                    Subota=l.Subota,
                    Nedjelja=l.Nedjelja,
                    VrijemePolaska=l.VrijemePolaska,                    
                    VrijemeDolaska=l.VrijemeDolaska,
                }).ToList();

            LinijaPrikazVM l = new LinijaPrikazVM();
            l.Linije = Linije;
            l.pretraga = pretraga;
            

            return View(l);
        }
        

        public IActionResult Obrisi(int LinijaID)
        {
            Linija linija = db.Linija.Find(LinijaID);
            db.Remove(linija);
            db.SaveChanges();

            return Redirect("/Linija/Prikaz");
        }

        public IActionResult Uredi(int LinijaID)
        {
            List<SelectListItem> gradovi = db.Grad.OrderBy(g => g.Naziv)
                .Select(g => new SelectListItem
                {
                    Text = g.Naziv,
                    Value = g.GradID.ToString()
                }).ToList();

            LinijaUrediVM linija = LinijaID == 0 ? new LinijaUrediVM() :
                db.Linija.Where( l=> l.LinijaID == LinijaID)
                .Select(l => new LinijaUrediVM
                {
                    LinijaID = l.LinijaID,
                    OznakaLinije = l.OznakaLinije,
                    GradPolaskaGradID = l.GradPolaskaGradID,
                    GradPolaska=l.GradPolaska.Naziv,
                    GradDolaskaGradID = l.GradDolaskaGradID,
                    GradDolaska=l.GradDolaska.Naziv,
                    Ponedjeljak = l.Ponedjeljak,
                    Utorak = l.Utorak,
                    Srijeda = l.Srijeda,
                    Cetvrtak = l.Cetvrtak,
                    Petak = l.Petak,
                    Subota = l.Subota,
                    Nedjelja = l.Nedjelja,

                    VrijemePolaska = l.VrijemePolaska,
                    VrijemeDolaska = l.VrijemeDolaska,
                }).Single();

            linija.Gradovi = gradovi;

            return View("Uredi", linija);
        }

        public IActionResult Snimi(LinijaUrediVM x)
        {
            Linija linija;
            if (x.LinijaID == 0)
            {
                linija = new Linija();
                db.Add(linija);
            }
            else
            {
                linija = db.Linija.Find(x.LinijaID);
            }
            linija.OznakaLinije = x.OznakaLinije;
            linija.GradPolaskaGradID = x.GradPolaskaGradID;
            linija.GradDolaskaGradID = x.GradDolaskaGradID;
            linija.Ponedjeljak = x.Ponedjeljak;
            linija.Utorak = x.Utorak;
            linija.Srijeda = x.Srijeda;
            linija.Cetvrtak = x.Cetvrtak;
            linija.Petak = x.Petak;
            linija.Subota = x.Subota;
            linija.Nedjelja = x.Nedjelja;
            linija.VrijemePolaska = x.VrijemePolaska;
            linija.VrijemeDolaska = x.VrijemeDolaska;

            db.SaveChanges();
            return Redirect("/Linija/Prikaz");
        }
    }
}
