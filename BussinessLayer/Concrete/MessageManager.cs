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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message2 GetByID(int id)
        {
            return _messageDal.GetById(id);
        }

        public List<Message2> GetInboxByWriter(int id)
        {
            return _messageDal.GetListWithMessageByWriter(id);
        }

        public List<Message2> GetListAll()
        {
            return _messageDal.GetListAll(); //KULLANMA..
        }

        public void TAdd(Message2 t)
        {
            _messageDal.Insert(t);
        }

        public void Tdelete(Message2 t)
        {
            _messageDal.Delete(t);
        }

        public void TUpdate(Message2 t)
        {
            _messageDal.Update(t);
        }
    }
}
