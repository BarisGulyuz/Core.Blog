using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePROJE.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        [Area("Admin")]

        public PartialViewResult AdminNavbarPartial()
        {
            return PartialView();
        }
    }
}
