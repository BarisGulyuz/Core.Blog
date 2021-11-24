using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CorePROJE.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(Writer p)
        {
            //GİRİŞ1
            //Context c = new Context();
            //var datavalue = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
            //if (datavalue != null)
            //{
            //    HttpContext.Session.SetString("UserName", p.WriterMail);
            //    return RedirectToAction("Index", "Blog");
            //}
            //else
            //{
            //    return View();
            //}

            //GİRİŞ2

            Context c = new Context();
            var datavalue = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
            if (datavalue != null)
            {
                var claims = new List<Claim>
                {
                 new Claim(ClaimTypes.Name, p.WriterMail)
                };
                var userindentity = new ClaimsIdentity(claims, "A");
                ClaimsPrincipal principal = new ClaimsPrincipal(userindentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return View();
            }
        }
    }
}
