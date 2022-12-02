using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.ViewModels
{
    public class ViewHoaDonChiTiet
    {
        public Guid Id { get; set; }
        public Guid IdHoaDon { get; set; }
        public Guid IdSachChiTiet { get; set; }
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public int SoLuong { get; set; }
        public decimal GiaBan { get; set; }
    }
}
