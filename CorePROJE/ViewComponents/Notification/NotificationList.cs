using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePROJE.ViewComponents.Notification
{
    public class NotificationList: ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
