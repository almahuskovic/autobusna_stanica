using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Podaci.Klase;
using WebApplication1.Data;
using WebApplication1.Helper;
using WebApplication1.Models.Menadzer;
using WebApplication1.Models.TipKarte;
using WebApplication1.Models.VrstaPopusta;

namespace WebApplication1.Controllers
{
    //[Authorize]
    [Autorizacija(menadzer:true,kupac:false)]
    public class MenadzerController : Controller
    {
        private readonly ApplicationDbContext db;
        public MenadzerController(ApplicationDbContext DB)
        {
            db = DB;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region Vozac
        public IActionResult VozacPrikaz(string Pretraga)
        {
            var vozaci = db.Vozac.Where(x => Pretraga == null || x.Ime.StartsWith(Pretraga) || x.Prezime.StartsWith(Pretraga))
                .Select(v => new VozacPrikazVM.Row()
                {
                    VozacID = v.VozacID,
                    Ime = v.Ime,
                    Prezime = v.Prezime,
                    DatumZaposlenja = v.DatumZaposlenja,
                    DatumRodjenja = v.DatumRodjenja,
                    BrojVozacke = v.BrojVozacke
                }).ToList();
            VozacPrikazVM m = new VozacPrikazVM()
            {
                Pretraga = Pretraga
            };
            m.Vozaci = vozaci;
            return View(m);
        }
        public IActionResult VozacUredi(int VozacID)
        {
            VozacUrediVM.Row m;
            if (VozacID == 0)
            {
                m = new VozacUrediVM.Row();
                m.DatumRodjenja = DateTime.Now.Date.ToString("dd-MM-yyyy");
                m.DatumZaposlenja = DateTime.Now.Date.ToString();
            }
            else
            {
                m = db.Vozac.Where(v => v.VozacID == VozacID).Select(x => new VozacUrediVM.Row()
                {
                    VozacID = x.VozacID,
                    BrojVozacke = x.BrojVozacke,
                    DatumRodjenja = x.DatumRodjenja,
                    DatumZaposlenja = x.DatumZaposlenja,
                    Ime = x.Ime,
                    Prezime = x.Prezime
                }).Single();
            }
            return View(m);
        }

        public IActionResult VozacSnimi(VozacUrediVM.Row x)
        {
            Vozac v;
            if (x.VozacID == 0)
            {
                v = new Vozac();
                db.Add(v);
            }
            else
            {
                v = db.Vozac.Find(x.VozacID);
            }
            v.VozacID = x.VozacID;
            v.BrojVozacke = x.BrojVozacke;
            v.DatumRodjenja = x.DatumRodjenja;
            v.DatumZaposlenja = x.DatumZaposlenja;
            v.Ime = x.Ime;
            v.Prezime = x.Prezime;
            db.SaveChanges();
            return Redirect("/Menadzer/VozacPrikaz");
        }

        public IActionResult VozacObrisi(int VozacID)
        {
            Vozac v = db.Vozac.Find(VozacID);
            db.Remove(v);
            db.SaveChanges();
            return Redirect("/Menadzer/VozacPrikaz");
        }
        #endregion
        #region Vozilo
        public IActionResult VoziloPrikaz(string pretraga)
        {
            List<VoziloPrikazVM.Row> Vozila = db.Vozilo
                .Where(v => pretraga == null || v.RegistracijskiBroj.ToLower().StartsWith(pretraga.ToLower()) || v.OznakaVozila.ToLower().StartsWith(pretraga.ToLower()))
                .Select(v => new VoziloPrikazVM.Row
                {
                    VoziloID = v.VoziloID,
                    OznakaVozila = v.OznakaVozila,
                    RegistracijskiBroj = v.RegistracijskiBroj,
                    MaxBrojSjedista = v.MaxBrojSjedista,
                    DatumZadnjegServisa = v.DatumZadnjegServisa.ToString()
                }).ToList();
            VoziloPrikazVM v = new VoziloPrikazVM();
            v.pretraga = pretraga;
            v.Vozila = Vozila;

            return View(v);
        }

        public IActionResult VoziloObrisi(int VoziloID)
        {
            Vozilo v = db.Vozilo.Find(VoziloID);
            db.Remove(v);
            db.SaveChanges();

            return Redirect("/Menadzer/VoziloPrikaz");
        }

        public IActionResult VoziloUredi(int VoziloID=0)
        {
            VoziloUrediVM v = VoziloID == 0 ? new VoziloUrediVM() { DatumZadnjegServisa = DateTime.Now.Date.ToString() } :
                db.Vozilo.Where(v => v.VoziloID == VoziloID)
                .Select(v => new VoziloUrediVM
                {
                    VoziloID = v.VoziloID,
                    OznakaVozila = v.OznakaVozila,
                    RegistracijskiBroj = v.RegistracijskiBroj,
                    MaxBrojSjedista = v.MaxBrojSjedista,
                    DatumZadnjegServisa = v.DatumZadnjegServisa
                }).Single();

            return View(v);

        }
        public IActionResult VoziloSnimi(VoziloUrediVM x)
        {
            Vozilo vozilo;
            if (x.VoziloID == 0)
            {
                vozilo = new Vozilo();
                db.Add(vozilo);

            }
            else
            {
                vozilo = db.Vozilo.Find(x.VoziloID);
            }
            vozilo.OznakaVozila = x.OznakaVozila;
            vozilo.DatumZadnjegServisa = x.DatumZadnjegServisa;
            vozilo.RegistracijskiBroj = x.RegistracijskiBroj;
            vozilo.MaxBrojSjedista = x.MaxBrojSjedista;

            db.SaveChanges();
            return Redirect("/Menadzer/VoziloPrikaz");
        }
        #endregion
        #region Obavijest
        public IActionResult ObavijestPrikaz()
        {
            List<ObavijestPrikazVM.Row> obavijesti = db.Obavijest.OrderByDescending(d => d.DatumObjave).Select(o => new ObavijestPrikazVM.Row
            {
                ObavijestID = o.ObavijestID,
                Naslov = o.Naslov,
                Podnaslov = o.Podnaslov,
                Opis = o.Opis.Substring(0,100),
                DatumObjave = o.DatumObjave,
                ObavijestKategorija = o.ObavijestKategorija.Naziv,
                Slika = KonvertovanjeSlike.GetImageBase64(o.Slika)
            }).ToList();
            ObavijestPrikazVM m = new ObavijestPrikazVM();
            m.obavijesti = obavijesti;

            return View(m);
        }

        public IActionResult ObavijestUredi(int ObavijestID)
        {
            List<SelectListItem> ok = db.ObavijestKategorija.OrderBy(n => n.Naziv).Select(k => new SelectListItem
            {
                Text = k.Naziv,
                Value = k.ObavijestKategorijaID.ToString()
            }).ToList();

            ObavijestUrediVM m;
            if (ObavijestID == 0)
            {
                m = new ObavijestUrediVM
                {
                    DatumObjave = DateTime.Now.ToString(),
                    Kategorije = ok,
                };
            }
            else
            {
                m = db.Obavijest.Where(o => o.ObavijestID == ObavijestID).Select(k => new ObavijestUrediVM
                {
                    ObavijestID = k.ObavijestID,
                    Naslov = k.Naslov,
                    Podnaslov = k.Podnaslov,
                    Opis = k.Opis,
                    DatumObjave = DateTime.Now.Date.ToString(),
                    KategorijaID = k.ObavijestKategorijaID,
                    Kategorije = ok,
                    Slika = KonvertovanjeSlike.GetImageBase64(k.Slika)
                }).Single();
            }
            return View(m);
        }
        [HttpPost]
        public IActionResult ObavijestSnimi(ObavijestUrediVM x, IFormFile file)
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
            return Redirect("/Menadzer/ObavijestPrikaz");
        }
        public IActionResult ObavijestObrisi(int ObavijestID)
        {
            Obavijest o = db.Obavijest.Find(ObavijestID);
            db.Remove(o);
            db.SaveChanges();
            return Redirect("/Menadzer/ObavijestPrikaz");
        }
        #endregion
        #region ObavijestKategorija
        public IActionResult ObavijestKategorijaPrikaz()
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
        public IActionResult ObavijestKategorijaUredi(int ObavijestID)
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
        
