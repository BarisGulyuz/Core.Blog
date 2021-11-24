using BussinessLayer.Concrete;
using BussinessLayer.EntityFramework;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePROJE.Controllers
{
    public class DashboardController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());

        [Authorize]
        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            Context c = new Context();
            var writer = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();

            //Toplam Blog Sayısı
            ViewBag.BlogSayısı = bm.GetListAll().Count();
            //Yazar Ait Blog Sayısı
            ViewBag.YazarBlogSayısı = bm.GetBlogListWithWriter(writer).Count();
            //Toplam Kategori Sayısı
            ViewBag.KategoriSayısı = cm.GetListAll().Count();
            return View();
        }
    }
}
