using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class Error : Token
    {
        public string ErrorString = "";
        public Error() 
        {
            Complete = true;
        }

        public override void Cleanse()
        {
            Possible = true;
            Complete = true;
        }

        public override Token Clone()
        {
            Error copy = new Error();
            CloneLogic(copy);
            copy.ErrorString = ErrorString;
            return copy;
        }

        public override float Compute(Token nextToken, float currentValue)
        {
            throw new NotImplementedException();
        }

        public override States Parse(char currChar)
        {
            throw new NotImplementedException();
        }

        public override void Print()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(ErrorString);
        }
    }
}
