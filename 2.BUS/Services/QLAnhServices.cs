using _1.DAL.IRepositories;
using _1.DAL.Models;
using _1.DAL.Repositories;
using _2.BUS.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.Services
{
    public class QLAnhServices:IQLAnhServices
    {
        List<Anh> _lst;
        IAnhRepositories _rps;
        public QLAnhServices()
        {
            _rps = new AnhRepositories();
            _lst = new List<Anh>(); 
        }

        public string Add(Anh obj)
        {
            _rps.Add(obj);
            return "Thêm thành công";
        }

        public string Delete(Anh obj)
        {
            _rps.Delete(obj);
            return "Xoá thành công";
        }

        public List<Anh> GetListAnh()
        {
            _lst = _rps.GetListAnh();
            return _lst;
        }

        public string Update(Anh obj)
        {
            _rps.Update(obj);
            return "Sửa thành công";
        }
    }
}
