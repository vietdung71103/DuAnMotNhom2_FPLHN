using _1.DAL.Context;
using _1.DAL.IRepositories;
using _1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Repositories
{
    public class AnhRepositories : IAnhRepositories
    {
        Db2Context _dbContext;
        List<Anh> _lst;
        public AnhRepositories()
        {
            _lst = new List<Anh>();
            _dbContext = new Db2Context();
        }
        public bool Add(Anh obj)
        {
            _dbContext.Anhs.Add(obj);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(Anh obj)
        {
            _dbContext.Anhs.Remove(obj);
            _dbContext.SaveChanges();
            return true;
        }

        public List<Anh> GetListAnh()
        {
            _lst = _dbContext.Anhs.ToList();
            
            return _lst;
        }

        public bool Update(Anh obj)
        {
            _dbContext.Anhs.Update(obj);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
