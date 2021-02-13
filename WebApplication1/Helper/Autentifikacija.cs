using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Podaci.Klase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Helper
{
    public static class Autentifikacija
    {
        public static Korisnik LogiraniKorisnik(this HttpContext httpContext)
        {
            ApplicationDbContext db = httpContext.RequestServices.GetService<ApplicationDbContext>();

            UserManager<Korisnik> userManager = httpContext.RequestServices.GetService<UserManager<Korisnik>>();
            if(httpContext.User ==null)
            {
                return null;
            }
            string userId = userManager.GetUserId(httpContext.User);
            Korisnik k = db.Menadzer.Where(s => s.Id == userId).SingleOrDefault();
            if (k == null)
            {
                k = db.Kupac.Where(s => s.Id == userId).SingleOrDefault();
            }
            return k;
        }
    }
}
