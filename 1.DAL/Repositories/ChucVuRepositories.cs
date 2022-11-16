using _1.DAL.Context;
using _1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public class ChucVuRepositories : IChucVuRepositories
    {
        List<ChucVu> _lst;
        Db2Context _dbContext;
        public ChucVuRepositories()
        {
            _dbContext = new Db2Context();
            _lst = new List<ChucVu>();
            GetListChucVu();
        }
        public bool Add(ChucVu obj)
        {
            _dbContext.ChucVus.Add(obj);
            return true;
        }

        public bool Delete(ChucVu obj)
        {
            _dbContext.ChucVus.Remove(obj);
            return true;
        }

        public List<ChucVu> GetListChucVu()
        {
            _lst = _dbContext.ChucVus.ToList();
            return _lst;
        }

        public bool Update(ChucVu obj)
        {
            _dbContext.ChucVus.Update(obj);
            return true;
        }
    }
}
