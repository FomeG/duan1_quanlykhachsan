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
    
    public partial class hoadonchitiet
    {
        public int id { get; set; }
        public int idhoadon { get; set; }
        public decimal thanhtien { get; set; }
    
        public virtual hoadon hoadon { get; set; }
    }
}