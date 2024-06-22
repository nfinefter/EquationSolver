using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class Number : Token
    {

        
        int digit = 0;
        public float Num = 0;
        public override States Parse(char currChar)
        {
            States state;

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

            }
            else
            {
                Possible = false;
                Complete = true;
            }
            return (Possible ? States.Possible : States.None) | (Complete ? States.Complete : States.None);
        }
        public override void Cleanse()
        {
            digit = 0;
            Num = 0;
            Possible = true;
            Complete = false;
        }

        protected void CloneLogic(Number replacemnt)
        {
            base.CloneLogic(replacemnt);
        }

        public override Number Clone()
        {
            Number copy = new Number();
            CloneLogic(copy);
            copy.Num = Num;
            copy.digit = digit;

            return copy;
        }

        public override float Compute(Token nextToken, float currentValue)
        {
            return Num;
        }
    }
}



