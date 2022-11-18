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
        public Sach Sach { get; set; }
        public NXB NXB { get; set; }
        public TheLoai TheLoai { get; set; }
        public TacGia TacGia { get; set; }
        public Anh Anh { get; set; }
    }
}
