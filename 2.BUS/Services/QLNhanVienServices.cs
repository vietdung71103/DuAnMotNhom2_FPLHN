using _1.DAL.IRepositories;
using _1.DAL.Models;
using _2.BUS.IServices;
using _2.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.Services
{
    public class QLNhanVienServices:IQLNhanVienServices
    {
        INhanVienRepositories _rps;
        IChucVuRepositories _rps2;
        List<NhanVien> _lst;
        List<NhanVienView> _lstnv;
        public QLNhanVienServices()
        {
            //_lst = new List<NhanVien>();
            _rps = new NhanVienRepositories();
            _rps2 = new ChucVuRepositories();
        }

        public string Add(NhanVien obj)
        {
            _lst.Add(obj);
            _rps.Add(obj);
            return "Thêm thành công";
        }

        public string Delete(NhanVien obj)
        {
            _rps.Delete(obj);
            return "Xoá thành công";
        }

        public List<NhanVienView> GetAll()
        {
            _lstnv = (from a in _rps.GetListNhanVien()
                      join b in _rps2.GetListChucVu() on a.IdChucVu equals b.Id
                      select new NhanVienView() {

                          ChucVus = b,
                          NhanViens = a
                      }).ToList();
            return _lstnv;
        }

        public List<NhanVien> GetListNV()
        {
            throw new NotImplementedException();
        }

        public string Update(NhanVien obj)
        {
            _rps.Update(obj);
            return "Sửa thành công";
        }
    }
}
