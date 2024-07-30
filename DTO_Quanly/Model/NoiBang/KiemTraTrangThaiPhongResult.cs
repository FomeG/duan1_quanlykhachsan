using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Quanly.Model.NoiBang
{
    public class KiemTraTrangThaiPhongResult
    {
        public int idphong { get; set; }
        public string tenphong { get; set; }
        public string loaiphong { get; set; }
        public string mota { get; set; }
        public decimal giaphong { get; set; }
        public string tenkhuvuc { get; set; }
        public int trangthai { get; set; }
        public string trangthai_text { get; set; }
    }
}
