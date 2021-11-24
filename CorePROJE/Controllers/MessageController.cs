using BussinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePROJE.Controllers
{
    public class MessageController : Controller
    {
       
        MessageManager mm = new MessageManager(new EfMessageRepository());
        public IActionResult Inbox()
        {
            var usermail = User.Identity.Name;
            Context c = new Context();
            var writer = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();
            var values = mm.GetInboxByWriter(writer);
            return View(values);
        }
    }
}
