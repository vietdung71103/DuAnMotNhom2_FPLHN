using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Models
{
    public class NhanVien
    {
        public Guid Id { get; set; }
        public Guid IdChucVu { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string Anh { get; set; }
        public Guid IdGuiBC { get; set; }
        public string Sdt { get; set; }
       
        public DateTime NgaySinh { get; set; }
        public string TrangThai { get; set; }
        public virtual ChucVu? ChucVu { get; set; }
    }
}
