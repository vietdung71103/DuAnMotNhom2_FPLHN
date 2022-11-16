using _1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public interface IGioHangChiTietRepositories
    {
        bool Add(GioHangChiTiet obj);
        bool Update(GioHangChiTiet obj);
        bool Delete(GioHangChiTiet obj);
        List<GioHangChiTiet> GetListGioHangChiTiet();
        List<GioHang> GetListGioHang();
    }
}
