using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class Number : Token
    {
        public float Num = 0;
        public override bool Parse(char currChar)
        {
            if (currChar >= '0' && currChar <= '9')
            {
                Num *= 10;
                Num += (float)int.Parse(currChar.ToString());
                return true;
            }
            return false;

        }
    }
}
