﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _01_Music.Controllers
{
    public class BlogController : Controller
    {
        //
        // GET: /Blog/

        public ActionResult Index(string year,string month,string day)
        {
            ViewBag.content = "year/month/day: " + year +" / " + month +" / "+ day;
            return View();
        }

    }
}