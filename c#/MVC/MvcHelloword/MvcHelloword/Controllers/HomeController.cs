using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcHelloword.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        //public string Index()
        //{
        //    return "hello world mvc.";
        //}
        public ActionResult Welcome(string name="")
        {
            ViewBag.name = name;
            return View();
        }
    }
}
