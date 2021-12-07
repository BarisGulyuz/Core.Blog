using BussinessLayer.Concrete;
using BussinessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace CorePROJE.Areas.Categories.Controllers
{
    [Area("Categories")]
    [AllowAnonymous]
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index(int page = 1)
        {
            var values = cm.GetListAll().Where(x => x.CategoryStatus == true).OrderByDescending(x => x.CategoryId).ToPagedList(page, 10);
            return View(values);
        }
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            category.CategoryStatus = true;
            cm.TAdd(category);
            return RedirectToAction("Index");
        }

        public IActionResult EditCategory(int id)
        {
            var value = cm.GetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditCategory(Category category)
        {
            category.CategoryStatus = true;
            cm.TUpdate(category);
            return RedirectToAction("Index");
        }

        public IActionResult GetCategoryById(int id)
        {
            var value = cm.GetByID(id);
            return View(value);
        }

        public IActionResult DeleteCategory(int id)
        {
            var value = cm.GetByID(id);
            cm.Tdelete(value);
            return RedirectToAction("Index");
        }
    }

}
