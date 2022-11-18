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
    public class QLTacGiaServices:IQLTacGiaServices
    {
        ITacGiaRepositories _rps;
        List<TacGia> _lst;
        public QLTacGiaServices()
        {
            _rps = new TacGiaRepositories();
            _lst = new List<TacGia>();
        }

        public string Add(TacGia obj)
        {
            _rps.Add(obj);
            return "Thêm thành công";
        }

        public string Delete(TacGia obj)
        {
            _rps.Delete(obj);
            return "Xoá thành công";
        }

        public List<TacGia> GetListTacGia()
        {
            _lst = _rps.GetListTacGia();
            return _lst;
        }

        public string Update(TacGia obj)
        {
            _rps.Update(obj);
            return "Sửa thành công";
        }
    }
}
