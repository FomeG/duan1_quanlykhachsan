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
    
    public partial class phong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public phong()
        {
            this.checkin_phong = new HashSet<checkin_phong>();
            this.trangthaiphongs = new HashSet<trangthaiphong>();
        }
    
        public int idphong { get; set; }
        public Nullable<int> loaiphong { get; set; }
        public string khuvuc { get; set; }
        public string tenphong { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<checkin_phong> checkin_phong { get; set; }
        public virtual loaiphong loaiphong1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<trangthaiphong> trangthaiphongs { get; set; }
    }
}
