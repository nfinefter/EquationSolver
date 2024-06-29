using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class WhiteSpace : Token
    {
        HashSet<char> whiteSpaceChars = new HashSet<char>();
        
        public WhiteSpace ()
        {
            whiteSpaceChars.Add(' ');
            whiteSpaceChars.Add('\t');
        }
        public override void Cleanse()
        {
            Possible = true;
            Complete = false;
        }

        public override Token Clone()
        {
            WhiteSpace copy = new WhiteSpace();
            CloneLogic(copy);
            
            return copy;
        }

        public override float Compute(Token nextToken, float currentValue)
        {
            throw new NotImplementedException();                    
        }

        public override States Parse(char currChar)
        {
            for (int i = 0; i < whiteSpaceChars.Count; i++)
            {
                if (whiteSpaceChars.Contains(currChar))
                {
                    Possible = true;
                    Complete = true;
                }
                else
                {
                    Possible = false;
                    Complete = false;
                }
            }
            
            return (Possible ? States.Possible : States.None) | (Complete ? States.Complete : States.None);
        }

        public override void Print()
        {
        }
    }
}
