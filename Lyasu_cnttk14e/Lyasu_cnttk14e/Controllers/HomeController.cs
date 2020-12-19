using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lyasu_cnttk14e.Models;

namespace Lyasu_cnttk14e.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Message From Đata";
            ViewData["CurrenTime"] = DateTime.Now;
            return View();
        }

        public IActionResult Thongtin()
        {
            ViewData["Tieude"] = "Thông tin sinh viên";
            ViewData["Hoten"] = "Ly A Sú";
            ViewData["Lop"] = "CNTTK_14E";
            

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
