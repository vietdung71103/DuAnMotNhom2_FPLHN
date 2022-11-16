using _1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public interface IHoaDonChiTietRepositories
    {
        bool Add(HoaDonChiTiet obj);
        bool Delete (HoaDonChiTiet obj);
        bool Update(HoaDonChiTiet obj);
        List<HoaDonChiTiet> GetListHoaDonChiTiet();
        List<HoaDon> GetListHoaDon();
    }
}
