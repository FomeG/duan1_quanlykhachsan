//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DTO_Quanly.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class voucher
    {
        public string MaVoucher { get; set; }
        public Nullable<int> idnv { get; set; }
        public Nullable<int> soluong { get; set; }
        public System.DateTime ngaylap { get; set; }
        public System.DateTime ngayhethan { get; set; }
        public string trangthai { get; set; }
    
        public virtual nhanvien nhanvien { get; set; }
    }
}
