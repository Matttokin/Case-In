using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Case_In.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Chat()
        {
            ViewBag.Title = "Чат";

            return View();
        }
    }
}
