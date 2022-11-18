using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.DAL.Models;

namespace _2.BUS.IServices
{
    public interface IQLAnhServices
    {
        string Add(Anh obj);
        string Update(Anh obj);
        string Delete(Anh obj);
        List<Anh> GetListAnh();
    }
}
