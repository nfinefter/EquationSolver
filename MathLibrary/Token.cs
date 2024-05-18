using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public abstract class Token
    {
        public abstract bool Parse(char currChar);
    }
}
