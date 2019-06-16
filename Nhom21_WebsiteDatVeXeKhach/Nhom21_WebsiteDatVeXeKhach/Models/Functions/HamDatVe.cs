using Nhom21_WebsiteDatVeXeKhach.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nhom21_WebsiteDatVeXeKhach.Models.Functions
{
    public class HamDatVe
    {
        private ModelQLBVXK db;

        public HamDatVe()
        {
            db = new ModelQLBVXK();
        }

        public IQueryable<THONGTINDATVE> DatPhongs
        {
            get { return db.THONGTINDATVEs; }
        }

        public int Insert(THONGTINDATVE model)
        {
            db.THONGTINDATVEs.Add(model);
            db.SaveChanges();
            return model.ID_ThongTinDatVe;
        }

        public int Update(THONGTINDATVE model)
        {
            THONGTINDATVE dbEntry = db.THONGTINDATVEs.Find(model.ID_ThongTinDatVe);
            if (dbEntry == null)
            {
                return -1;
            }
            dbEntry.ID_ThongTinDatVe = model.ID_ThongTinDatVe;
            dbEntry.ThoiGianDatVe = model.ThoiGianDatVe;
            dbEntry.SoLuongVe = model.SoLuongVe;
            dbEntry.LyDoHuyVe = model.LyDoHuyVe;
            dbEntry.TrangThaiDatVe = model.TrangThaiDatVe;
            dbEntry.ID_ChuyenXe = model.ID_ChuyenXe;
            dbEntry.ID_TaiKhoan = model.ID_TaiKhoan;
            dbEntry.ID_PTTT = model.ID_PTTT;
            db.SaveChanges();
            return model.ID_ThongTinDatVe;
        }

        public int Delete(int MaDat)
        {
            THONGTINDATVE dbEntry = db.THONGTINDATVEs.Find(MaDat);
            if (dbEntry == null)
            {
                return -1;
            }
            db.THONGTINDATVEs.Remove(dbEntry);
            db.SaveChanges();
            return MaDat;
        }
    }
}