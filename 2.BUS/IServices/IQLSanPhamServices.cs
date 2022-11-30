using _1.DAL.Models;
using _2.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IServices
{
    public interface IQLSanPhamServices
    {
        string Add(SachChiTiet obj);
        string Update(SachChiTiet obj);
        string Delete(SachChiTiet obj);
        List<SanPhamView> GetAll();
        List<SachChiTiet> GetListSachChiTiet();
    }
}
