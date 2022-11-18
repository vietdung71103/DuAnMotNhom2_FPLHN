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
    public class QLNXBServices:IQLNXBServices
    {
        INXBRepositories _rps;
        List<NXB> _lst;
        public QLNXBServices()
        {
            _lst = new List<NXB>();
            _rps = new NXBRepositories();
        }

        public string Add(NXB obj)
        {
            _rps.Add(obj);
            return "Thêm thành công";
        }

        public string Delete(NXB obj)
        {
            _rps.Delete(obj);
            return "Xoá thành công";
        }

        public List<NXB> GetListNXB()
        {
          _lst = _rps.GetListNXB();
            return _lst;
        }

        public string Update(NXB obj)
        {
            _rps.Update(obj);
            return "Sửa thành công";
        }
    }
}
