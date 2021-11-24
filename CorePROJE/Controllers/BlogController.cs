using BussinessLayer.Concrete;
using BussinessLayer.EntityFramework;
using BussinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePROJE.Controllers
{
    
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
       

        public IActionResult Index()
        {
            var values = bm.GetListBlogWithCategory();
            return View(values);
        }

        public IActionResult BlogDetails(int id)
        {
            ViewBag.i = id;
            var values = bm.GetBlogById(id);
            return View(values);
        }

        public IActionResult BlogListByWriter()
        {
            var usermail = User.Identity.Name;
            Context c = new Context();
            var writer = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).SingleOrDefault();
            var values = bm.GetListWithCatandWriter(writer);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddBlog()
        {
            CategoryManager cm = new CategoryManager(new EfCategoryRepository());

            List<SelectListItem> cat = (from x in cm.GetListAll()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryId.ToString()
                                             }
                                             ).ToList();
            ViewBag.category = cat;
            return View();
        }
        [HttpPost]
        public IActionResult AddBlog(Blog blog)
        {
            var usermail = User.Identity.Name;
            Context c = new Context();
            var writer = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).SingleOrDefault();
            CategoryManager cm = new CategoryManager(new EfCategoryRepository());
            List<SelectListItem> cat = (from x in cm.GetListAll()
                                        select new SelectListItem
                                        {
                                            Text = x.CategoryName,
                                            Value = x.CategoryId.ToString()
                                        }
                                             ).ToList();
            ViewBag.category = cat;

            BlogValidator wv = new BlogValidator();
            ValidationResult result = wv.Validate(blog);
            if (result.IsValid)
            {
 
                blog.BlogCreateDate = DateTime.Now;
                blog.BlogStatus = true;
                blog.WriterId = writer;
                bm.TAdd(blog);
                return RedirectToAction("BlogListByWriter");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    return View();
                }
            }
            return View();
           
        }

        public IActionResult BlogDelete(int id)
        {
            var values = bm.GetByID(id);
            bm.Tdelete(values);
            return RedirectToAction("BlogListByWriter");
        }

        public IActionResult Edit(int id)
        {
            CategoryManager cm = new CategoryManager(new EfCategoryRepository());
            List<SelectListItem> categoryedit = (from x in cm.GetListAll()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryId.ToString()
                                             }
                                            ).ToList();
            ViewBag.cv = categoryedit;
            var values = bm.GetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult Edit(Blog blog, int id)
        {
            var usermail = User.Identity.Name;
            Context c = new Context();
            var writer = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).SingleOrDefault();
            blog.WriterId = writer;
            blog.BlogStatus = true;
            bm.TUpdate(blog);
            return RedirectToAction("BlogListByWriter");
        }

    }
}
