namespace Nhom21_WebsiteDatVeXeKhach.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XEKHACH")]
    public partial class XEKHACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public XEKHACH()
        {
            CHUYENXEs = new HashSet<CHUYENXE>();
        }

        [Key]
        [StringLength(20)]
        public string ID_XeKhach { get; set; }

        [StringLength(100)]
        public string HinhAnhXe { get; set; }

        public int? SoGhe { get; set; }

        [StringLength(200)]
        public string MoTa { get; set; }

        public int? ID_HangXe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHUYENXE> CHUYENXEs { get; set; }

        public virtual HANGXE HANGXE { get; set; }
    }
}
