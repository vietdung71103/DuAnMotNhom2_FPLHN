using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Models
{
    public  class GioHang
    {
        public Guid Id { get; set; }
        public Guid IdKhachHang { get; set; }
        public string MaGioHang { get; set; }
        public string TrangThai { get; set; }
        public virtual KhachHang? KhachHang { get; set; }
    }
}
