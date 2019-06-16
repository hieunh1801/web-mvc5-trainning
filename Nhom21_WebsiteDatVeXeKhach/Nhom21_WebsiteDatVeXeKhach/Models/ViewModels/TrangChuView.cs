using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nhom21_WebsiteDatVeXeKhach.Models.Entities;

namespace Nhom21_WebsiteDatVeXeKhach.Models.ViewModels
{
    public class TrangChuView
    {
        public List<HANGXE> hangxes { get; set; }
        public List<DIEMDEN> diemden { get; set; }
    }
}