namespace Nhom21_WebsiteDatVeXeKhach.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelQLBVXK : DbContext
    {
        public ModelQLBVXK()
            : base("name=ModelQLBVXK")
        {
        }

        public virtual DbSet<CHUYENXE> CHUYENXEs { get; set; }
        public virtual DbSet<DIEMDEN> DIEMDENs { get; set; }
        public virtual DbSet<DIEMXUATPHAT> DIEMXUATPHATs { get; set; }
        public virtual DbSet<HANGXE> HANGXEs { get; set; }
        public virtual DbSet<PHUONGTHUCTHANHTOAN> PHUONGTHUCTHANHTOANs { get; set; }
        public virtual DbSet<QUYEN> QUYENs { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }
        public virtual DbSet<THONGTINDATVE> THONGTINDATVEs { get; set; }
        public virtual DbSet<XEKHACH> XEKHACHes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CHUYENXE>()
                .Property(e => e.ID_XeKhach)
                .IsUnicode(false);

            modelBuilder.Entity<HANGXE>()
                .Property(e => e.LogoHangXe)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.TenTaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.SoDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.Email)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<XEKHACH>()
                .Property(e => e.ID_XeKhach)
                .IsUnicode(false);

            modelBuilder.Entity<XEKHACH>()
                .Property(e => e.HinhAnhXe)
                .IsUnicode(false);
        }
    }
}
