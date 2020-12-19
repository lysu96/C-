using BanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanHang.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            List<SanPham> list = new List<SanPham>();
            list = SanPham.LaySanPham(null);

            return View(list);
        }
        public ActionResult SanPhamGiaNhomHon500()
        {
            List<SanPham> list = new List<SanPham>();
            list = SanPham.LaySanPhamGiaNhoHon("500000");

            return View(list);
        }
        //[HttpPost]
        //public ActionResult timkiem()
        //{
        //    String ten = Request["ten"]; 
        //    ViewBag.ten = ten ;
        //    List<SanPham> list = new List<SanPham>();
        //    list = SanPham.TimTheoTen(ten);
        //    return View(list);
        //}
        [HttpPost]
        public ActionResult timkiem()
        {
            String ten = Request["ten"];
            ViewBag.ten = ten;
            List<SanPham> list = new List<SanPham>();
            list = SanPham.TimTheoTen(ten);
            return View(list);
        }
        [HttpGet]
        public ActionResult Edit(String id)
        {
           
            try
            {
                int.Parse(id);
              
                    List<SanPham> list = new List<SanPham>();
                    list = SanPham.LaySanPham(id);
                    ViewBag.listdanhmuc = DanhMuc.LayDanhMuc(null);
                    return View(list[0]);
                
            }
            catch (Exception) { }
           

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(SanPham sp)
        {
            if (ModelState.IsValid==true)
            {
               if( SanPham.SuaSanPham(sp)==true)
                return RedirectToAction("Index");
                else
                {
                    return View();
                }
            }
            else return View();
        }
    }
}