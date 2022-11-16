using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Models
{
    public class GioHangChiTiet
    {
        public Guid Id { get; set; }
        public Guid IdGioHang { get; set; }
        public Guid IdSachChiTiet { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public virtual GioHang GioHang { get; set; }
        public virtual SachChiTiet SachChiTiet { get; set; }
    }
}
