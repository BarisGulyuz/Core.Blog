using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinessLayer.Concrete;
using BussinessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CorePROJE.ViewComponents.Blog
{
    public class BlogListDashboard: ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IViewComponentResult Invoke()
        {
            var values = bm.GetListBlogWithCategory().Take(5);
            return View(values);
        }
    }
}
