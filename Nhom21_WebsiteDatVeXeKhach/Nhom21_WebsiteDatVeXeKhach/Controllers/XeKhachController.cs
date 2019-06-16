using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom21_WebsiteDatVeXeKhach.Models.Entities;
using Nhom21_WebsiteDatVeXeKhach.Models.ViewModels;

namespace Nhom21_WebsiteDatVeXeKhach.Controllers
{
    public class XeKhachController : Controller
    {
        private ModelQLBVXK db = new ModelQLBVXK();
        // GET: XeKhach
        public ActionResult DSXeKhach()
        {
            var listXe = db.XEKHACHes.ToList();
            return View(listXe);
        }

        public ActionResult XeKhach()
        {
            ViewBag.Success = 0;
            int id = Convert.ToInt32(RouteData.Values["id"]);
            var lsxk = db.XEKHACHes.Where(i => i.ID_HangXe == id).ToList();
            var lshx = db.HANGXEs.Where(i => i.ID_HangXe == id).ToList();
            XEKHACH lp;
            HANGXE hx;
            if (lsxk == null)
            {
                return View();
            }
            else
            {
                lp = lsxk[0];
            }
            if (lsxk == null)
            {
                return View();
            }
            else
            {
                hx = lshx[0];

            }
            if (lp == null)
            {
                return View(new List<CHUYENXE>());
            }
            ViewBag.Success = 1;
            ViewBag.Logo = hx.LogoHangXe;
            ViewBag.TenNhaXe = hx.TenHangXe;
            ViewBag.ThongTin = hx.ThongTinHangXe;
            ViewBag.ID_HangXe = lp.ID_HangXe;
            ViewBag.ID_XeKhach = lp.ID_XeKhach;
            ViewBag.DuongDanAnh = lp.HinhAnhXe;
            ViewBag.SoGhe = lp.SoGhe;
            ViewBag.MoTa = lp.MoTa;
            var listXe = db.XEKHACHes.Where(m => m.ID_HangXe == id).ToList();
            return View(listXe);
        }

        public ActionResult TimKiem()
        {
            string diemDiTimKiem = Request.QueryString["DiemDi"];
            string diemDenTimKiem = Request.QueryString["DiemDen"];
            string ngayDi = Request.QueryString["ngayDi"];
            if (diemDiTimKiem == "") diemDiTimKiem = "Hà Nội";
            if (diemDenTimKiem == "") diemDenTimKiem = "TPHCM";
            if (ngayDi == "") ngayDi = DateTime.Now.ToString("dd-MM-yyyy");
            var query = from xk in db.XEKHACHes
                        join cx in db.CHUYENXEs
                        on xk.ID_XeKhach equals cx.ID_XeKhach
                        join dden in db.DIEMDENs
                        on cx.ID_DiemDen equals dden.ID_DiemDen
                        join ddi in db.DIEMXUATPHATs
                        on cx.ID_DiemXP equals ddi.ID_DiemXP
                        where dden.TenDiemDen == diemDenTimKiem &&
                        ddi.TenDiemXP == diemDiTimKiem
                        select new TimXeView
                        {
                            ID_XeKhach = xk.ID_XeKhach,
                            HinhAnhXe = xk.HinhAnhXe,
                            SoGhe = xk.SoGhe,
                            MoTa = xk.MoTa,
                            ID_HangXe = xk.ID_HangXe,
                            TenDiemDi = ddi.TenDiemXP,
                            TenDiemDen = dden.TenDiemDen,
                            NgayDi = cx.ThoiGianXP,
                            NgayDen = cx.ThoiGianDen,
                            ID_ChuyenXe = cx.ID_ChuyenXe
                        };
            
            var xekhach = query.ToList<TimXeView>();
            return View(xekhach);
        }
    }
}