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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerdal;

        public WriterManager(IWriterDal writerdal)
        {
            _writerdal = writerdal;
        }

        public Writer GetByID(int id)
        {
          return _writerdal.GetById(id);
        }

        public List<Writer> GetListAll()
        {
            return _writerdal.GetListAll();
        }

        public void TAdd(Writer t)
        {
            _writerdal.Insert(t);
        }

        public void Tdelete(Writer t)
        {
            _writerdal.Delete(t);
        }

        public void TUpdate(Writer t)
        {
            _writerdal.Update(t);
        }

        public void WriterAdd(Writer t)
        {
            _writerdal.Insert(t);
        }
    }
}
