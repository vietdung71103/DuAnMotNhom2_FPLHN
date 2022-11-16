using _1.DAL.Context;
using _1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public class NXBRepositories:INXBRepositories
    {
        Db2Context _dbContext;
        List<NXB> _lst;
        public NXBRepositories()
        {
            _lst = new List<NXB>();
            _dbContext = new Db2Context();
        }

        public bool Add(NXB obj)
        {
            _dbContext.NXBs.Add(obj);
            return true;
        }

        public bool Delete(NXB obj)
        {
            _dbContext.NXBs.Remove(obj);
            return true;
        }

        public List<NXB> GetListNXB()
        {
            _lst = _dbContext.NXBs.ToList();
            return _lst;
        }

        public bool Update(NXB obj)
        {
            _dbContext.NXBs.Update(obj);
            return true;
        }
    }
}
