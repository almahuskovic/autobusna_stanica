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
using WebApplication1.Models.Linija;

namespace WebApplication1.Controllers
{
    public class LinijaController : Controller
    {
        private readonly ApplicationDbContext db;
        public LinijaController(ApplicationDbContext Db)
        {
            db = Db;
        }
        //public IActionResult Prikaz(string pretraga)
        //{
        //    List<LinijaPrikazVM.Row> Linije = db.Linija
        //        .Where(l => pretraga == null || l.OznakaLinije.ToLower().StartsWith(pretraga.ToLower()) 
        //                                     || l.GradPolaska.Naziv.ToLower().StartsWith(pretraga.ToLower()) 
        //                                     || l.GradDolaska.Naziv.ToLower().StartsWith(pretraga.ToLower()))
        //        .Select(l => new LinijaPrikazVM.Row
        //        {
        //            LinijaID = l.LinijaID,
        //            OznakaLinije = l.OznakaLinije,
        //            GradDolaskaGradID = l.GradDolaskaGradID,
        //            GradDolaska = l.GradDolaska.Naziv,
        //            GradPolaskaGradID = l.GradPolaskaGradID,
        //            GradPolaska = l.GradPolaska.Naziv,

        //            Ponedjeljak=l.Ponedjeljak,
        //            Utorak=l.Utorak,
        //            Srijeda=l.Srijeda,
        //            Cetvrtak=l.Cetvrtak,
        //            Petak=l.Petak,
        //            Subota=l.Subota,
        //            Nedjelja=l.Nedjelja,
        //            VrijemePolaska=l.VrijemePolaska,                    
        //            VrijemeDolaska=l.VrijemeDolaska,
        //        }).ToList();

        //    LinijaPrikazVM l = new LinijaPrikazVM();
        //    l.Linije = Linije;
        //    l.pretraga = pretraga;


        //    return View(l);
        //}


        //public IActionResult Obrisi(int LinijaID)
        //{
        //    List<Stajalista> stajalistazaBrisati = db.Stajalista.Where(x => x.LinijaID == LinijaID).ToList();
        //    db.RemoveRange(stajalistazaBrisati);
        //    db.SaveChanges();

        //    Linija linija = db.Linija.Find(LinijaID);
        //    db.Remove(linija);
        //    db.SaveChanges();

        //    return Redirect("/Linija/Prikaz");
        //}

        //public IActionResult Uredi(int LinijaID)
        //{
        //    List<SelectListItem> gradovi = db.Grad.OrderBy(g => g.Naziv)
        //        .Select(g => new SelectListItem
        //        {
        //            Text = g.Naziv,
        //            Value = g.GradID.ToString()
        //        }).ToList();

        //    LinijaUrediVM linija = LinijaID == 0 ? new LinijaUrediVM() :
        //        db.Linija.Where( l=> l.LinijaID == LinijaID)
        //        .Select(l => new LinijaUrediVM
        //        {
        //            LinijaID = l.LinijaID,
        //            OznakaLinije = l.OznakaLinije,
        //            GradPolaskaGradID = l.GradPolaskaGradID,
        //            GradPolaska=l.GradPolaska.Naziv,
        //            GradDolaskaGradID = l.GradDolaskaGradID,
        //            GradDolaska=l.GradDolaska.Naziv,
        //            Ponedjeljak = l.Ponedjeljak,
        //            Utorak = l.Utorak,
        //            Srijeda = l.Srijeda,
        //            Cetvrtak = l.Cetvrtak,
        //            Petak = l.Petak,
        //            Subota = l.Subota,
        //            Nedjelja = l.Nedjelja,

        //            VrijemePolaska = l.VrijemePolaska,
        //            VrijemeDolaska = l.VrijemeDolaska,
        //        }).Single();

        //    linija.Gradovi = gradovi;

        //    return View("Uredi", linija);
        //}

        //public IActionResult Snimi(LinijaUrediVM x)
        //{
        //    Linija linija;
        //    if (x.LinijaID == 0)
        //    {
        //        linija = new Linija();
        //        db.Add(linija);
        //    }
        //    else
        //    {
        //        linija = db.Linija.Find(x.LinijaID);
        //    }
        //    linija.OznakaLinije = x.OznakaLinije;
        //    linija.GradPolaskaGradID = x.GradPolaskaGradID;
        //    linija.GradDolaskaGradID = x.GradDolaskaGradID;
        //    linija.Ponedjeljak = x.Ponedjeljak;
        //    linija.Utorak = x.Utorak;
        //    linija.Srijeda = x.Srijeda;
        //    linija.Cetvrtak = x.Cetvrtak;
        //    linija.Petak = x.Petak;
        //    linija.Subota = x.Subota;
        //    linija.Nedjelja = x.Nedjelja;
        //    linija.VrijemePolaska = x.VrijemePolaska;
        //    linija.VrijemeDolaska = x.VrijemeDolaska;

