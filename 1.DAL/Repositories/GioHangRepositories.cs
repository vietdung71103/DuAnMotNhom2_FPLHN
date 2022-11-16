using _1.DAL.Context;
using _1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public class GioHangRepositories : IGioHangRepositories
    {
        Db2Context _dbContext;
        List<GioHang> _lst;
        List<GioHangChiTiet> _lst2;
        public GioHangRepositories()
        {
            _dbContext = new Db2Context();
            _lst = new List<GioHang>();
        }
        public bool Add(GioHang obj)
        {
            _dbContext.GioHangs.Add(obj);
            return true;
        }

        public bool Delete(GioHang obj)
        {
            _dbContext.GioHangs.Remove(obj);
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

        public bool Update(GioHang obj)
        {
            _dbContext.GioHangs.Update(obj);
            return true;
        }
    }
}
