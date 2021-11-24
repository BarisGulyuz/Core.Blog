using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface ICommentServices
    {
        void CommentAdd(Comment comment);
        //void CategoryDelete(Category category);
        //void CategoryUpdate(Category category);
        List<Comment> GetList(int id);
        //Category GetById(int id);
    }
}
