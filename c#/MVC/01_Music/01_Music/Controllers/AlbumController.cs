using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _01_Music.Models;

namespace _01_Music.Controllers
{
    public class AlbumController : Controller
    {
        //
        // GET: /Album/

        public ActionResult Index()
        {
            ViewBag.Title = "Album page";
            var album = new List<Album>();
            for (int i = 0; i < 10; i++)
            {
                album.Add(new Album { Title = "Product " + i });
            }
            ViewBag.Album = album;

            return View();
        }

        public ActionResult Index1(int id)
        {
            ViewBag.Content = "Id is " + id;
            return View("Browse");
        }
        public ActionResult List()
        {
            var album = new List<Album>();
            for (int i = 0; i < 10; i++)
            {
                album.Add(new Album { Title = "Product " + i });
            }
            

            return View(album);
        }
        public ActionResult Edit()
        {
            return View();
        }
        //局部视图，类似于web中的用户控件
        [ChildActionOnly]
        public ActionResult GenreMenu()
        {
            var album = new List<Album>();
            for (int i = 0; i < 10; i++)
            {
                album.Add(new Album { Title = "Product " + i });
            }

            return PartialView(album);
        }


        public ActionResult Browse(string title)
        {
            ViewBag.Content = "Title is : " + title;

            return View();

        }

        //public string Entry(DateTime entryDate)
        //{
        //    return "You requested the entry from " + entryDate.ToString();
        //}
        public string Entry(string entryDate)
        {
            return "You requested the entry from " + entryDate.ToString();
        }
    }
}
