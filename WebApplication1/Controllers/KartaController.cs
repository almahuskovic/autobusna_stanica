using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Podaci.Klase;
using WebApplication1.Data;
using WebApplication1.Helper;
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
                    OznakaLinije=polazni.First().ImeLinije+" - "+polazni.First().VrijemePolaska,//+"\n"+dolazni.First().ImeLinije,
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
                OznakaLinije=x.OznakaLinije
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
                ukupna += iznos - iznos *x.Dijete* db.VrstaPopusta.Where(i => i.Naziv == "Dijete").Select(i => i.Iznos).SingleOrDefault(); 
            if (x.Student != 0)
                ukupna += iznos - iznos *x.Student* db.VrstaPopusta.Where(i => i.Naziv == "Student").Select(i => i.Iznos).SingleOrDefault();
            if (x.Penzioner != 0)
                ukupna += iznos - iznos *x.Penzioner* db.VrstaPopusta.Where(i => i.Naziv == "Penzioner").Select(i => i.Iznos).SingleOrDefault();
            if(x.Odrasli!=0)
                ukupna += x.Odrasli * iznos;

            var kartice = new List<KartaKupovinaVM.KarticaRedovi>();
            if (db.KreditnaKartica.Where(k => k.Kupac.Id == HttpContext.LogiraniKorisnik().Id).Count() > 0)
            {
                kartice = db.KreditnaKartica.Where(k => k.Kupac.Id == HttpContext.LogiraniKorisnik().Id).Select(k => new KartaKupovinaVM.KarticaRedovi
                {
                    KreditnaKarticaID = k.KreditnaKarticaID,
                    BrojKartice = k.BrojKartice,
                    DatumIsteka = k.DatumIsteka,
                    ImeVlasnika = k.ImeVlasnikaKartice,
                    VerKod = k.VerifikacijskiKod
                }).ToList();
            }
            var listak = db.KreditnaKartica.Where(k => k.Kupac.Id == HttpContext.LogiraniKorisnik().Id).Select(k => new SelectListItem
            {
                Value = k.KreditnaKarticaID.ToString(),
                Text = k.BrojKartice
            }).ToList();

            var m = new KartaKupovinaVM
            {
                CijenaBezPopusta=iznos,
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
                TipKarte=db.TipKarte.Where(t=>t.TipKarteID==x.TipKarteID).Select(t=>t.Naziv).SingleOrDefault(),
                Kartice = listak,
                KarticeKupca = kartice,
                OznakaLinije=x.OznakaLinije
            };
          
            return View(m);
        }
        public IActionResult Placanje(KartaKupovinaVM x)
        {
            int ukupnoPonavljanja = x.Dijete + x.Student + x.Penzioner + x.Odrasli;
            for(int i=0;i< ukupnoPonavljanja;i++)
            {
                VrstaPopusta p = new VrstaPopusta();
                if(x.Dijete>=1)
                {
                    p = db.VrstaPopusta.Where(i => i.Naziv == "Dijete").SingleOrDefault();
                    x.Dijete--;
                }
                else if (x.Student >= 1)
                {
                    p = db.VrstaPopusta.Where(i => i.Naziv == "Student").SingleOrDefault();
                    x.Student--;
                }
                else if (x.Penzioner >= 1)
                {
                    p = db.VrstaPopusta.Where(i => i.Naziv == "Penzioner").SingleOrDefault();
                    x.Penzioner--;
                }
                else
                {
                    p = db.VrstaPopusta.Where(i => i.Naziv == "Odrasli").SingleOrDefault();
                    x.Odrasli--;
                }
                if (p != null)
                {
                    Karta k = new Karta()
                    {
                        DatumKupovine = DateTime.Now.Date.ToString("yyyy-MM-dd"),
                        DatumPolaska = x.DatumPolaska,
                        DatumDolaska = x.TipKarteID == 2 ? x.DatumDolaska : null,
                        TipKarteID = x.TipKarteID,
                        //PolazisteID = x.PolazisteID,
                        //DolazisteID = x.DolazisteID,
                        VrstaPopustaID = p.VrstaPopustaID,
                        NazivLinije=x.OznakaLinije,
                        IsAktivna=true,
                        Cijena =(float)Math.Round(x.CijenaBezPopusta - x.CijenaBezPopusta * p.Iznos,2),
                        Kupac = (Kupac)HttpContext.LogiraniKorisnik(),
                    };
                    if (x.KarticeID != 0)
                        k.KKarticaID = x.KarticeID;
                    k.PolazisteID = x.PolazisteID;
                    k.DolazisteID = x.DolazisteID;
                    db.Karta.Add(k);
                    db.SaveChanges();
                    p = null;
                }
            }
            return RedirectToAction("KupljeneKarte");
        }
        public IActionResult KupljeneKarte()
        {
            foreach(var i in db.Karta)
            {
                if (i.TipKarteID == 1 && DateTime.Compare(DateTime.Parse(i.DatumPolaska), DateTime.Now) == -1)
                {
                    if (i.TipKarteID == 2 && DateTime.Compare(DateTime.Parse(i.DatumDolaska), DateTime.Now) == -1)
                        i.IsAktivna = false;
                    i.IsAktivna = false;
                }
                else
                    i.IsAktivna = true;
            }
            db.SaveChanges();
            var redovi = db.Karta
                .Include(i => i.Polaziste.Grad)
                .Include(i => i.Dolaziste.Grad)
                .Include(i => i.TipKarte)
                .Include(i => i.VrstaPopusta)
                .OrderBy(i=>i.DatumKupovine)
                .Where(i => i.Kupac.Id == HttpContext.LogiraniKorisnik().Id).Select(i => new KupljeneKarteVM.Row
            {
                Cijena = i.Cijena,
                DatumPolaska = i.DatumPolaska,
                DatumDolaska = i.DatumDolaska,
                PolazisteNaziv = db.Grad.Where(p=>p.GradID==i.PolazisteID).FirstOrDefault().Naziv,
                DolazisteNaziv = db.Grad.Where(p => p.GradID == i.DolazisteID).FirstOrDefault().Naziv,
                IsAktivna = i.IsAktivna,
                KartaID = i.KartaID,
                OznakaLinije = i.NazivLinije,
                TipKarte = i.TipKarte.Naziv,
                VrstaPopusta = i.VrstaPopusta.Naziv,
                DatumKupovineKarte=i.DatumKupovine
            }).ToList();

            var m = new KupljeneKarteVM
            {
                redovi = redovi
            };
            return View(m);
        }
        public IActionResult OtkaziKartu(int KartaID)
        {
            var karta = db.Karta.Find(KartaID);
            db.Remove(karta);
            db.SaveChanges();
            return Redirect("KupljeneKarte");
        }
        #region KreditnaKartica
        public IActionResult KreditnaKarticaPrikaz()
        {
            var kartice= new List<KreditnaKarticaPrikazVM.KarticaRedovi>(); 
            if (db.KreditnaKartica.Where(k => k.Kupac.Id == HttpContext.LogiraniKorisnik().Id).Count() > 0)
            {
                kartice = db.KreditnaKartica.Where(k => k.Kupac.Id == HttpContext.LogiraniKorisnik().Id).Select(k => new KreditnaKarticaPrikazVM.KarticaRedovi
                {
                    KreditnaKarticaID = k.KreditnaKarticaID,
                    BrojKartice = k.BrojKartice,
                    DatumIsteka = k.DatumIsteka,
                    ImeVlasnika = k.ImeVlasnikaKartice,
                    VerKod = k.VerifikacijskiKod
                }).ToList();
            }
            var listak= db.KreditnaKartica.Where(k => k.Kupac.Id == HttpContext.LogiraniKorisnik().Id).Select(k => new SelectListItem
            {
               Value=k.KreditnaKarticaID.ToString(),
               Text= k.BrojKartice
            }).ToList();
            var m = new KreditnaKarticaPrikazVM
            {
                Kartice=listak,
                KarticeKupca = kartice
            };
            return PartialView(m); 
            //ako je view onda moze da otvori sa get, a ne moze da ucita ispod onog, a kad je partial onda ucita, al ne otvori vamo fak

        }
       
        public IActionResult KreditnaKarticaObrisi(int KarticaID)
        {
            KreditnaKartica v = db.KreditnaKartica.Find(KarticaID);
            db.Remove(v);
            db.SaveChanges();

            return Redirect("/Karta/KreditnaKarticaPrikaz");
        }
        public IActionResult KreditnaKarticaUredi(int KarticaID)
        {
            KreditnaKarticaUrediVM v = KarticaID == 0 ? new KreditnaKarticaUrediVM() :
                db.KreditnaKartica.Where(v => v.KreditnaKarticaID == KarticaID)
                .Select(v => new KreditnaKarticaUrediVM
                {
                    ImeVlasnika=v.ImeVlasnikaKartice,
                    VerKod=v.VerifikacijskiKod,
                    DatumIsteka=v.DatumIsteka,
                    BrojKartice=v.BrojKartice
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
        #endregion
    }
}