using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _01_Music.Models;

namespace _01_Music.Controllers
{
    public class HomeController : Controller
    {
        private MusicContext db = new MusicContext();

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
           // ViewBag.Message = "I like cake!";
            //ViewData["Message"] = ViewBag.Message
            return View();
           // return View("About");  //指向具体的某个view
            //return View("~/Views/Example/Index.cshtml"); //provide the full path
        }
        

        public ActionResult About()
        {
            ViewBag.Message = "About ASP.NET MVC!";
            return View();
        }

        public ActionResult Search(string q)
        {
            return View();
        }
        public ActionResult DailyDeal()
        {
            var ablum = db.Albums.OrderBy(a => a.Price).First();
            return PartialView("_DailyDeal",ablum);
        }

        public ActionResult QuickSearch(string q)
        {
            if (q == null) q = "";
           // var artists = db.Artists.Where(a => a.Name.Contains(q)).ToList().Select(a => new { value = a.Name });
            var artists = db.Artists.ToList();
            return Json(artists, JsonRequestBehavior.AllowGet);
            //return View();
        }
    }
}
