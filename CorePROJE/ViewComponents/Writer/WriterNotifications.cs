using BussinessLayer.Concrete;
using BussinessLayer.EntityFramework;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePROJE.ViewComponents.Writer
{
    public class WriterNotifications: ViewComponent
    {
        NotificationManager nm = new NotificationManager(new EfNotificationRepository());
        public IViewComponentResult Invoke()
        {
            var values = nm.GetListAll().Where(x=> x.Status == true).OrderByDescending(x=> x.NotificationDate).Take(5);
            return View(values);
        }
    }
}
