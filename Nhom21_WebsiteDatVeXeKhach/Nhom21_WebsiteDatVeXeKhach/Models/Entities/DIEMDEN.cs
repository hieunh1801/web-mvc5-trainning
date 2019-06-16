namespace Nhom21_WebsiteDatVeXeKhach.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DIEMDEN")]
    public partial class DIEMDEN
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_DiemDen { get; set; }

        [StringLength(100)]
        public string TenDiemDen { get; set; }
    }
}
