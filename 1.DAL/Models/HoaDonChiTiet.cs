using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Models
{
        public class HoaDonChiTiet
    {
        public Guid Id { get; set; }
        public Guid IdHoaDon { get; set; }
        public Guid IdSachChiTiet { get; set; }
        public int SoLuong { get; set; }
        public decimal GiaBan { get; set; }
        public virtual HoaDon? HoaDon { get; set; }
        public virtual SachChiTiet? SachChiTiet { get; set; }
    }
}
