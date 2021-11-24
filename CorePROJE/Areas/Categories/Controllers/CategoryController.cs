using BussinessLayer.Concrete;
using BussinessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePROJE.Areas.Categories.Controllers
{
    [Area("Categories")]
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index()
        {
            var values = cm.GetListAll().Where(x => x.CategoryStatus == true);
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
    }

}
