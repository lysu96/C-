using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using onthilai.Models;

namespace onthilai.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<dlsach> sach = new List<dlsach>();
            return View(sach);
        }

        public ActionResult About()
        {
            

            return View();
        }

        public ActionResult Contact()
        {
            

            return View();
        }
    }
}