using _1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.ViewModels
{
    public class SanPhamView
    {
        public SachChiTiet SachChiTiets { get; set; }
        public Sach Sachs { get; set; }
        public NXB NXBs { get; set; }
        public TheLoai TheLoais { get; set; }
        public TacGia TacGias { get; set; }
        public Anh Anhs { get; set; }
    }
}
