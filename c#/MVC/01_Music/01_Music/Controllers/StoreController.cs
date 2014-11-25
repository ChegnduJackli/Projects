using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _01_Music.Controllers
{
    public class StoreController : Controller
    {
        //
        // GET: /Store/

        //public ActionResult Index()
        //{
        //    return View();
        //}
        public string index()
        {
            return "hello from store.index()";
        }

        //
        // GET: /Store/Details
        //url ? genre ="xxxx"
        public string Details(string genre)
        {
            string message = HttpUtility.HtmlEncode("store.Browse,Genre=" + genre);
            return message;
        }
        //
        // GET: /Store/Details_1/5
        public string Details_1(int id)
        {
            string message = HttpUtility.HtmlEncode("store.Browse,Genre=" + id);
            return message;
        }

        //
        // GET: /Store/Create

        public string Browse()
        {
            return "hello from store.browse()";
        }

   
      
    }
}
