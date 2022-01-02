using BussinessLayer.Concrete;
using BussinessLayer.EntityFramework;
using CorePROJE.Areas.Admin.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePROJE.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class WriterController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        WriterManager writerManager = new WriterManager(new EfWriterRepository());

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterList()
        {
            List<WriterModel> writers = new();
            var writerData = writerManager.GetListAll();
            foreach (var item in writerData)
            {
                writers.Add(new WriterModel
                {
                    WriterId = item.WriterId,
                    WriterName = item.WriterName,
                });
            }

            var jsonData = JsonConvert.SerializeObject(writers);
            return Json(jsonData);

        }

        public IActionResult GetWriter(int writerId)
        {
            List<WriterModel> writers = new();
            var writerData = writerManager.GetByID(writerId);
            writers.Add(new WriterModel
            {
                WriterId = writerData.WriterId,
                WriterName = writerData.WriterName
            });
            var jsonData = JsonConvert.SerializeObject(writers);
            return Json(jsonData);
        }

    }
}
