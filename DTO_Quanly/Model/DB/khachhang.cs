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
    
    public partial class khachhang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public khachhang()
        {
            this.checkins = new HashSet<checkin>();
            this.checkouts = new HashSet<checkout>();
            this.dsdattruocs = new HashSet<dsdattruoc>();
            this.hoadons = new HashSet<hoadon>();
            this.tempkhachhangs = new HashSet<tempkhachhang>();
        }
    
        public int id { get; set; }
        public string ten { get; set; }
        public string email { get; set; }
        public string sdt { get; set; }
        public string gioitinh { get; set; }
        public string diachi { get; set; }
        public string anh { get; set; }
        public Nullable<System.DateTime> ngaysinh { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<checkin> checkins { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<checkout> checkouts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dsdattruoc> dsdattruocs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hoadon> hoadons { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tempkhachhang> tempkhachhangs { get; set; }
    }
}
