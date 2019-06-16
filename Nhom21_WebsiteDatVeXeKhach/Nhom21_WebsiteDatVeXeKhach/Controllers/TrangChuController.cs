using Nhom21_WebsiteDatVeXeKhach.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom21_WebsiteDatVeXeKhach.Models.ViewModels;

namespace Nhom21_WebsiteDatVeXeKhach.Controllers
{
    public class TrangChuController : Controller
    {
        private ModelQLBVXK db = new ModelQLBVXK();
        // GET: TrangChu
        public ActionResult Index()
        {
            if (Request.IsAuthenticated) return RedirectToAction("DSTaiKhoan", "Admin");
            if (Session["TAIKHOAN"] == null)
            {
                if (Request.Cookies["TenTaiKhoan"] != null)
                {
                    HttpCookie TenTaiKhoan = Request.Cookies["TenTaiKhoan"];
                    HttpCookie MatKhau = Request.Cookies["MatKhau"];
                    var listTK = db.TAIKHOANs.Where(m => m.TenTaiKhoan == TenTaiKhoan.Value && m.MatKhau == MatKhau.Value).ToList();
                    if (listTK.Count != 0)
                    {
                        TAIKHOAN taiKhoan = listTK.First();
                        Session["TAIKHOAN"] = taiKhoan;
                    }
                }
            }

            var listNhaXe = db.HANGXEs.ToList();
            var listDienDen = db.DIEMDENs.ToList();
            var trangChuView = new TrangChuView();
            trangChuView.hangxes = listNhaXe;
            trangChuView.diemden = listDienDen;
            return View(trangChuView);
        }

        public ActionResult TinTuc()
        {
            return View();
        }

        public ActionResult LienHe()
        {
            return View();
        }
    }
}