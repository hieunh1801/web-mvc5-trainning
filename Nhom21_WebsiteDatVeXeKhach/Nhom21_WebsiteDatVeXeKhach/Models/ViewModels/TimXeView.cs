using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nhom21_WebsiteDatVeXeKhach.Models.ViewModels
{
    public class TimXeView
    {
        public string ID_XeKhach { get; set; }
        public string HinhAnhXe { get; set; }
        public int? SoGhe { get; set; }
        public string MoTa { get; set; }
        public int? ID_HangXe { get; set; }
        public string TenDiemDi { get; set; }
        public string TenDiemDen { get; set; }
        public DateTime? NgayDi { get; set; }
        public DateTime? NgayDen { get; set; }

        public int? ID_ChuyenXe { get; set; }
    };
}
