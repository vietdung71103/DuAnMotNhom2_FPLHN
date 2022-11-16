using _1.DAL.Context;
using _1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public class GioHangChiTietRepositories:IGioHangChiTietRepositories
    {
        Db2Context _dbContext;
        List<GioHang> _lst;
        List<GioHangChiTiet> _lst2;

        public bool Add(GioHangChiTiet obj)
        {
           _dbContext.GioHangChiTiets.Add(obj);
            return true;
        }

        public bool Delete(GioHangChiTiet obj)
        {
            _dbContext.GioHangChiTiets.Remove(obj);
            return true;
        }

        public List<GioHang> GetListGioHang()
        {
            return _lst = _dbContext.GioHangs.ToList();
        }

        public List<GioHangChiTiet> GetListGioHangChiTiet()
        {
            return _lst2 = _dbContext.GioHangChiTiets.ToList();
        }

        public bool Update(GioHangChiTiet obj)
        {
            _dbContext.GioHangChiTiets.Update(obj);
            return true;
        }
    }
}
