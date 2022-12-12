using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Models
{
    public class KhuyenMais
    {
        public Guid Id { get; set; }
        public string TenKhuyenMai { get; set; }
        public int PhanTram { get; set; }
        public string ChiTiet { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
    }
}
