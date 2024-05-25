using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class Number : Token
    {
        int digit = 0;
        public float Num = 0;
        public override bool Parse(char currChar)
        {

            if (digit == 0)
            {
                if (currChar == '-')
                {
                    Possible = true;
                    Complete = false;
                }
            }
            digit++;

            if (currChar >= '0' && currChar <= '9')
            {
                Num *= 10;
                Num += (float)int.Parse(currChar.ToString());
                Possible = true;
                Complete = true;
                return true;
                
            }
            Possible = false;
            Complete = false;
            Fail = true;
            return false;

        }
    }
}
