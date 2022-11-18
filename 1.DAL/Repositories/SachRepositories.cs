using _1.DAL.Context;
using _1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public class SachRepositories:ISachRepositories
    {
        Db2Context _dbContext;
        List<Sach> _lst;
        public SachRepositories()
        {
            _dbContext = new Db2Context();
            _lst = new List<Sach>();
        }

        public bool Add(Sach obj)
        {
            _dbContext.Add(obj);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(Sach obj)
        {
            _dbContext.Remove(obj);
            _dbContext.SaveChanges();
            return true;
        }

        public List<Sach> GetListSach()
        {
            _lst = _dbContext.Sachs.ToList();
            return _lst;
        }

        public bool Update(Sach obj)
        {
            _dbContext.Update(obj);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
