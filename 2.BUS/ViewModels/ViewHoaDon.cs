using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.ViewModels
{
    public class ViewHoaDon
    {
        public Guid Id { get; set; }
        public Guid IdKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public Guid IdNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string MaHoaDon { get; set; }
        public DateTime NgayTao { get; set; }
        public string TrangThai { get; set; }
        public string GhiChu { get; set; }
        public decimal TongTien { get; set; }
    }
}