        //    linija.DaniUSedmici = new string[7];
        //    if (x.Ponedjeljak)
        //        linija.DaniUSedmici[0]=("Monday");
        //    if (x.Utorak)
        //        linija.DaniUSedmici[1]=("Tuesday");
        //    if (x.Srijeda)
        //        linija.DaniUSedmici[2] = ("Wednesday");
        //    if (x.Cetvrtak)
        //        linija.DaniUSedmici[3] = ("Thursday");
        //    if (x.Petak)
        //        linija.DaniUSedmici[4] = ("Friday");
        //    if (x.Subota)
        //        linija.DaniUSedmici[5] = ("Saturday");
        //    if (x.Nedjelja)
        //        linija.DaniUSedmici[6] = ("Sunday");

        //    db.SaveChanges();
        //    return Redirect("/Linija/Prikaz");
        //}

        #region Linija
        public IActionResult LinijaPrikaz(string pretraga)
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

                    Ponedjeljak = l.Ponedjeljak,
                    Utorak = l.Utorak,
                    Srijeda = l.Srijeda,
                    Cetvrtak = l.Cetvrtak,
                    Petak = l.Petak,
                    Subota = l.Subota,
                    Nedjelja = l.Nedjelja,
                    VrijemePolaska = l.VrijemePolaska,
                    VrijemeDolaska = l.VrijemeDolaska,
                }).ToList();

            LinijaPrikazVM l = new LinijaPrikazVM();
            l.Linije = Linije;
            l.pretraga = pretraga;


            return View(l);
        }
        public IActionResult LinijaObrisi(int LinijaID)
        {
            List<Stajalista> stajalistazaBrisati = db.Stajalista.Where(x => x.LinijaID == LinijaID).ToList();
            db.RemoveRange(stajalistazaBrisati);
            db.SaveChanges();

            Linija linija = db.Linija.Find(LinijaID);
            db.Remove(linija);
            db.SaveChanges();

            return Redirect("/Linija/LinijaPrikaz");
        }
        public IActionResult LinijaUredi(int LinijaID)
        {
            List<SelectListItem> gradovi = db.Grad.OrderBy(g => g.Naziv)
                .Select(g => new SelectListItem
                {
                    Text = g.Naziv,
                    Value = g.GradID.ToString()
                }).ToList();

            LinijaUrediVM linija = LinijaID == 0 ? new LinijaUrediVM() :
                db.Linija.Where(l => l.LinijaID == LinijaID)
                .Select(l => new LinijaUrediVM
                {
                    LinijaID = l.LinijaID,
                    OznakaLinije = l.OznakaLinije,
                    GradPolaskaGradID = l.GradPolaskaGradID,
                    GradPolaska = l.GradPolaska.Naziv,
                    GradDolaskaGradID = l.GradDolaskaGradID,
                    GradDolaska = l.GradDolaska.Naziv,
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

            return View( linija);
        }

        public IActionResult LinijaSnimi(LinijaUrediVM x)
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

            linija.DaniUSedmici = new string[7];
            if (x.Ponedjeljak)
                linija.DaniUSedmici[0] = ("Monday");
            if (x.Utorak)
                linija.DaniUSedmici[1] = ("Tuesday");
            if (x.Srijeda)
                linija.DaniUSedmici[2] = ("Wednesday");
            if (x.Cetvrtak)
                linija.DaniUSedmici[3] = ("Thursday");
            if (x.Petak)
                linija.DaniUSedmici[4] = ("Friday");
            if (x.Subota)
                linija.DaniUSedmici[5] = ("Saturday");
            if (x.Nedjelja)
                linija.DaniUSedmici[6] = ("Sunday");

            db.SaveChanges();
            return Redirect("/Linija/LinijaPrikaz");
        }
        #endregion

        #region Stajalista
        public IActionResult StajalistaPrikaz(int LinijaID)
        {
            Linija linija = db.Linija.Find(LinijaID);

            List<StajalistePrikazVM.Row> Stajalista = db.Stajalista.Where(s => s.LinijaID == LinijaID)
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


        public IActionResult StajalistaObrisi(int LinijaID, int StajalisteID)
        {
            Stajalista stajaliste = db.Stajalista.Find(StajalisteID);
            db.Remove(stajaliste);
            db.SaveChanges();

            return Redirect("/Linija/StajalistaPrikaz?LinijaID=" + LinijaID);
        }

        public IActionResult StajalistaUredi(int LinijaID, int StajalisteID)
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
                    StajaistaID = StajalisteID,
                    LinijaID = LinijaID,
                    Linija = s.Linija.OznakaLinije,
                    GradID = s.GradID,
                    Grad = s.Grad.Naziv,
                    SatnicaStizanja = s.SatnicaStizanja,
                    RedniBrojStajalista = s.RedniBrojStajalista
                }).Single();
            stajaliste.Gradovi = gradovi;
            stajaliste._linijaID = LinijaID;
            stajaliste._stajalisteID = StajalisteID;

            return View("StajalistaUredi", stajaliste);
        }

        public IActionResult StajalistaSnimi(StajalisteUrediVM x)
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
            return Redirect("/Linija/StajalistaPrikaz?LinijaID=" + x._linijaID);
        }
        #endregion

        #region Grad
        public IActionResult GradPrikaz(string pretraga)
        {
            //List<SelectListItem> Drzave = db.Drzava
            //    .OrderBy(d => d.Naziv)
            //    .Select(d => new SelectListItem
            //    {
            //        Text = d.Naziv,
            //        Value = d.DrzavaID.ToString()
            //    }).ToList();

            List<GradPrikazVM.Row> Gradovi = db.Grad
                .Where(g => pretraga == null || g.Naziv.ToLower().StartsWith(pretraga.ToLower()))
                .Select(x => new GradPrikazVM.Row
                {
                    GradID = x.GradID,
                    Naziv = x.Naziv,
                    Drzava = x.Drzava.Naziv

                }).ToList();
            GradPrikazVM g = new GradPrikazVM();
            g.Gradovi = Gradovi;
            //g.Drzave = Drzave;
            g.pretraga = pretraga;

            return View(g);
        }

        public IActionResult GradObrisi(int GradID)
        {
            Grad g = db.Grad.Find(GradID);
            db.Remove(g);
            db.SaveChanges();
            return Redirect("/Linija/GradPrikaz");
        }

        public IActionResult GradUredi(int GradID)
        {
            List<SelectListItem> drzave = db.Drzava.OrderBy(x => x.Naziv)
                .Select(x => new SelectListItem
                {
                    Text = x.Naziv,
                    Value = x.DrzavaID.ToString()
                }).ToList();

            GradDodajVM g = GradID == 0 ? new GradDodajVM() :
                db.Grad.Where(x => x.GradID == GradID)
                .Select(x => new GradDodajVM
                {
                    GradID = x.GradID,
                    Naziv = x.Naziv,
                    DrzavaID = x.DrzavaID,
                    //Drzava = x.Drzava
                }).Single();
            g.drzave = drzave;

            return View("GradUredi", g);

        }
        public IActionResult GradSnimi(GradDodajVM x)
        {
            Grad grad;
            if (x.GradID == 0)
            {
                grad = new Grad();
                db.Add(grad);
            }
            else
            {
                grad = db.Grad.Find(x.GradID);
            }
            grad.Naziv = x.Naziv;
            grad.DrzavaID = x.DrzavaID;

            db.SaveChanges();
            return Redirect("/Linija/GradPrikaz");
        }
        #endregion

        #region Drzava
        public IActionResult DrzavaPrikaz(string pretraga)
        {
            List<DrzavaPrikazVM.Row> Drzave = db.Drzava
                .Where(d => pretraga == null || d.Naziv.StartsWith(pretraga))
                .Select(x => new DrzavaPrikazVM.Row
                {
                    DrzavaID = x.DrzavaID,
                    Naziv = x.Naziv
                }).ToList();
            DrzavaPrikazVM d = new DrzavaPrikazVM();
            d.Drzave = Drzave;
            d.pretraga = pretraga;

            return View(d);
        }

        public IActionResult DrzavaObrisi(int DrzavaID)
        {
            Drzava d = db.Drzava.Find(DrzavaID);
            db.Remove(d);
            db.SaveChanges();

            TempData["PorukaInfo"] = "Uspjesno obrisana drzava " + d.Naziv;
            return Redirect("/Linija/DrzavaPrikaz");
        }

        public IActionResult DrzavaUredi(int DrzavaID)
        {
            DrzavaDodajVM d = DrzavaID == 0 ? new DrzavaDodajVM() :
              db.Drzava.Where(w => w.DrzavaID == DrzavaID)
              .Select(x => new DrzavaDodajVM
              {
                  DrzavaID = x.DrzavaID,
                  Naziv = x.Naziv,
              }).Single();

            return View(d);
        }

        public IActionResult DrzavaSnimi(DrzavaDodajVM x)
        {
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
            return Redirect("/Linija/DrzavaPrikaz");
        }
        #endregion
    }
}
