//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DTO_Quanly.Model.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class hoadon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public hoadon()
        {
            this.dv_trunggian = new HashSet<dv_trunggian>();
            this.phong_trunggian = new HashSet<phong_trunggian>();
        }
    
        public int idhoadon { get; set; }
        public int idkh { get; set; }
        public int idnv { get; set; }
        public System.DateTime ngaytao { get; set; }
        public decimal tongtien { get; set; }
        public Nullable<int> songuoi { get; set; }
        public string trangthai { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dv_trunggian> dv_trunggian { get; set; }
        public virtual khachhang khachhang { get; set; }
        public virtual nhanvien nhanvien { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<phong_trunggian> phong_trunggian { get; set; }
    }
}
