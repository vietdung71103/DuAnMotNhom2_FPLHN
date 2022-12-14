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
    public class SachChiTietRepositories:ISachChiTietRepositories
    {
        Db2Context _dbContext;
        List<SachChiTiet> _lst;
        public SachChiTietRepositories()
        {
            _lst = new List<SachChiTiet>();
            _dbContext = new Db2Context();
        }

        public bool Add(SachChiTiet obj)
        {
           _dbContext.SachChiTiets.Add(obj);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(SachChiTiet obj)
        {
            _dbContext.SachChiTiets.Remove(obj);
            _dbContext.SaveChanges();
            return true;
        }


        public List<SachChiTiet> GetListSachChiTiet()
        {
            _lst = _dbContext.SachChiTiets.AsNoTracking().ToList();
            return _lst;
        }

        public bool Update(SachChiTiet obj)
        {
            _dbContext.SachChiTiets.Update(obj);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
