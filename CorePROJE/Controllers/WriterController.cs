using BussinessLayer.Concrete;
using BussinessLayer.EntityFramework;
using BussinessLayer.ValidationRules;
using CorePROJE.Models;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace CorePROJE.Controllers
{
    
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
       
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Test()
        {
            return View();
        }
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
        public IActionResult WriterEditProfile()
        {
            var usermail = User.Identity.Name;
            Context c = new Context();
            var writer = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).SingleOrDefault();
            var writervalues = wm.GetByID(writer);
            return View(writervalues);
        }
        [HttpPost]
        public IActionResult WriterEditProfile(Writer writer, ProfileImage profileImage, IFormFile WriterImage)
        {
            WriterValidator vl = new WriterValidator();
            ValidationResult result = vl.Validate(writer);
            if (result.IsValid)
            {
                if(profileImage.WriterImage != null)
                {
                    var extension = Path.GetExtension(profileImage.WriterImage.FileName);
                    var newImageName = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Upload/Writer/",newImageName);
                    var stream = new FileStream(location, FileMode.Create);
                    profileImage.WriterImage.CopyTo(stream);
                    writer.WriterImage = newImageName;
                }
             
                writer.WriterStatus = true;
                wm.TUpdate(writer);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.ErrorMessage, item.PropertyName);
                }
            }
            return View();
        }
    }
}