        public IActionResult ObavijestKategorijaSnimi(ObavijestKategorijaUrediVM x)
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

           
            return Redirect("/Menadzer/ObavijestKategorijaPrikaz");
        }
        
        public IActionResult ObavijestKategorijaObrisi(int ObavijestID)
        {
            var m = db.ObavijestKategorija.Find(ObavijestID);
            db.Remove(m);
            db.SaveChanges();
            return Redirect("/Menadzer/ObavijestKategorijaPrikaz");
        }
        #endregion
        #region TipKarte
        public IActionResult TipKartePrikaz()
        {
            var m = db.TipKarte.Select(k => new TipKartePrikazVM()
            {
                TipKarteID = k.TipKarteID,
                Naziv = k.Naziv
            }).ToList();
            return View(m);
        }
        public IActionResult TipKarteObrisi(int TipKarteID)
        {
            TipKarte k = db.TipKarte.Find(TipKarteID);
            db.Remove(k);
            db.SaveChanges();
            return Redirect("/Menadzer/TipKartePrikaz/");
        }
        public IActionResult TipKarteUredi(int TipKarteID)
        {
            TipKarteUrediVM m;
            if (TipKarteID == 0)
            {
                m = new TipKarteUrediVM();
            }
            else
            {
                m = db.TipKarte.Where(k => k.TipKarteID == TipKarteID).Select(i => new TipKarteUrediVM()
                {
                    Naziv = i.Naziv,
                    TipKarteID = i.TipKarteID
                }).SingleOrDefault();
            }
            return View(m);
        }
        public IActionResult TipKarteSnimi(TipKarteUrediVM m)
        {
            TipKarte karta;
            if (m.TipKarteID == 0)
            {
                karta = new TipKarte();
                db.TipKarte.Add(karta);
            }
            else
            {
                karta = db.TipKarte.Find(m.TipKarteID);
            }
            karta.Naziv = m.Naziv;
            karta.TipKarteID = m.TipKarteID;
            db.SaveChanges();
            return Redirect("/Menadzer/TipKartePrikaz");
        }
        #endregion
        #region VrstaPopusta
        public IActionResult VrstaPopustaPrikaz()
        {
            var m = db.VrstaPopusta.Select(k => new VrstaPopustaPrikazVM()
            {
                VrstaPopustaID = k.VrstaPopustaID,
                Naziv = k.Naziv,
                Iznos = k.Iznos
            }).ToList();
            return View(m);
        }
        public IActionResult VrstaPopustaObrisi(int VrstaPopustaID)
        {
            VrstaPopusta k = db.VrstaPopusta.Find(VrstaPopustaID);
            db.Remove(k);
            db.SaveChanges();
            return Redirect("/Menadzer/VrstaPopustaPrikaz/");
        }
        public IActionResult VrstaPopustaUredi(int VrstaPopustaID)
        {
            VrstaPopustaUrediVM m;
            if (VrstaPopustaID == 0)
            {
                m = new VrstaPopustaUrediVM();
            }
            else
            {
                m = db.VrstaPopusta.Where(k => k.VrstaPopustaID == VrstaPopustaID).Select(i => new VrstaPopustaUrediVM()
                {
                    VrstaPopustaID = i.VrstaPopustaID,
                    Naziv = i.Naziv,
                    Iznos = i.Iznos
                }).SingleOrDefault();
            }
            return View(m);
        }
        public IActionResult VrstaPopustaSnimi(VrstaPopustaUrediVM m)
        {
            VrstaPopusta popust;
            if (m.VrstaPopustaID == 0)
            {
                popust = new VrstaPopusta();
                db.VrstaPopusta.Add(popust);
            }
            else
            {
                popust = db.VrstaPopusta.Find(m.VrstaPopustaID);
            }
            popust.VrstaPopustaID = m.VrstaPopustaID;
            popust.Naziv = m.Naziv;
            popust.Iznos = m.Iznos;

            db.SaveChanges();
            return Redirect("/Menadzer/VrstaPopustaPrikaz");
        }
        #endregion

