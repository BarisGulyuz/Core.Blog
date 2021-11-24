using BussinessLayer.Concrete;
using BussinessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePROJE.Controllers
{
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult PartialAddComment(Comment comment)
        {
            comment.CommentDate = DateTime.Now;
            comment.CommentStatus = true;
            comment.BlogId = 2;
            cm.CommentAdd(comment);
            return PartialView();
        }
        public PartialViewResult PartialCommentListByBlod(int id)
        {
           var values = cm.GetList(id);
            return PartialView();
        }
    }
}
