using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.ViewModels
{
    public class ViewXuatBill
    {
        public int Id { get; set; }
        public string TenSanPham { get; set; }
        public decimal GiaBan { get; set; }
        public int SoLuong { get; set; }
        public string TongTien { get { return string.Format("{0}$", GiaBan * SoLuong); } }
    }
}
