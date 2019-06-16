using Nhom21_WebsiteDatVeXeKhach.Models.Entities;
using Nhom21_WebsiteDatVeXeKhach.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nhom21_WebsiteDatVeXeKhach.Controllers
{
    public class DatXeController : Controller
    {
        ModelQLBVXK db = new ModelQLBVXK();
        // GET: DatXe
        public ActionResult DatXe()
        {
            if (Session["TAIKHOAN"] == null)
            {
                return RedirectToAction("DangNhap", "ThongTinCaNhan");
            }
            string idXe = RouteData.Values["id"].ToString();
            var xe = db.XEKHACHes.Find(idXe);

            var query = from hx in db.HANGXEs
                        join xk in db.XEKHACHes
                        on hx.ID_HangXe equals xk.ID_HangXe
                        join cx in db.CHUYENXEs
                        on xk.ID_XeKhach equals cx.ID_XeKhach
                        join dden in db.DIEMDENs
                        on cx.ID_DiemDen equals dden.ID_DiemDen
                        join ddi in db.DIEMXUATPHATs
                        on cx.ID_DiemXP equals ddi.ID_DiemXP
                        where xk.ID_XeKhach == xe.ID_XeKhach
                        select new DatVeView
                        {
                            TenHangXe = hx.TenHangXe,
                            ID_XeKhach = xk.ID_XeKhach,
                            HinhAnhXe = xk.HinhAnhXe,
                            SoGheTrong = cx.SoGheTrong,
                            GiaVe = cx.GiaVe,
                            TenDiemDi = ddi.TenDiemXP,
                            TenDiemDen = dden.TenDiemDen,
                            NgayDi = cx.ThoiGianXP,
                            NgayDen = cx.ThoiGianDen,
                            ID_ChuyenXe = cx.ID_ChuyenXe
                        };
            var thongtin = query.ToList<DatVeView>();
            return View(thongtin);
        }

        [HttpPost]
        public ActionResult DatXe(int IdChuyenXe, int SoVe, string ThoiGian, int ID_PTTT)
        {
            int idTaiKhoan = ((TAIKHOAN)Session["TAIKHOAN"]).ID_TaiKhoan;
            var stt = db.THONGTINDATVEs.OrderByDescending(i => i.ID_ThongTinDatVe).First();
            THONGTINDATVE tt = new THONGTINDATVE()
            {
                ID_ThongTinDatVe = stt.ID_ThongTinDatVe + 1,
                SoLuongVe = SoVe,
                ThoiGianDatVe = DateTime.Now,
                LyDoHuyVe = "",
                TrangThaiDatVe = "Đang Chờ Xét",
                ID_TaiKhoan = idTaiKhoan,
                ID_PTTT = ID_PTTT,
                ID_ChuyenXe = IdChuyenXe //ok
            };
            db.THONGTINDATVEs.Add(tt);
            db.SaveChanges();
            ViewBag.SoVe = tt.SoLuongVe;
            ViewBag.ThoiGianDat = tt.ThoiGianDatVe;
            ViewBag.TrangThai = tt.TrangThaiDatVe;
            
            return View("ThongBaoDatVe");
        }
    }
}
