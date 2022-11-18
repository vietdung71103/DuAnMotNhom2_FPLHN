using _1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IServices
{
    public interface IQLNXBServices
    {
        string Add(NXB obj);
        string Update(NXB obj);
        string Delete(NXB obj);
        List<NXB> GetListNXB();
    }
}
