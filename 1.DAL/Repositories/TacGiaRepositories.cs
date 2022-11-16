using _1.DAL.Context;
using _1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public class TacGiaRepositories:ITacGiaRepositories
    {
        Db2Context _dbContext;
        List<TacGia> _lst;
        public TacGiaRepositories()
        {
            _lst = new List<TacGia>();
            _dbContext = new Db2Context();
        }

        public bool Add(TacGia obj)
        {
           _dbContext.TacGias.Add(obj);
            return true;
        }

        public bool Delete(TacGia obj)
        {
            _dbContext.TacGias.Remove(obj);
            return true;
        }

        public List<TacGia> GetListTacGia()
        {
            _lst = _dbContext.TacGias.ToList();
            return _lst;
        }

        public bool Update(TacGia obj)
        {
            _dbContext.TacGias.Update(obj);
            return true;
        }
    }
}
