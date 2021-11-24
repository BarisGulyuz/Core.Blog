using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public List<Blog> GetListWithCatandWriter(int id)
        {
            return _blogDal.GetListWithCategoryByWriter(id);
        }

        public List<Blog> GetListBlogWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

        public List<Blog> GetBlogById(int id)
        {
            return _blogDal.GetListAll(x => x.BlogId == id);
        }

        public List<Blog> GetLast3Post()
        {
            return _blogDal.GetListAll().OrderByDescending(x => x.BlogCreateDate).Take(3).ToList();
        }
        public List<Blog> GetBlogListWithWriter(int id)
        {
            return _blogDal.GetListAll(x => x.WriterId == id);
        }

        public void TAdd(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void Tdelete(Blog t)
        {
            _blogDal.Delete(t);
        }

        public void TUpdate(Blog t)
        {
            _blogDal.Update(t);
        }

        public List<Blog> GetListAll()
        {
            return _blogDal.GetListAll();
        }

        public Blog GetByID(int id)
        {
            return _blogDal.GetById(id);
        }
    }
}
