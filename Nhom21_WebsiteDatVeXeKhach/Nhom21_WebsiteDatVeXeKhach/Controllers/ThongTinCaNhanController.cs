using Nhom21_WebsiteDatVeXeKhach.Models.Entities;
using Nhom21_WebsiteDatVeXeKhach.Models.Functions;
using Nhom21_WebsiteDatVeXeKhach.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Nhom21_WebsiteDatVeXeKhach.Controllers
{
    public class ThongTinCaNhanController : Controller
    {
        private ModelQLBVXK db = new ModelQLBVXK();
        // GET: ThongTinCaNhanController
        public ActionResult DangNhap()
        {
            if (Session["TAIKHOAN"] != null)
            {
                return RedirectToAction("Index", "TrangChu");
            }
            Session["TrangTruoc"] = Request.UrlReferrer;
            return View(new TaiKhoanDangNhapView());
        }

        public ActionResult DangKy()
        {
            if (Session["TAIKHOAN"] != null)
            {
                return RedirectToAction("Index", "TrangChu");
            }
            return View(new TaiKhoanDangKyView());
        }

        public ActionResult DangKyThanhCong()
        {
            return View(new TAIKHOAN());
        }

        public ActionResult ThongTinCaNhan()
        {
            if (Session["TAIKHOAN"] == null) return Redirect("DangNhap");
            var TaiKhoan = (TAIKHOAN)Session["TAIKHOAN"];
            var TaiKhoanCaNhan = new TaiKhoanDangKyView
            {
                TenTaiKhoan = TaiKhoan.TenTaiKhoan,
                MatKhau = TaiKhoan.MatKhau,
                XacNhanMatKhau = TaiKhoan.MatKhau,
                HoTen = TaiKhoan.HoTen,
                SoDienThoai = TaiKhoan.SoDT,
                Email = TaiKhoan.Email
            };
            return View(TaiKhoanCaNhan);
        }

        public ActionResult LichSuDatVe()
        {
            if (Session["TAIKHOAN"] == null) return Redirect("DangNhap");
            TAIKHOAN taiKhoan = (TAIKHOAN)Session["TAIKHOAN"];
            DateTime dateHomNay = DateTime.Now.AddDays(-1);
            var listLichSu = db.THONGTINDATVEs.Where(dp => dp.ID_TaiKhoan == taiKhoan.ID_TaiKhoan).Join(
                db.CHUYENXEs, dp => dp.ID_ChuyenXe, p => p.ID_ChuyenXe, (dp, p) => new
                {
                    MaDatVe = dp.ID_ThongTinDatVe,
                    MaXeKhach = p.ID_XeKhach,
                    ThoiGianDatVe = dp.ThoiGianDatVe,
                    SoLuongVe = dp.SoLuongVe,
                    ThoiGianXP = p.ThoiGianXP,
                    ThoiGianDen = p.ThoiGianDen,
                    GiaVe = p.GiaVe,
                    ThanhTien = p.GiaVe*dp.SoLuongVe,
                    TrangThaiDatVe = dp.TrangThaiDatVe
                }).AsEnumerable().Select(m =>
                    new LichSuDatVeView()
                    {
                        MaDatVe = m.MaDatVe,
                        MaXeKhach = m.MaXeKhach,
                        ThoiGianDatVe = m.ThoiGianDatVe.Value.ToString("dd/MM/yyyy"),
                        SoLuongVe = m.SoLuongVe,
                        ThoiGianXP = m.ThoiGianXP.Value,
                        ThoiGianDen = m.ThoiGianDen.Value,
                        GiaVe = m.GiaVe,
                        ThanhTien = m.GiaVe*m.SoLuongVe,
                        TrangThaiDatVe = m.TrangThaiDatVe
                    }).ToList();
            return View(listLichSu);
        }

        public ActionResult XoaDatVe()
        {
            int MaHuy = Convert.ToInt16(RouteData.Values["id"].ToString());
            var HamDP = new HamDatVe();
            HamDP.Delete(MaHuy);
            return RedirectToAction("LichSuDatVe", "ThongTinCaNhan");
        }

        public ActionResult DangXuat()
        {
            Session["TAIKHOAN"] = null;
            HttpCookie ckTaiKhoan = new HttpCookie("TenTaiKhoan"), ckMatKhau = new HttpCookie("MatKhau");
            ckTaiKhoan.Expires = DateTime.Now.AddDays(-1);
            ckMatKhau.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(ckTaiKhoan);
            Response.Cookies.Add(ckMatKhau);
            return RedirectToAction("Index", "TrangChu");
        }

        [HttpPost]
        public ActionResult DangNhap(TaiKhoanDangNhapView tk)
        {
            if (ModelState.IsValid)
            {
                var list = db.TAIKHOANs.Where(m => m.TenTaiKhoan == tk.TenTaiKhoan && m.MatKhau == tk.MatKhau).ToList();
                if (list.Count == 0)
                {
                    ModelState.AddModelError("TenTaiKhoan", "Tài Khoản hoặc Mật Khẩu không chính xác");
                    return View(tk);
                }
                TAIKHOAN taiKhoan = list.First();
                if (taiKhoan.ID_Quyen == 1)
                {
                    FormsAuthentication.SetAuthCookie(taiKhoan.HoTen, tk.TuDongDangNhap);
                    return RedirectToAction("listTaiKhoan", "Admin");
                }
                Session["TAIKHOAN"] = taiKhoan;
                if (tk.TuDongDangNhap)
                {
                    HttpCookie ckTaiKhoan = new HttpCookie("TenTaiKhoan"), ckMatKhau = new HttpCookie("MatKhau");
                    ckTaiKhoan.Value = taiKhoan.TenTaiKhoan; ckMatKhau.Value = taiKhoan.MatKhau;
                    ckTaiKhoan.Expires = DateTime.Now.AddDays(15);
                    ckMatKhau.Expires = DateTime.Now.AddDays(15);
                    Response.Cookies.Add(ckTaiKhoan);
                    Response.Cookies.Add(ckMatKhau);
                }
                if (Session["TrangTruoc"] != null)
                {
                    return Redirect(Session["TrangTruoc"].ToString());
                }
                return RedirectToAction("Index", "TrangChu");
            }
            return View(tk);
        }

        [HttpPost]
        public ActionResult DangKy(TaiKhoanDangKyView tk)
        {
            var stt = db.TAIKHOANs.OrderByDescending(i => i.ID_TaiKhoan).First();
            if (ModelState.IsValid)
            {
                var taiKhoan = db.TAIKHOANs.Find(tk.ID_TaiKhoan);
                if (taiKhoan != null)
                {
                    ModelState.AddModelError("TenTaiKhoan", "Tài Khoản đã tồn tại");
                    return View(tk);
                }
                taiKhoan = new TAIKHOAN()
                {
                    ID_TaiKhoan = stt.ID_TaiKhoan + 1,
                    TenTaiKhoan = tk.TenTaiKhoan,
                    MatKhau = tk.MatKhau,
                    HoTen = tk.HoTen,
                    NgaySinh = DateTime.Now,
                    DiaChi = "",
                    SoDT = tk.SoDienThoai,
                    Email = tk.Email,
                    ID_Quyen = 2
                };
                var hTK = new HamTaiKhoan();
                hTK.Insert(taiKhoan);
                return View("DangKyThanhCong", taiKhoan);
            }
            return View(tk);
        }

        [HttpPost]
        public ActionResult ThongTinCaNhan(TaiKhoanDangKyView tk)
        {
            var ls = db.TAIKHOANs.Where(i => i.TenTaiKhoan == tk.TenTaiKhoan).ToList();
            if (ModelState.IsValid)
            {
                var taiKhoan = new TAIKHOAN()
                {
                    ID_TaiKhoan = ls[0].ID_TaiKhoan,
                    TenTaiKhoan = tk.TenTaiKhoan,
                    MatKhau = tk.MatKhau,
                    HoTen = tk.HoTen,
                    NgaySinh = DateTime.Now,
                    DiaChi = "",
                    SoDT = tk.SoDienThoai,
                    Email = tk.Email,
                    ID_Quyen = 2
                };
                Session["TAIKHOAN"] = taiKhoan;
                var HamTK = new HamTaiKhoan();
                HamTK.Update(taiKhoan);
                ViewBag.Success = 1;
            }
            return View(tk);
        }
    }
}