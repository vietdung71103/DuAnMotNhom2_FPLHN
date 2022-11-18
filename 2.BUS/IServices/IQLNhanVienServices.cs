using _1.DAL.Models;
using _2.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IServices
{
    public interface IQLNhanVienServices
    {
        string Add(NhanVien obj);
        string Delete(NhanVien obj);
        string Update(NhanVien obj);
        List<NhanVienView> GetAll();
        List<NhanVien> GetListNV();
    }
}
