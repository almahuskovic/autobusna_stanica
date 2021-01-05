using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Podaci.Klase;
using WebApplication1.Data;
using WebApplication1.Models.VrstaPopusta;

namespace WebApplication1.Controllers
{
    public class VrstaPopustaController : Controller
    {
        private readonly ApplicationDbContext db;
        public VrstaPopustaController(ApplicationDbContext Db)
        {
            db = Db;
        }
        public IActionResult Prikaz()
        {
            var m = db.VrstaPopusta.Select(k => new VrstaPopustaPrikazVM()
            {
                VrstaPopustaID = k.VrstaPopustaID,
                Naziv = k.Naziv,
                Iznos=k.Iznos
            }).ToList();
            return View(m);
        }
        public IActionResult Obrisi(int VrstaPopustaID)
        {
            VrstaPopusta k = db.VrstaPopusta.Find(VrstaPopustaID);
            db.Remove(k);
            db.SaveChanges();
            return Redirect("/VrstaPopusta/Prikaz/");
        }
        public IActionResult Uredi(int VrstaPopustaID)
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
        public IActionResult Snimi(VrstaPopustaUrediVM m)
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
            return Redirect("/VrstaPopusta/Prikaz");
        }
    }
}