using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.DAL.Models;
using _1.DAL.IRepositories;
using _1.DAL.Context;

namespace _1.DAL.Repositories
{
    public class KhuyenMai_repos : Ikhuyenmai_repo
    {
        Db2Context _dbContext;
        public KhuyenMai_repos()
        {
            _dbContext = new Db2Context();
        }
    //    bool Ikhuyenmai_repo.Add(KhuyenMai obj)
    //    {
    //        _dbContext.khuyenmai.Add(obj);
    //        _dbContext.SaveChanges();
    //        return true;
    //    }

    //    bool Ikhuyenmai_repo.Delete(KhuyenMai obj)
    //    {
    //        _dbContext.khuyenmai.Remove(obj);
    //        _dbContext.SaveChanges();
    //        return true;
    //    }

    //    List<KhuyenMai> Ikhuyenmai_repo.GetList()
    //    {
    //        return _dbContext.khuyenmai.ToList(); ;
    //    }

    //    bool Ikhuyenmai_repo.Update(KhuyenMai obj)
    //    {
    //        _dbContext.khuyenmai.Update(obj);
    //        _dbContext.SaveChanges();
    //        return true;
    //    }
    }
}
