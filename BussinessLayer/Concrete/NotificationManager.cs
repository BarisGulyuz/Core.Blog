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
    public class NotificationManager : INotificationService
    {
        INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public Notification GetByID(int id)
        {
            return _notificationDal.GetById(id);
           
        }

        public List<Notification> GetListAll()
        {
            return _notificationDal.GetListAll();
        }

        public void TAdd(Notification t)
        {
            _notificationDal.Insert(t);
        }

        public void Tdelete(Notification t)
        {
            _notificationDal.Delete(t);
        }

        public void TUpdate(Notification t)
        {
            _notificationDal.Update(t);
        }
    }
}
