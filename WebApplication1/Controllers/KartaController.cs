using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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
        public static List<KartaPrikazVM.Row> polazni = null;
        public static List<KartaPrikazVM.Row> dolazni = null;
        private readonly UserManager<Korisnik> userManager;
        private readonly SignInManager<Korisnik> signInManager;
        public KartaController(ApplicationDbContext Db, UserManager<Korisnik> um, SignInManager<Korisnik> sm)
        {
            db = Db;
            userManager = um;
            signInManager = sm;
        }
       
        public IActionResult Prikaz(KartaPrikazVM karte)
        {
            KartaPrikazVM m;
            List<SelectListItem> polazneLinije = new List<SelectListItem>();
            List<SelectListItem> dolazneLinije = new List<SelectListItem>();

            if (polazni == null || polazni.Count()==0)
            {
                m = new KartaPrikazVM();
                m.DatumPolaska = DateTime.Now.Date.ToString();
                m.DatumDolaska = DateTime.Now.Date.ToString();
                m.polazni = null;
                m.dolazni = null;
            }
            else
            {
                m = new KartaPrikazVM()
                {
                    TipKarteID = karte.TipKarteID,
                    DatumPolaska = karte.DatumPolaska,
                    DatumDolaska = karte.DatumDolaska,
                    DolazisteID = karte.DolazisteID,
                    PolazisteID = karte.PolazisteID,
                    polazni = polazni,
                    dolazni=dolazni,
                };
                foreach (var p in polazni)
                {
                    var item = new SelectListItem
                    {
                        Text = p.ImeLinije + " - " + p.VrijemePolaska,
                        Value = p.LinijaId.ToString()
                    };
                    polazneLinije.Add(item);
                }
                foreach (var p in dolazni)
                {
                    var item = new SelectListItem
                    {
                        Text = p.ImeLinije +" - "+ p.VrijemePolaska,
                        Value = p.LinijaId.ToString()
                    };
                    dolazneLinije.Add(item);
                }
            }
           
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

            m.LinijaDolaziste = dolazneLinije;
            m.LinijaPolaziste = polazneLinije;
            m.TipKarte = tip;
            m.Polaziste = pol;
            m.Dolaziste = dol;
            return View(m);
        }
        //u slucaju da zajebem kod koji je radio na pocetku-->
        //public IActionResult Uredi(KartaUrediVM x)
        //{
        //    int polazisteRedniBroj = -1, dolazisteRedniBroj = -1;
        //    string vrijemePolaska="",vrijemeDolaska="",gradP="",gradD="";
        //    int linijaId=0;

        //    List<KartaUrediVM> podlinije=new List<KartaUrediVM>();
        //    foreach (var t in db.Stajalista)
        //    {
        //        if(t.GradID == x.PolazisteID){
        //            polazisteRedniBroj = t.RedniBrojStajalista;
        //            vrijemePolaska = t.SatnicaStizanja;
        //            linijaId = t.LinijaID;
        //            gradP = db.Grad.Find(t.GradID).Naziv;
        //        }
        //        if (t.GradID == x.DolazisteID && linijaId==t.LinijaID){
        //            dolazisteRedniBroj = t.RedniBrojStajalista;
        //            vrijemeDolaska = t.SatnicaStizanja;
        //            gradD = db.Grad.Find(t.GradID).Naziv;
        //        }
        //        if(polazisteRedniBroj < dolazisteRedniBroj && polazisteRedniBroj!=-1 && dolazisteRedniBroj != -1)
        //        {
        //            podlinije.Add(new KartaUrediVM()
        //            {
        //                LinijaId = linijaId,
        //                RedniBrojPolazista = polazisteRedniBroj,
        //                RedniBrojDolazista = dolazisteRedniBroj,
        //                VrijemePolaska=vrijemePolaska,
        //                VrijemeDolaska=vrijemeDolaska,
        //                PolazisteNaziv=gradP,
        //                DolazisteNaziv=gradD,
        //            });
        //            polazisteRedniBroj = -1;
        //            dolazisteRedniBroj = -1;
        //        }
        //    }
        //    string stanica = "";

        //    List<KartaUrediVM> Pkarte=new List<KartaUrediVM>();
        //    foreach (var t in podlinije)
        //    {
        //        foreach (var i in db.Stajalista)
        //        {
        //            if(t.LinijaId==i.LinijaID)
        //            {
        //                if (i.RedniBrojStajalista > t.RedniBrojPolazista && i.RedniBrojStajalista < t.RedniBrojDolazista)
        //                    stanica += db.Grad.Find(i.GradID).Naziv + " " + i.SatnicaStizanja + "\n";
        //            }
        //        }
        //        KartaUrediVM y = new KartaUrediVM()
        //        {
        //            PolazisteNaziv = t.PolazisteNaziv,
        //            DolazisteNaziv = t.DolazisteNaziv,
        //            ImeLinije = db.Linija.Find(t.LinijaId).OznakaLinije,
        //            VrijemePolaska = t.VrijemePolaska,
        //            VrijemeDolaska = t.VrijemeDolaska,
        //            Stajalista = stanica==""?"nema stajanja":stanica
        //        };
        //        Pkarte.Add(y);
        //    }
            
        //    return View(Pkarte);
        //}
        public IActionResult Uredi1(KartaPrikazVM x)
        {
            polazni = PronadjiLinije(x);
            int temp = x.PolazisteID;
            x.PolazisteID = x.DolazisteID;
            x.DolazisteID = temp;
            dolazni = PronadjiLinije(x);


            KartaPrikazVM xz = new KartaPrikazVM()
            {
                DolazisteID = x.PolazisteID,
                PolazisteID = x.DolazisteID,
                TipKarteID = x.TipKarteID,
                DatumPolaska = x.DatumPolaska,
                DatumDolaska = x.DatumDolaska,
            };
           
            return RedirectToAction("Prikaz",xz);
           
        }
        public List<KartaPrikazVM.Row> PronadjiLinije(KartaPrikazVM x)
        {
            int polazisteRedniBroj = -1, dolazisteRedniBroj = -1;
            string vrijemePolaska = "", vrijemeDolaska = "", gradP = "", gradD = "";
            int linijaId = 0;

            List<KartaPrikazVM.Row> podlinije = new List<KartaPrikazVM.Row>();
            foreach (var t in db.Stajalista)
            {
                if (t.GradID == x.PolazisteID)
                {
                    polazisteRedniBroj = t.RedniBrojStajalista;
                    vrijemePolaska = t.SatnicaStizanja;
                    linijaId = t.LinijaID;
                    gradP = db.Grad.Find(t.GradID).Naziv;
                }
                if (t.GradID == x.DolazisteID && linijaId == t.LinijaID)
                {
                    dolazisteRedniBroj = t.RedniBrojStajalista;
                    vrijemeDolaska = t.SatnicaStizanja;
                    gradD = db.Grad.Find(t.GradID).Naziv;
                }
                if (polazisteRedniBroj < dolazisteRedniBroj && polazisteRedniBroj != -1 && dolazisteRedniBroj != -1)
                {
                    var linija = db.Linija.Where(l => l.LinijaID == linijaId).SingleOrDefault();
                    var parsedDate = DateTime.Parse(x.DatumPolaska);
                    if (linija.DaniUSedmici.Contains(parsedDate.DayOfWeek.ToString()))
                    {
                        podlinije.Add(new KartaPrikazVM.Row()
                        {
                            LinijaId = linijaId,
                            RedniBrojPolazista = polazisteRedniBroj,
                            RedniBrojDolazista = dolazisteRedniBroj,
                            VrijemePolaska = vrijemePolaska,
                            VrijemeDolaska = vrijemeDolaska,
                            PolazisteNaziv = gradP,
                            DolazisteNaziv = gradD,
                        });
                    }
                    polazisteRedniBroj = -1;
                    dolazisteRedniBroj = -1;
                }
            }
            string stanica = "";

            List<KartaPrikazVM.Row> Pkarte = new List<KartaPrikazVM.Row>();
            foreach (var t in podlinije)
            {
                foreach (var i in db.Stajalista)
                {
                    if (t.LinijaId == i.LinijaID)
                    {
                        if (i.RedniBrojStajalista > t.RedniBrojPolazista && i.RedniBrojStajalista < t.RedniBrojDolazista)
                            stanica += db.Grad.Find(i.GradID).Naziv + " " + i.SatnicaStizanja + "\n";
                    }
                }
               

                KartaPrikazVM.Row y = new KartaPrikazVM.Row()
                {
                    LinijaId = t.LinijaId,
                    PolazisteNaziv = t.PolazisteNaziv,
                    DolazisteNaziv = t.DolazisteNaziv,
                    ImeLinije = db.Linija.Find(t.LinijaId).OznakaLinije,
                    VrijemePolaska = t.VrijemePolaska,
                    VrijemeDolaska = t.VrijemeDolaska,
                    Stajalista = stanica == "" ? "nema stajanja" : stanica,
                };
                Pkarte.Add(y);
            }
            return Pkarte;
        }
        public IActionResult Kupovina(KartaPrikazVM x)
        {
            var cijena = db.Cijena.Where(c => (c.GradPolaskaGradID == x.PolazisteID && c.GradDolaskaGradID == x.DolazisteID)
              || (c.GradDolaskaGradID == x.PolazisteID && c.GradPolaskaGradID == x.DolazisteID)).SingleOrDefault();

            float iznos = 0;
            if (x.TipKarteID == 1)
                iznos = cijena.JednosmijernaKartaCijena;
            else
                iznos = cijena.PovratnaKartaCijena;

            float ukupna=0;

            if (x.Dijete != 0)
                ukupna += iznos - iznos * db.VrstaPopusta.Where(i => i.Naziv == "Dijete").Select(i => i.Iznos).SingleOrDefault(); 
           else if (x.Student != 0)
                ukupna += iznos - iznos * db.VrstaPopusta.Where(i => i.Naziv == "Student").Select(i => i.Iznos).SingleOrDefault();
            else if (x.Penzioner != 0)
                ukupna += iznos - iznos * db.VrstaPopusta.Where(i => i.Naziv == "Penzioner").Select(i => i.Iznos).SingleOrDefault();
            if(x.Odrasli!=0)
                ukupna += x.Odrasli * iznos;
            var m = new KartaKupovinaVM
            {
                Cijena = (float)Math.Round(ukupna,2),
                PolazisteID = x.PolazisteID,
                DolazisteID = x.DolazisteID,
                DatumDolaska = x.DatumDolaska,
                DatumPolaska = x.DatumPolaska,
                TipKarteID = x.TipKarteID,
                LinijaDolaziste = db.Linija.Where(l => l.LinijaID == x.LinijaDolazisteID).Select(l => l.OznakaLinije + " - " + l.VrijemePolaska).SingleOrDefault(),
                LinijaPolaziste = db.Linija.Where(l => l.LinijaID == x.LinijaPolazisteID).Select(l => l.OznakaLinije+" - "+l.VrijemePolaska).SingleOrDefault(),
                Dijete = x.Dijete,
                Odrasli = x.Odrasli,
                Penzioner = x.Penzioner,
                Student = x.Student,
                DolazisteNaziv=db.Grad.Where(g=>g.GradID==x.DolazisteID).Select(g=>g.Naziv).SingleOrDefault(),
                PolazisteNaziv=db.Grad.Where(g=>g.GradID==x.PolazisteID).Select(g=>g.Naziv).SingleOrDefault(),
                TipKarte=db.TipKarte.Where(t=>t.TipKarteID==x.TipKarteID).Select(t=>t.Naziv).SingleOrDefault()
            };

            return View(m);
        }
        public async Task<IActionResult> Placanje(KartaKupovinaVM x)
        {
            Korisnik user = await userManager.GetUserAsync(User);
          
            
            if(user!=null && user is Kupac)
            {

            }
            if (user == null)
            {
                return Redirect("/Identity/Account/Login");
            }
            return View();
        }
    }
}