using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePROJE.Controllers
{
    public class NewSletterController : Controller
    {
        NewSletterManagaer nm = new NewSletterManagaer(new EfNewSletterRepository());
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }
        
        [HttpPost]
        public PartialViewResult SubscribeMail(NewSletter p)
        {
            p.MailStatus = true;
            nm.AddNewSletter(p);
            return PartialView();
        }
    }
}
