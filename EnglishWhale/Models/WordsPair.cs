using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishWhale.Models
{
    public class WordsPair
    {
        public string Original { get; }
        public string Translation { get; }

        public WordsPair(string orig, string trans)
        {
            Original = orig;
            Translation = trans;
        }
    }
}
