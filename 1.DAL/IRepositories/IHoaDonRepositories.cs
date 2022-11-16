using _1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public interface IHoaDonRepositories
    {
        bool Add(HoaDon obj);
        bool Delete(HoaDon obj);
        bool Update(HoaDon obj);
        List<HoaDonChiTiet> GetListHoaDonChiTiet();
        List<HoaDon> GetListHoaDon();
    }
}
