using DAL_Quanly.Repository.Login;
using DTO_Quanly;
using System.Windows.Forms;

namespace BUS_Quanly.Services.LoginLogout
{
    //Lớp xử lý nghiệp vụ đăng nhập
    public static class DangNhap
    {
        // Kiểm tra kết quả đăng nhập dựa vào tài khoản và mật khẩu
        public static bool KetQua(string tk, string mk)
        {
            if (DTODB.db.taikhoans.Find(tk) != null)
            {
                if (DTODB.db.taikhoans.Find(tk).matkhau != mk)
                {
                    MessageBox.Show("Sai mật khẩu");
                    return false;
                }
                else
                {
                    return Dangnhap.login(tk, mk);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy tài khoản");
                return false;
            }
        }

        // Kiểm tra vai trò => đưa ra đúng form 
        public static int? VaiTro(string tk)
        {
            return DTODB.db.taikhoans.Find(tk).loaitk;
        }

    }
}
