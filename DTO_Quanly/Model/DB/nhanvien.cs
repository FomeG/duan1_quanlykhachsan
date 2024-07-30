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
    
    public partial class nhanvien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public nhanvien()
        {
            this.checkins = new HashSet<checkin>();
            this.checkouts = new HashSet<checkout>();
            this.dsdattruocs = new HashSet<dsdattruoc>();
            this.hoadons = new HashSet<hoadon>();
            this.vouchers = new HashSet<voucher>();
        }
    
        public int idnv { get; set; }
        public string ten { get; set; }
        public string email { get; set; }
        public string sdt { get; set; }
        public string gioitinh { get; set; }
        public string diachi { get; set; }
        public Nullable<System.DateTime> ngaysinh { get; set; }
        public string taikhoan { get; set; }
        public Nullable<bool> idtrangthai { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<checkin> checkins { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<checkout> checkouts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dsdattruoc> dsdattruocs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hoadon> hoadons { get; set; }
        public virtual taikhoan taikhoan1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<voucher> vouchers { get; set; }
    }
}
