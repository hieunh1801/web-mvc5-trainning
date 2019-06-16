using Nhom21_WebsiteDatVeXeKhach.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nhom21_WebsiteDatVeXeKhach.Models.Functions
{
    public class HamTaiKhoan
    {
        private ModelQLBVXK db;

        public HamTaiKhoan()
        {
            db = new ModelQLBVXK();
        }

        public IQueryable<TAIKHOAN> TaiKhoans
        {
            get { return db.TAIKHOANs; }
        }

        public string Insert(TAIKHOAN model)
        {
            db.TAIKHOANs.Add(model);
            db.SaveChanges();
            return model.TenTaiKhoan;
        }

        public string Update(TAIKHOAN model)
        {
            TAIKHOAN dbEntry = db.TAIKHOANs.Find(model.ID_TaiKhoan);
            if (dbEntry == null)
            {
                return null;
            }
            dbEntry.ID_TaiKhoan = model.ID_TaiKhoan;
            dbEntry.TenTaiKhoan = model.TenTaiKhoan;
            dbEntry.MatKhau = model.MatKhau;
            dbEntry.HoTen = model.HoTen;
            dbEntry.NgaySinh = DateTime.Now;
            dbEntry.DiaChi = "236 HQV";
            dbEntry.SoDT = model.SoDT.Trim();
            dbEntry.Email = model.Email;
            dbEntry.ID_Quyen = model.ID_Quyen;
            db.SaveChanges();
            return model.TenTaiKhoan;
        }

        public string Delete(int idTaiKhoan)
        {
            TAIKHOAN dbEntry = db.TAIKHOANs.Find(idTaiKhoan);
            if (dbEntry == null)
            {
                return null;
            }
            db.TAIKHOANs.Remove(dbEntry);
            db.SaveChanges();
            return idTaiKhoan.ToString();
        }
    }
}