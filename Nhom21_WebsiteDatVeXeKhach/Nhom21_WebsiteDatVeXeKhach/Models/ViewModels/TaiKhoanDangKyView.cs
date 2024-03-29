﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nhom21_WebsiteDatVeXeKhach.Models.ViewModels
{
    public class TaiKhoanDangKyView
    {
        public int ID_TaiKhoan { get; set; }
        [Required(ErrorMessage = "Không được để trống Tài Khoản")]
        public string TenTaiKhoan { get; set; }

        [Required(ErrorMessage = "Không được để trống Mật Khẩu")]
        public string MatKhau { get; set; }

        [Compare("MatKhau", ErrorMessage = "Mật Khẩu Không Khớp")]
        public string XacNhanMatKhau { get; set; }

        [Required(ErrorMessage = "Không được để trống Họ Tên")]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Không được để trống Số Điện Thoại")]
        public string SoDienThoai { get; set; }

        [Required(ErrorMessage = "Không được để trống Email")]
        public string Email { get; set; }
    }
}