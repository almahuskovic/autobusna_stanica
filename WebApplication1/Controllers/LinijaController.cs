using Microsoft.AspNetCore.Mvc;
using Podaci;
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
                .Where(l => pretraga == null || l.OznakaLinije.ToLower().StartsWith(pretraga.ToLower()) || l.GradPolaska.Naziv.ToLower().StartsWith(pretraga.ToLower()) || l.GradDolaska.Naziv.ToLower().StartsWith(pretraga.ToLower()))
                .Select(l => new LinijaPrikazVM.Row
                {
                    LinijaID = l.LinijaID,
                    OznakaLinije = l.OznakaLinije,
                    GDolaskaID=l.GDolaskaID,
                    GradDolaska = l.GradDolaska.Naziv,
                    GPolaskaID=l.GPolaskaID,
                    GradPolaska = l.GradPolaska.Naziv,
                    CijenaJednosmijerna = l.CijenaJednosmijerna,
                    CijenaPovratna = l.CijenaPovratna
                }).ToList();

            LinijaPrikazVM l = new LinijaPrikazVM();
            l.Linije = Linije;
            l.pretraga = pretraga;

            return View(l);
        }
        
    }
}
