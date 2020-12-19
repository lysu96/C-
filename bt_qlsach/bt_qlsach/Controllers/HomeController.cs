using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bt_qlsach.Models;
using MySql.Data.MySqlClient;

namespace bt_qlsach.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult QLSach()
        {
            List<Sach> obj = Sach.getSach(string.Empty);
            return View(obj);
        }
    }
}