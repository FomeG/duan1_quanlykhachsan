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
    
    public partial class checkin_phong
    {
        public int id { get; set; }
        public int idcheckin { get; set; }
        public int idphong { get; set; }
    
        public virtual checkin checkin { get; set; }
        public virtual phong phong { get; set; }
    }
}
