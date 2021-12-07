using BussinessLayer.Concrete;
using BussinessLayer.EntityFramework;
using ClosedXML.Excel;
using CorePROJE.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace CorePROJE.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());

        public IActionResult AdminBlogList(string blogTitle, int page = 1)
        {
            if (!string.IsNullOrEmpty(blogTitle))
            {
                var listByTitle = bm.GetListBlogWithCategory().Where(x => x.BlogTitle.Contains(blogTitle)).ToPagedList(page, 10);
                return View(listByTitle);
            }
            else
            {
                var values = bm.GetListBlogWithCategory().Where(x => x.BlogStatus == true).OrderByDescending(x => x.BlogCreateDate).ToPagedList(page, 10);
                return View(values);
            }
        }

        public IActionResult ExportEXCEL()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog Id";
                worksheet.Cell(1, 2).Value = "Blog Başlığı";

                int blogRowCount = 2;
                foreach (var item in bm.GetListAll())
                {
                    worksheet.Cell(blogRowCount, 1).Value = item.BlogId;
                    worksheet.Cell(blogRowCount, 2).Value = item.BlogTitle;
                    blogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreads.sheet", "BlogL-Listesi.xlsx");
                }
            }
        }

       //public List<BlogModel> BlogTitles()
       // {
       //     List<BlogModel> blogModels = new List<BlogModel>();
       //     using (var context = new Context())
       //     {
       //         blogModels = context.Blogs.Select(x => new BlogModel
       //         {
       //             Id = x.BlogId,
       //             Title = x.BlogTitle
       //         }).ToList();
       //     }
       //     return blogModels;
       // }
    }
}
