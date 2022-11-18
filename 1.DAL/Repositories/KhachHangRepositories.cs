using _1.DAL.Context;
using _1.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public class KhachHangRepositories:IKhachHangRepositories
    {
        Db2Context _dbContext;
        List<KhachHang> _lst;
        public KhachHangRepositories()
        {
            _lst = new List<KhachHang>();
            _dbContext = new Db2Context();
        }

        public bool Add(KhachHang obj)
        {
            _dbContext.KhachHangs.Add(obj);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(KhachHang obj)
        {
            _dbContext.KhachHangs.Remove(obj);
            _dbContext.SaveChanges();
            return true;
        }

        public List<KhachHang> GetListKhachHang()
        {
            _lst = _dbContext.KhachHangs.AsNoTracking().ToList();
            return _lst;
        }

        public bool Update(KhachHang obj)
        {
            _dbContext.KhachHangs.Update(obj);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
