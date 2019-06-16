using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nhom21_WebsiteDatVeXeKhach.Models.ViewModels
{
    public class DatVeView
    {
        public string TenHangXe { get; set; }
        public string ID_XeKhach { get; set; }
        public string HinhAnhXe { get; set; }
        public int? SoGheTrong { get; set; }
        public double? GiaVe { get; set; }
        public string TenDiemDi { get; set; }
        public string TenDiemDen { get; set; }
        public DateTime? NgayDi { get; set; }
        public DateTime? NgayDen { get; set; }

        public int? ID_ChuyenXe { get; set; }
    }
}