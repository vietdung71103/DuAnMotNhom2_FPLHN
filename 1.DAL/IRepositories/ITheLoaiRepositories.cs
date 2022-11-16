using _1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public interface ITheLoaiRepositories
    {
        bool Add(TheLoai obj);
        bool Delete(TheLoai obj);
        bool Update(TheLoai obj);
        List<TheLoai> GetListTheLoai(); 
    }
}
