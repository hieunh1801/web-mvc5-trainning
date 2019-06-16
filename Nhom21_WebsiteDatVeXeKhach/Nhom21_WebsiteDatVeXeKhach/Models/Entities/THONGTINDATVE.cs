namespace Nhom21_WebsiteDatVeXeKhach.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THONGTINDATVE")]
    public partial class THONGTINDATVE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_ThongTinDatVe { get; set; }

        public DateTime? ThoiGianDatVe { get; set; }

        public int? SoLuongVe { get; set; }

        [StringLength(100)]
        public string LyDoHuyVe { get; set; }

        [StringLength(100)]
        public string TrangThaiDatVe { get; set; }

        public int? ID_ChuyenXe { get; set; }

        public int? ID_TaiKhoan { get; set; }

        public int? ID_PTTT { get; set; }

        public virtual CHUYENXE CHUYENXE { get; set; }

        public virtual PHUONGTHUCTHANHTOAN PHUONGTHUCTHANHTOAN { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }
    }
}
