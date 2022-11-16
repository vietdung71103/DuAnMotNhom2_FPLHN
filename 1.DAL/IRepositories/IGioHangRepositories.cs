using _1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public interface IGioHangRepositories
    {
        bool Add(GioHang obj);
        bool Update(GioHang obj);
        bool Delete(GioHang obj);
        List<GioHangChiTiet> GetListGioHangChiTiet();
        List<GioHang> GetListGioHang();
    }
}
