using _1.DAL.IRepositories;
using _1.DAL.Models;
using _2.BUS.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.Services
{
    public class QLTheLoaiServices:IQLTheLoaiServices
    {
        ITheLoaiRepositories _rps;
        List<TheLoai> _lst;
        public QLTheLoaiServices()
        {
            _lst = new List<TheLoai>();
            _rps = new TheLoaiRepositories();
        }

        public string Add(TheLoai obj)
        {
            _rps.Add(obj);
            return "Thêm thành công";
        }

        public string Delete(TheLoai obj)
        {
            _rps.Delete(obj);
            return "Xoá thành công";
        }

        public List<TheLoai> GetListTheLoai()
        {
           return _lst = _rps.GetListTheLoai();
        }

        public string Update(TheLoai obj)
        {
            _rps.Update(obj);
            return "Sửa thành công";
        }
    }
}
