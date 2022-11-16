using _1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public interface IKhachHangRepositories
    {
        bool Add(KhachHang obj);
        bool Delete(KhachHang obj);
        bool Update(KhachHang obj);
        List<KhachHang> GetListKhachHang();
    }
}
