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
    public class NhanVienRepositories : INhanVienRepositories
    {
        Db2Context _dbContext;
        List<NhanVien> _lst;
        public NhanVienRepositories()
        {
            _lst = new List<NhanVien>();
            _dbContext = new Db2Context();
        }
        public bool Add(NhanVien obj)
        {
            _dbContext.NhanViens.Add(obj);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(NhanVien obj)
        {
            _dbContext.NhanViens.Remove(obj);
            _dbContext.SaveChanges();
            return true;
        }

        public List<NhanVien> GetListNhanVien()
        {
            _lst = _dbContext.NhanViens.AsNoTracking().ToList();
            return _lst;
        }

        public bool Update(NhanVien obj)
        {
            _dbContext.NhanViens.Update(obj);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
