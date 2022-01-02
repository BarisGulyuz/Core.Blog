using BussinessLayer.Concrete;
using BussinessLayer.EntityFramework;
using CorePROJE.Areas.Admin.Models;
using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePROJE.Areas.Admin.Controllers
{
    [AllowAnonymous]
    public class StatisticsController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/Admin/Statistics/CategoryChart/")]
        public IActionResult CategoryChart()
        {
            var categoryList = categoryManager.GetListWithBlog();
            List<CategoryModel> categories = new();
            foreach (var item in categoryList)
            {
                categories.Add(new CategoryModel
                {
                    CategoryName = item.CategoryName,
                    Count = item.Blogs.Count()
                    
                });
            }
             
            return Json(new { jsonList = categories });
        }

        [Route("/Admin/Statistics/CategoryListChart/")]
        public IActionResult CategoryListChart()
        {
            var categoryList = categoryManager.GetListAll();
            List<CategoryModel> categories = new();
            foreach (var item in categoryList)
            {
                categories.Add(new CategoryModel
                {
                    CategoryName = item.CategoryName,
                    Count = 1

                });
            }
            return Json(new { jsonList = categories });
        }
    }
}
