using _1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public interface ITacGiaRepositories
    {
        bool Add(TacGia obj);
        bool Delete(TacGia obj);
        bool Update(TacGia obj);
        List<TacGia> GetListTacGia();

    }
}
