using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Models
{
    public class SachChiTiet
    {
        public Guid Id { get; set; }
        public Guid IdSach { get; set; }
        public Guid IdTacGia { get; set; }
        public Guid IdTheLoai { get; set; }
        public Guid IdNXB { get; set; }
        public string Anh { get; set; }
        public string Ma { get; set; }
        public string MoTa { get; set; }
        public decimal GiaNhap { get; set; }
        public decimal GiaBan { get; set; }
        public int SoLuongTon { get; set; }
        public int SoTrang { get; set; }

     
        public virtual Sach? Sach { get; set; }
        public virtual NXB? NXB { get; set; }
        public virtual TheLoai? TheLoai { get; set; }
        public virtual TacGia? TacGia { get; set; }
    }
}
