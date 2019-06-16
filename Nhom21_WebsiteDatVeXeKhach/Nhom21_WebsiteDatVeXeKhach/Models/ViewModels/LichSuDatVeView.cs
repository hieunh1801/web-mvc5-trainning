using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nhom21_WebsiteDatVeXeKhach.Models.ViewModels
{
    public class LichSuDatVeView
    {
        public int MaDatVe { get; set; }
        public string MaXeKhach { get; set; }
        public string ThoiGianDatVe { get; set; }
        public int? SoLuongVe { get; set; }
        public DateTime ThoiGianXP { get; set; }
        public DateTime ThoiGianDen { get; set; }
        public double? GiaVe { get; set; }
        public double? ThanhTien { get; set; }
        public string TrangThaiDatVe { get; set; }
    }
}