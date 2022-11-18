using _1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IServices
{
    public interface IQLChucVuServices
    {
        string Add(ChucVu obj);
        string Update(ChucVu obj);
        string Delete(ChucVu obj);
        List<ChucVu> GetListChucVu();
    }
}
