using _1.DAL.Models;
using _2.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IServices
{
    public interface IQLHoaDonServices
    {
        string Add(HoaDon obj);
        string Update(HoaDon obj);
        string Delete(HoaDon obj);
        List<ViewHoaDon> GetListViewHoaDon();
        List<HoaDon> GetListHoaDon();
    }
}
