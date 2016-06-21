using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        [HttpGet]
        public ActionResult Table(int n)
        {
            ViewBag.Name = n;
            return View();

        }
        public ActionResult Index()
        {
            return View();
        }

    }
}
