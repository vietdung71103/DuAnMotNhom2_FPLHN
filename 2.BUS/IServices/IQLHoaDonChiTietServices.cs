using _1.DAL.Models;
using _2.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IServices
{
    public interface IQLHoaDonChiTietServices
    {
        string AddHDCT(HoaDonChiTiet obj);
        string UpdateHDCT(HoaDonChiTiet obj);
        string DeleteHDCT(HoaDonChiTiet obj);
        List<ViewHoaDonChiTiet> GetListViewHoaDonCT(Guid idHD);
        List<HoaDonChiTiet> GetListHoaDonCT();
    }
}
