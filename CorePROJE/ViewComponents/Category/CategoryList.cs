using BussinessLayer.Concrete;
using BussinessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePROJE.ViewComponents.Category
{
   
    public class CategoryList: ViewComponent
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IViewComponentResult Invoke(int id)
        {
            var values = cm.GetListAll();
            return View(values);
        }
    }
}
