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
    public class QLChucVuServices:IQLChucVuServices
    {
        IChucVuRepositories _rps;
        List<ChucVu> _lst;
        public QLChucVuServices()
        {
            _rps = new ChucVuRepositories();
            _lst = new List<ChucVu>();
        }

        public string Add(ChucVu obj)
        {
           _rps.Add(obj);
            return "Thêm thành công";
        }

        public string Delete(ChucVu obj)
        {
           _rps.Delete(obj);
            return "Xoá thành công";
        }

        public List<ChucVu> GetListChucVu()
        {
            _lst = _rps.GetListChucVu();
            return _lst;
        }

        public string Update(ChucVu obj)
        {
            _rps.Update(obj);
            return "Sửa thành công";
        }
    }
}
