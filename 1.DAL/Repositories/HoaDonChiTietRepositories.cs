using _1.DAL.Context;
using _1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public class HoaDonChiTietRepositories:IHoaDonChiTietRepositories
    {

        Db2Context _dbContext;
        List<HoaDon> _lst;
        List<HoaDonChiTiet> _lst2;
        public HoaDonChiTietRepositories()
        {
            _dbContext = new Db2Context();
            _lst = new List<HoaDon>();
            _lst2 = new List<HoaDonChiTiet>();
        }

        public bool Add(HoaDonChiTiet obj)
        {
            _dbContext.HoaDonChiTiets.Add(obj);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(HoaDonChiTiet obj)
        {
            _dbContext.HoaDonChiTiets.Remove(obj);
            _dbContext.SaveChanges();
            return true;
        }

        public List<HoaDon> GetListHoaDon()
        {
            _lst = _dbContext.HoaDons.ToList();
            return _lst;
        }

        public List<HoaDonChiTiet> GetListHoaDonChiTiet()
        {
            _lst2 = _dbContext.HoaDonChiTiets.ToList();
            return _lst2;
        }

        public bool Update(HoaDonChiTiet obj)
        {
            _dbContext.HoaDonChiTiets.Update(obj);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
