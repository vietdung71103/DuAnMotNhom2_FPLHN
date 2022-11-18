using _1.DAL.IRepositories;
using _1.DAL.Models;
using _2.BUS.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.Services
{
    public class QLKhachHangServices:IQLKhachHangServices
    {
        IKhachHangRepositories _rps;
        List<KhachHang> _lst;
        public QLKhachHangServices()
        {
            _lst = new List<KhachHang>();
            _rps = new KhachHangRepositories();
        }

        public string Add(KhachHang obj)
        {
           _rps.Add(obj);
            return "Thêm thành công";
        }

        public string Delete(KhachHang obj)
        {
            _rps.Delete(obj);
            return "Xoá thành công";
        }

        public List<KhachHang> GetListKhachHang()
        {
           _lst = _rps.GetListKhachHang();
            return _lst;
        }

        public string Update(KhachHang obj)
        {
            _rps.Update(obj);
            return "Sửa thành công";
        }
    }
}
