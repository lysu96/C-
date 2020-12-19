using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using thi.Models;

namespace thi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Khachhang> listkh = Khachhang.GetHocSinh(string.Empty);
            return View(listkh);
        }

        // thêm: HocSinh
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Khachhang kh)
        {
            if (ModelState.IsValid)
            {
                bool ths = Khachhang.them(kh);
                if (ths == true)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Thêm mới thất bại";
                }
            }
            return View();
        }

        // sửa: HocSinh
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            string id = ID.ToString();
            List<Khachhang> listkh = Khachhang.GetHocSinh(id);

            return View(listkh[0]);
        }
        [HttpPost]
        public ActionResult Edit(Khachhang kh)
        {

            if (ModelState.IsValid)
            {
                bool ths = Khachhang.sua(kh);
                if (ths == true)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Sửa mới thất bại";
                }
            }
            else
            {
                ModelState.AddModelError("Fullname", "có lỗi xảy ra");
            }
            return View();
        }

    }
}