using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public abstract class Token
    {
        public bool Possible { get; protected set; } = false;
        public bool Complete { get; protected set; } = false;
        public abstract bool Parse(char currChar);
    }
}
    