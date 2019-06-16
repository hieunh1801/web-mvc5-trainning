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
    public class AdminController : Controller
    {
        private ModelQLBVXK db = new ModelQLBVXK();
        private int MaxPhanTuMoiTrang = 5;

        // GET
        public ActionResult DangXuat()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "TrangChu");
        }
        public ActionResult listTaiKhoan()
        {
            var list = db.TAIKHOANs.ToList();
            int TongPhanTu = list.Count;
            int SoTrang = (TongPhanTu - 1) / MaxPhanTuMoiTrang + 1;
            int Trang = 1;
            try
            {
                string id = RouteData.Values["id"].ToString();
                Trang = Convert.ToInt16(id);
                if (Trang > SoTrang) Trang = SoTrang;
            }
            catch (Exception e)
            {
            }
            int PhanTuDau = (Trang - 1) * MaxPhanTuMoiTrang;
            int SoPhanTu = MaxPhanTuMoiTrang;
            if (Trang == SoTrang) SoPhanTu = TongPhanTu - (SoTrang - 1) * MaxPhanTuMoiTrang;
            var listMoiTrang = list.GetRange(PhanTuDau, SoPhanTu);
            ViewBag.STT = PhanTuDau;
            ViewBag.Trang = Trang;
            ViewBag.SoTrang = SoTrang;
            return View(listMoiTrang);
        }

        public ActionResult listChuyenXe()
        {
            var list = db.CHUYENXEs.ToList();
            int TongPhanTu = list.Count;
            int SoTrang = (TongPhanTu - 1) / MaxPhanTuMoiTrang + 1;
            int Trang = 1;
            try
            {
                string id = RouteData.Values["id"].ToString();
                Trang = Convert.ToInt16(id);
                if (Trang > SoTrang) Trang = SoTrang;
            }
            catch (Exception e) { }
            int PhanTuDau = (Trang - 1) * MaxPhanTuMoiTrang;
            int SoPhanTu = MaxPhanTuMoiTrang;
            if (Trang == SoTrang) SoPhanTu = TongPhanTu - (SoTrang - 1) * MaxPhanTuMoiTrang;
            var listMoiTrang = list.GetRange(PhanTuDau, SoPhanTu);
            ViewBag.STT = PhanTuDau;
            ViewBag.Trang = Trang;
            ViewBag.SoTrang = SoTrang;
            return View(listMoiTrang);
        }

        public ActionResult listHangXe()
        {
            MaxPhanTuMoiTrang = 1;
            var list = db.HANGXEs.ToList();
            int TongPhanTu = list.Count;
            int SoTrang = (TongPhanTu - 1) / MaxPhanTuMoiTrang + 1;
            int Trang = 1;
            try
            {
                string id = RouteData.Values["id"].ToString();
                Trang = Convert.ToInt16(id);
                if (Trang > SoTrang) Trang = SoTrang;
            }
            catch (Exception e) { }
            int PhanTuDau = (Trang - 1) * MaxPhanTuMoiTrang;
            int SoPhanTu = MaxPhanTuMoiTrang;
            if (Trang == SoTrang) SoPhanTu = TongPhanTu - (SoTrang - 1) * MaxPhanTuMoiTrang;
            var listMoiTrang = list.GetRange(PhanTuDau, SoPhanTu);
            ViewBag.STT = PhanTuDau;
            ViewBag.Trang = Trang;
            ViewBag.SoTrang = SoTrang;
            return View(listMoiTrang);
        }

        public ActionResult listXeKhach()
        {
            var list = db.XEKHACHes.ToList();
            int TongPhanTu = list.Count;
            int SoTrang = (TongPhanTu - 1) / MaxPhanTuMoiTrang + 1;
            int Trang = 1;
            try
            {
                string id = RouteData.Values["id"].ToString();
                Trang = Convert.ToInt16(id);
                if (Trang > SoTrang) Trang = SoTrang;
            }
            catch (Exception e) { }
            int PhanTuDau = (Trang - 1) * MaxPhanTuMoiTrang;
            int SoPhanTu = MaxPhanTuMoiTrang;
            if (Trang == SoTrang) SoPhanTu = TongPhanTu - (SoTrang - 1) * MaxPhanTuMoiTrang;
            var listMoiTrang = list.GetRange(PhanTuDau, SoPhanTu);
            ViewBag.STT = PhanTuDau;
            ViewBag.Trang = Trang;
            ViewBag.SoTrang = SoTrang;
            return View(listMoiTrang);
        }

        public ActionResult listPTTT()
        {
            var list = db.PHUONGTHUCTHANHTOANs.ToList();
            int TongPhanTu = list.Count;
            int SoTrang = (TongPhanTu - 1) / MaxPhanTuMoiTrang + 1;
            int Trang = 1;
            try
            {
                string id = RouteData.Values["id"].ToString();
                Trang = Convert.ToInt16(id);
                if (Trang > SoTrang) Trang = SoTrang;
            }
            catch (Exception e) { }
            int PhanTuDau = (Trang - 1) * MaxPhanTuMoiTrang;
            int SoPhanTu = MaxPhanTuMoiTrang;
            if (Trang == SoTrang) SoPhanTu = TongPhanTu - (SoTrang - 1) * MaxPhanTuMoiTrang;
            var listMoiTrang = list.GetRange(PhanTuDau, SoPhanTu);
            ViewBag.STT = PhanTuDau;
            ViewBag.Trang = Trang;
            ViewBag.SoTrang = SoTrang;
            return View(listMoiTrang);
        }

        public ActionResult listTTDatVe()
        {
            var list = db.THONGTINDATVEs.ToList();
            int TongPhanTu = list.Count;
            int SoTrang = (TongPhanTu - 1) / MaxPhanTuMoiTrang + 1;
            int Trang = 1;
            try
            {
                string id = RouteData.Values["id"].ToString();
                Trang = Convert.ToInt16(id);
                if (Trang > SoTrang) Trang = SoTrang;
            }
            catch (Exception e) { }
            int PhanTuDau = (Trang - 1) * MaxPhanTuMoiTrang;
            int SoPhanTu = MaxPhanTuMoiTrang;
            if (Trang == SoTrang) SoPhanTu = TongPhanTu - (SoTrang - 1) * MaxPhanTuMoiTrang;
            var listMoiTrang = list.GetRange(PhanTuDau, SoPhanTu);
            ViewBag.STT = PhanTuDau;
            ViewBag.Trang = Trang;
            ViewBag.SoTrang = SoTrang;
            return View(listMoiTrang);
        }

        // Thêm
        [Authorize]
        public ActionResult ThemTaiKhoan()
        {
            return View(new TaiKhoanDangKyView());
        }

        // Sửa
        [Authorize]
        public ActionResult SuaTaiKhoan()
        {
            int idTaiKhoan = Convert.ToInt32(RouteData.Values["id"]);
            var taiKhoan = db.TAIKHOANs.Find(idTaiKhoan);
            var TaiKhoanCaNhan = new TaiKhoanDangKyView
            {
                TenTaiKhoan = taiKhoan.TenTaiKhoan,
                MatKhau = taiKhoan.MatKhau,
                XacNhanMatKhau = taiKhoan.MatKhau,
                HoTen = taiKhoan.HoTen,
                SoDienThoai = taiKhoan.SoDT,
                Email = taiKhoan.Email
            };
            return View(TaiKhoanCaNhan);
        }

        // Xóa
        [Authorize]
        public ActionResult XoaTaiKhoan()
        {
            int idTaiKhoan = Convert.ToInt32(RouteData.Values["id"]);
            // Trước khi xóa Tài Khoản phải xóa thông tin đặt vé
            var listVe = db.THONGTINDATVEs.Where(m => m.ID_TaiKhoan == idTaiKhoan).ToList();
            var HamDV = new HamDatVe();
            foreach (THONGTINDATVE dp in listVe)
                HamDV.Delete(dp.ID_ThongTinDatVe);
            // Sau đó mới xóa Tài Khoản
            var HamTK = new HamTaiKhoan();
            HamTK.Delete(idTaiKhoan);
            return RedirectToAction("listTaiKhoan", "Admin");
        }

        // POST
        [Authorize]
        [HttpPost]
        public ActionResult ThemTaiKhoan(TaiKhoanDangKyView tk)
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
                    DiaChi = "Hà Nội",
                    SoDT = tk.SoDienThoai,
                    Email = tk.Email,
                    ID_Quyen = 2
                };
                var hTK = new HamTaiKhoan();
                hTK.Insert(taiKhoan);
                return RedirectToAction("listTaiKhoan", "Admin");
            }
            return View(tk);
        }

        [Authorize]
        [HttpPost]
        public ActionResult SuaTaiKhoan(TaiKhoanDangKyView tk)
        {
            var ls = db.TAIKHOANs.Where(i => i.TenTaiKhoan == tk.TenTaiKhoan).ToList();
            TAIKHOAN taiKhoan;
            if (!ModelState.IsValid)
            {
                taiKhoan = new TAIKHOAN()
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
                var HamTK = new HamTaiKhoan();
                HamTK.Update(taiKhoan);
                return RedirectToAction("listTaiKhoan", "Admin");
            }
            return View(tk);
        }
    }
}