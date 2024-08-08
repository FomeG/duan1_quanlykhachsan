using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Quanly.Model.NoiBang
{
    public class NoiKH
    {
        public int id {  get; set; }
        public string ten { get; set; }
        public string email { get; set; }
        public string sdt { get; set; }
        public string gioitinh { get; set; }
        public string diachi { get; set; }
        public string anh { get; set; }
        public DateTime ngaysinh { get; set; }
    }
}
