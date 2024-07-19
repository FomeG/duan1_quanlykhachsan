﻿using DAL_Quanly.Repository.NhanVien;
using DTO_Quanly;
using DTO_Quanly.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace BUS_Quanly
{
    public class Snhanvien
    {
        TruyVanNV _truyvan = new TruyVanNV();
        public Snhanvien()
        {

        }

        public Snhanvien(TruyVanNV truyVanNV)
        {
            this._truyvan = truyVanNV;
        }

        public List<nhanvien> hienthi()
        {
            return _truyvan.getlist();
        }



        public bool addnv(string ten, string email, string sdt, string gioitinh, string diachi, DateTime ngaysinh, string tk, string matkhau)
        {
            if (DTODB.db.taikhoans.FirstOrDefault(p => p.taikhoan1 == tk) == null)
            {
                if (DTODB.db.nhanviens.FirstOrDefault(p => p.email == email) == null)
                {

                    taikhoan tknv = new taikhoan()
                    {
                        taikhoan1 = tk,
                        matkhau = matkhau,
                        loaitk = 2
                    };

                    nhanvien nvmoi = new nhanvien()
                    {
                        ten = ten,
                        email = email,
                        sdt = sdt,
                        gioitinh = gioitinh,
                        diachi = diachi,
                        ngaysinh = ngaysinh,
                        taikhoan = tk
                    };
                    return _truyvan.them(nvmoi, tknv);
                }
                else
                {
                    MessageBox.Show("Email đã bị trùng, vui lòng nhập lại!");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Tài khoản nhân viên đã bị trùng!");
                return false;
            }

        }
        



    }
}
