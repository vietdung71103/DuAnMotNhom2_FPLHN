using _1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public interface INXBRepositories
    {
        bool Add(NXB obj);
        bool Delete(NXB obj);
        bool Update(NXB obj);
        List<NXB> GetListNXB();
    }
}
