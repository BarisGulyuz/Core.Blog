using BussinessLayer.Concrete;
using BussinessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePROJE.ViewComponents.Category
{
    public class CategoryListDashboard: ViewComponent
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IViewComponentResult Invoke(int id)
        {
            var values = cm.GetListAll();
            return View(values);
        }
    }
}
