using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DABWinForms.Tools
{
    public interface ICrud
    {
        bool LogIn(int numCarte, int pin);
    }
}