        #region LinijaVozac
        public IActionResult LinijaVozacPrikaz(int LinijaID)
        {
            var redovi = db.LinijaVozac.Include(s => s.Vozac).Include(l => l.Linija).Where(i => i.LinijaID == LinijaID).Select(i => new LinijaVozacPrikazVM.Row
            {
                VozacID = i.VozacID,
                ImePrezime = i.Vozac.Ime + " " + i.Vozac.Prezime,
            }).ToList();
            var m = new LinijaVozacPrikazVM()
            {
                LinijaID=LinijaID,
                NazivLinije = db.Linija.Where(i => i.LinijaID == LinijaID).FirstOrDefault().OznakaLinije,
                redovi = redovi
            };

            return View(m);
        }
        public IActionResult LinijaVozacUkloni(int LinijaID,int VozacID)
        {
            var x = db.LinijaVozac.Where(i => i.LinijaID == LinijaID && i.VozacID == VozacID).SingleOrDefault();
            db.Remove(x);
            db.SaveChanges();
            return Redirect("/Menadzer/LinijaVozacPrikaz?LinijaID=" + x.LinijaID);
        }
        public IActionResult LinijaVozacDodaj(int LinijaID)
        {
            List<SelectListItem> vozaci=new List<SelectListItem>();
            foreach(var i in db.Vozac)
            {
                var linija = db.LinijaVozac.Where(l => l.LinijaID == LinijaID && l.VozacID == i.VozacID).SingleOrDefault();
                if (linija == null)
                {
                    SelectListItem item = new SelectListItem
                    {
                        Value = i.VozacID.ToString(),
                        Text = i.Ime + " " + i.Prezime
                    };
                    vozaci.Add(item);
                }
            }
            var m = new LinijaVozacDodajVM
            {
                LinijaID = LinijaID,
                Vozaci = vozaci
            };
            return View(m);
        }
        public IActionResult LinijaVozacSnimi(LinijaVozacDodajVM x)
        {
            LinijaVozac vm = new LinijaVozac
            {
                LinijaID = x.LinijaID,
                VozacID = x.VozacID
            };
            db.LinijaVozac.Add(vm);
            db.SaveChanges();
            return Redirect("/Menadzer/LinijaVozacPrikaz?LinijaID="+x.LinijaID);
        }
        #endregion
        #region Izvjestaj
        #endregion
    }
}