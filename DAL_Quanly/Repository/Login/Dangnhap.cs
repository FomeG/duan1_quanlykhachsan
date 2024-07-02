namespace DAL_Quanly.Repository.Login
{
    // Lớp đăng nhập tĩnh, thật ra chẳng động vào đâu nhưng cứ thêm vào cho đúng quy trình =))
    public static class Dangnhap
    {
        public static bool login(string tk, string mk)
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
