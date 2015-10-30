using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OliApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            using (var db = new OliModel())
            {
                var ps = db.PostIt.OrderByDescending(p=>p.Datum).Take(5).ToList();
                return View(ps);

            }

        }
    }
}
