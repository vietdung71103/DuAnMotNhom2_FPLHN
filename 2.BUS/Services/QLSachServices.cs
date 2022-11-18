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
    public class QLSachServices : IQLSachServices
    {
        ISachRepositories _rps;
        List<Sach> _lst;
        public QLSachServices()
        {
           _rps = new SachRepositories();
            _lst = new List<Sach>();

        }
        public string Add(Sach obj)
        {
            _rps.Add(obj);
            return "Thêm thành công";
        }

        public string Delete(Sach obj)
        {
            _rps.Delete(obj);
            return "Sửa thành công";
        }

        public List<Sach> GetListSach()
        {
           return _lst = _rps.GetListSach();
        }

        public string Update(Sach obj)
        {
            _rps.Update(obj);
            return "Xoá thành công";
        }
    }
}
