using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
   public interface IGenericService<T>
    {
        void TAdd(T t);
        void Tdelete(T t);
        void TUpdate(T t);
        List<T> GetListAll();
        T GetByID(int id);
    }
}
