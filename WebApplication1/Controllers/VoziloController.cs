using Microsoft.AspNetCore.Mvc;
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
    public class VoziloController : Controller
    {
        //MojDbContext db = new MojDbContext();
        private readonly ApplicationDbContext db;
        public VoziloController(ApplicationDbContext Db)
        {
            Db = db;
        }
        public IActionResult Prikaz(string pretraga)
        {
            List<VoziloPrikazVM.Row> Vozila = db.Vozilo
                .Where(v => pretraga == null || v.RegistracijskiBroj.StartsWith(pretraga))
                .Select(v => new VoziloPrikazVM.Row
                {
                    VoziloID = v.VoziloID,
                    RegistracijskiBroj = v.RegistracijskiBroj,
                    MaxBrojSjedista = v.MaxBrojSjedista,
                    DatumZadnjegServisa = v.DatumZadnjegServisa
                }).ToList();
            VoziloPrikazVM v = new VoziloPrikazVM();
            v.pretraga = pretraga;
            v.Vozila = Vozila;

            return View(v);
        }  

        public IActionResult Obrisi(int VoziloID)
        {
            Vozilo v = db.Vozilo.Find(VoziloID);
            db.Remove(v);
            db.SaveChanges();

            return Redirect("/Vozilo/Prikaz");
        }

        public IActionResult Uredi(int VoziloID)
        {
            VoziloUrediVM v = VoziloID == 0 ? new VoziloUrediVM() { DatumZadnjegServisa = DateTime.Now } :
                db.Vozilo.Where(v => v.VoziloID == VoziloID)
                .Select(v => new VoziloUrediVM
                {
                    VoziloID = v.VoziloID,
                    RegistracijskiBroj = v.RegistracijskiBroj,
                    MaxBrojSjedista = v.MaxBrojSjedista,
                    DatumZadnjegServisa = v.DatumZadnjegServisa
                }).Single();

            return View("Uredi", v);

        }
        public IActionResult Snimi(VoziloUrediVM x)
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
            vozilo.DatumZadnjegServisa = x.DatumZadnjegServisa;
            vozilo.RegistracijskiBroj = x.RegistracijskiBroj;
            vozilo.MaxBrojSjedista = x.MaxBrojSjedista;

            db.SaveChanges();
            return Redirect("/Vozilo/Prikaz");
        }
    }
}
