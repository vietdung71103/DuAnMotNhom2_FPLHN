using _1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IServices
{
    public interface IQLTheLoaiServices
    {
        string Add(TheLoai obj);
        string Update(TheLoai obj);
        string Delete(TheLoai obj);
        List<TheLoai> GetListTheLoai();
    }
}
