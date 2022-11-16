using _1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public interface ISachChiTietRepositories
    {
        bool Add(SachChiTiet obj);
        bool Delete(SachChiTiet obj);
        bool Update(SachChiTiet obj);
    
        List<SachChiTiet> GetListSachChiTiet();
    }
}
