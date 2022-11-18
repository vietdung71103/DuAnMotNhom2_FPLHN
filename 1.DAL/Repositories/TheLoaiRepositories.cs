using _1.DAL.Context;
using _1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public class TheLoaiRepositories:ITheLoaiRepositories
    {
        Db2Context _dbContext;
        List<TheLoai> _lst;
        public TheLoaiRepositories()
        {
            _lst = new List<TheLoai>();
            _dbContext = new Db2Context();
        }

        public bool Add(TheLoai obj)
        {
            _dbContext.TheLoais.Add(obj);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(TheLoai obj)
        {
            _dbContext.TheLoais.Remove(obj);
            _dbContext.SaveChanges();
            return true;
        }

        public List<TheLoai> GetListTheLoai()
        {
            _lst = _dbContext.TheLoais.ToList();
            return _lst;
        }

        public bool Update(TheLoai obj)
        {
            _dbContext.TheLoais.Update(obj);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
