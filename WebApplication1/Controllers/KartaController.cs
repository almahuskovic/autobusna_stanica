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
            KartaUrediVM m = new KartaUrediVM() { 
                DatumPolaska=DateTime.Now.Date.ToString() 
            };
            List<SelectListItem> tip = db.TipKarte.OrderBy(n => n.Naziv).Select(t => new SelectListItem
            {
                Text = t.Naziv,
                Value = t.TipKarteID.ToString()
            }).ToList();
            List<SelectListItem> pol = db.Grad.OrderBy(n => n.Naziv).Select(t => new SelectListItem
            {
                Text = t.Naziv,
                Value = t.GradID.ToString()
            }).ToList();
            List<SelectListItem> dol = db.Grad.OrderBy(n => n.Naziv).Select(t => new SelectListItem
            {
                Text = t.Naziv,
                Value = t.GradID.ToString()
            }).ToList();
            m.TipKarte = tip;
            m.Polaziste = pol;
            m.Dolaziste = dol;
            return View(m);
        }
        public IActionResult Uredi(KartaUrediVM x)
        {
            int polazisteRedniBroj = -1, dolazisteRedniBroj = -1;
            string vrijemePolaska="",vrijemeDolaska="",gradP="",gradD="";
            int linijaId=0;

            List<KartaUrediVM> podlinije=new List<KartaUrediVM>();
            foreach (var t in db.Stajalista)
            {
                if(t.GradID == x.PolazisteID){
                    polazisteRedniBroj = t.RedniBrojStajalista;
                    vrijemePolaska = t.SatnicaStizanja;
                    linijaId = t.LinijaID;
                    gradP = db.Grad.Find(t.GradID).Naziv;
                }
                if (t.GradID == x.DolazisteID && linijaId==t.LinijaID){
                    dolazisteRedniBroj = t.RedniBrojStajalista;
                    vrijemeDolaska = t.SatnicaStizanja;
                    gradD = db.Grad.Find(t.GradID).Naziv;
                }
                if(polazisteRedniBroj < dolazisteRedniBroj && polazisteRedniBroj!=-1 && dolazisteRedniBroj != -1)
                {
                    podlinije.Add(new KartaUrediVM()
                    {
                        LinijaId = linijaId,
                        RedniBrojPolazista = polazisteRedniBroj,
                        RedniBrojDolazista = dolazisteRedniBroj,
                        VrijemePolaska=vrijemePolaska,
                        VrijemeDolaska=vrijemeDolaska,
                        PolazisteNaziv=gradP,
                        DolazisteNaziv=gradD,
                    });
                    polazisteRedniBroj = -1;
                    dolazisteRedniBroj = -1;
                }
            }
            string stanica = "";

            List<KartaUrediVM> Pkarte=new List<KartaUrediVM>();
            foreach (var t in podlinije)
            {
                foreach (var i in db.Stajalista)
                {
                    if(t.LinijaId==i.LinijaID)
                    {
                        if (i.RedniBrojStajalista > t.RedniBrojPolazista && i.RedniBrojStajalista < t.RedniBrojDolazista)
                            stanica += db.Grad.Find(i.GradID).Naziv + " " + i.SatnicaStizanja + "\n";
                    }
                }
                KartaUrediVM y = new KartaUrediVM()
                {
                    PolazisteNaziv = t.PolazisteNaziv,
                    DolazisteNaziv = t.DolazisteNaziv,
                    ImeLinije = db.Linija.Find(t.LinijaId).OznakaLinije,
                    VrijemePolaska = t.VrijemePolaska,
                    VrijemeDolaska = t.VrijemeDolaska,
                    Stajalista = stanica==""?"nema stajanja":stanica
                };
                Pkarte.Add(y);
            }
            
            return View(Pkarte);
        }
    }
}