using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishWhale.View
{
    public interface IMute
    {
        bool MuteQuestion { get; set; }
        bool MuteAnswer { get; set; }
    }
}
