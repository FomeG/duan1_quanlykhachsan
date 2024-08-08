﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Duan1_Final : DbContext
    {
        public Duan1_Final()
            : base("name=Duan1_Final")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<checkin> checkins { get; set; }
        public virtual DbSet<checkin_dichvu> checkin_dichvu { get; set; }
        public virtual DbSet<checkin_phong> checkin_phong { get; set; }
        public virtual DbSet<checkout> checkouts { get; set; }
        public virtual DbSet<dichvu> dichvus { get; set; }
        public virtual DbSet<dsdattruoc> dsdattruocs { get; set; }
        public virtual DbSet<dv_trunggian> dv_trunggian { get; set; }
        public virtual DbSet<hoadon> hoadons { get; set; }
        public virtual DbSet<khachhang> khachhangs { get; set; }
        public virtual DbSet<khuvuc> khuvucs { get; set; }
        public virtual DbSet<loaiphong> loaiphongs { get; set; }
        public virtual DbSet<nhanvien> nhanviens { get; set; }
        public virtual DbSet<phong> phongs { get; set; }
        public virtual DbSet<phong_trunggian> phong_trunggian { get; set; }
        public virtual DbSet<taikhoan> taikhoans { get; set; }
        public virtual DbSet<tempkhachhang> tempkhachhangs { get; set; }
        public virtual DbSet<vaitro> vaitroes { get; set; }
        public virtual DbSet<voucher> vouchers { get; set; }
        public virtual DbSet<hoadon_dichvu> hoadon_dichvu { get; set; }
        public virtual DbSet<hoadon_phong> hoadon_phong { get; set; }
        public virtual DbSet<view_dsdattruoc_chitiet> view_dsdattruoc_chitiet { get; set; }
        public virtual DbSet<view_trangthai_phong_hientai> view_trangthai_phong_hientai { get; set; }
        public virtual DbSet<viewhoadon> viewhoadons { get; set; }
    
        public virtual int insert_dsdattruoc(Nullable<int> idnv, Nullable<int> idkh, Nullable<int> idphong, Nullable<System.DateTime> ngayden, Nullable<System.DateTime> ngaydi, string ghichu)
        {
            var idnvParameter = idnv.HasValue ?
                new ObjectParameter("idnv", idnv) :
                new ObjectParameter("idnv", typeof(int));
    
            var idkhParameter = idkh.HasValue ?
                new ObjectParameter("idkh", idkh) :
                new ObjectParameter("idkh", typeof(int));
    
            var idphongParameter = idphong.HasValue ?
                new ObjectParameter("idphong", idphong) :
                new ObjectParameter("idphong", typeof(int));
    
            var ngaydenParameter = ngayden.HasValue ?
                new ObjectParameter("ngayden", ngayden) :
                new ObjectParameter("ngayden", typeof(System.DateTime));
    
            var ngaydiParameter = ngaydi.HasValue ?
                new ObjectParameter("ngaydi", ngaydi) :
                new ObjectParameter("ngaydi", typeof(System.DateTime));
    
            var ghichuParameter = ghichu != null ?
                new ObjectParameter("ghichu", ghichu) :
                new ObjectParameter("ghichu", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insert_dsdattruoc", idnvParameter, idkhParameter, idphongParameter, ngaydenParameter, ngaydiParameter, ghichuParameter);
        }
    
        public virtual ObjectResult<kiemtra_dsdattruoc_chitiet_Result> kiemtra_dsdattruoc_chitiet(string ngayden, string ngaydi, Nullable<int> idphong)
        {
            var ngaydenParameter = ngayden != null ?
                new ObjectParameter("ngayden", ngayden) :
                new ObjectParameter("ngayden", typeof(string));
    
            var ngaydiParameter = ngaydi != null ?
                new ObjectParameter("ngaydi", ngaydi) :
                new ObjectParameter("ngaydi", typeof(string));
    
            var idphongParameter = idphong.HasValue ?
                new ObjectParameter("idphong", idphong) :
                new ObjectParameter("idphong", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<kiemtra_dsdattruoc_chitiet_Result>("kiemtra_dsdattruoc_chitiet", ngaydenParameter, ngaydiParameter, idphongParameter);
        }
    
        public virtual ObjectResult<kiemtra_trangthai_phong_Result> kiemtra_trangthai_phong(string ngayden, string ngaydi)
        {
            var ngaydenParameter = ngayden != null ?
                new ObjectParameter("ngayden", ngayden) :
                new ObjectParameter("ngayden", typeof(string));
    
            var ngaydiParameter = ngaydi != null ?
                new ObjectParameter("ngaydi", ngaydi) :
                new ObjectParameter("ngaydi", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<kiemtra_trangthai_phong_Result>("kiemtra_trangthai_phong", ngaydenParameter, ngaydiParameter);
        }
    }
}
