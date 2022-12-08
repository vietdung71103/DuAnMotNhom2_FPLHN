using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IServices
{
    public interface IQuenMatKhau
    {
        string RandomMa(int size, bool chuthuong);
        int RandomSo(int min, int max);
        void Update(string email, string password);
        string MaHoa(string password);
        string GuiEmail(string email, string password);
    }
}
