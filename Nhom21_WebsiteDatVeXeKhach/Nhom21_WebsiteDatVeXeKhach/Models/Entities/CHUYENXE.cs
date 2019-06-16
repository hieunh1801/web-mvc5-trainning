namespace Nhom21_WebsiteDatVeXeKhach.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHUYENXE")]
    public partial class CHUYENXE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CHUYENXE()
        {
            THONGTINDATVEs = new HashSet<THONGTINDATVE>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_ChuyenXe { get; set; }

        public int? ID_DiemDen { get; set; }

        public int? ID_DiemXP { get; set; }

        public DateTime? ThoiGianXP { get; set; }

        public DateTime? ThoiGianDen { get; set; }

        public int? SoGheTrong { get; set; }

        public double? GiaVe { get; set; }

        [StringLength(20)]
        public string ID_XeKhach { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THONGTINDATVE> THONGTINDATVEs { get; set; }

        public virtual XEKHACH XEKHACH { get; set; }
    }
}
