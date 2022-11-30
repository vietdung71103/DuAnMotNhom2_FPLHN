using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3.PL.Utilities
{
    public class CheckClass
    {
        public bool CheckEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,10})+)$");
            Match match = regex.Match(email);
        return false;
        }
    }
}
