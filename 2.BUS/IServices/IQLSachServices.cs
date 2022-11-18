using _1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IServices
{
    public interface IQLSachServices
    {
        string Add(Sach obj);
        string Update(Sach obj);
        string Delete(Sach obj);
        List<Sach> GetListSach();
    }
}
