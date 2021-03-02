using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Podaci.Klase;
using WebApplication1.Data;
using WebApplication1.Helper;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext db;
        private readonly UserManager<Korisnik> userManager;
        private readonly SignInManager<Korisnik> signInManager;

        public HomeController(ILogger<HomeController> logger, UserManager<Korisnik> um, SignInManager<Korisnik> sm,ApplicationDbContext DB)
        {
            _logger = logger;
            userManager = um;
            signInManager = sm;
            db = DB;
        }
        
        public IActionResult Index()
        {
           return View(); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Authorize]
        public IActionResult DodajMenadzera()
        {
            return View();
        }
        public IActionResult Snimi(string ime, string prezime)
        {
            string email = ime + "." + prezime + "@edu.fit.ba";
            if (db.Users.Where(i => i.Email == email).SingleOrDefault()!=null)
            {
                email= ime + "1." + prezime + "@edu.fit.ba";
            }
            var korisnik = new Menadzer
            {
                Email = email,
                UserName = email,
                Ime = ime,
                Prezime = prezime,
                EmailConfirmed = true,
            };
            IdentityResult result = userManager.CreateAsync(korisnik, "Mostar2020!").Result;

            if (!result.Succeeded)
            {
                 Console.WriteLine("errors: " + string.Join('|', result.Errors));
                return DodajMenadzera();
            }
            Console.WriteLine("Menadzer je uspješno dodat");
            return RedirectToAction("Index");
        }
    }
}
