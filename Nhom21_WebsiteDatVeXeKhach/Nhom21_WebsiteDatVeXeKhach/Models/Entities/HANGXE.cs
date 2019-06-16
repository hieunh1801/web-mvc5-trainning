namespace Nhom21_WebsiteDatVeXeKhach.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HANGXE")]
    public partial class HANGXE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HANGXE()
        {
            XEKHACHes = new HashSet<XEKHACH>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_HangXe { get; set; }

        [StringLength(100)]
        public string TenHangXe { get; set; }

        [StringLength(100)]
        public string LogoHangXe { get; set; }

        [StringLength(1000)]
        public string ThongTinHangXe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XEKHACH> XEKHACHes { get; set; }
    }
}
