using _1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IServices
{
    public interface IQLTacGiaServices
    {
        string Add(TacGia obj);
        string Update(TacGia obj);
        string Delete(TacGia obj);
        List<TacGia> GetListTacGia();
    }
}
