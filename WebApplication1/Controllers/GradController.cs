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
using WebApplication1.Models.Grad;

namespace WebApplication1.Controllers
{
    public class GradController : Controller
    {
        private readonly ApplicationDbContext db;
        public GradController(ApplicationDbContext Db)
        {
            Db=db;
        }
        
        public IActionResult Prikaz(string pretraga)
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

        public IActionResult Obrisi(int GradID)
        {
            Grad g = db.Grad.Find(GradID);
            db.Remove(g);
            db.SaveChanges();
            return Redirect("/Grad/Prikaz");
        }

        public IActionResult Uredi(int GradID)
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

            return View("Uredi", g);

        }
        public IActionResult Snimi(GradDodajVM x)
        {
            //MojDbContext db = new MojDbContext();

            Grad grad;
            if (x.GradID== 0)
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
            return Redirect("/Grad/Prikaz");

        }
    }
}
