using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OliApi.Models;

namespace OliApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            var oim = new OliIndexModel();
            using (var db = new OliModel())
            {
                var ps = db.PostIt.OrderByDescending(p=>p.Datum).Take(5).ToList();
                var ts = db.TopLab.Where(t=>t.TopLabParent == null).OrderByDescending(t => t.Datum).Take(5).ToList();
                oim.PostIts = ps;
                oim.TopLabs = ts;
                return View(oim);
            }
        }
    }
}
