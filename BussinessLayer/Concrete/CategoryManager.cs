using BussinessLayer.Abstract;
using BussinessLayer.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public Category GetByID(int id)
        {
            return _categoryDal.GetById(id);
        }

        public List<Category> GetListAll()
        {
            return _categoryDal.GetListAll();
        }

        public List<Category> GetListWithBlog()
        {
            return _categoryDal.GetListWihtBlog();
        }

        public void TAdd(Category t)
        {
            _categoryDal.Insert(t);
        }

        public void Tdelete(Category t)
        {
            _categoryDal.Delete(t);
        }

        public void TUpdate(Category t)
        {
            _categoryDal.Update(t);
        }
    }
}
