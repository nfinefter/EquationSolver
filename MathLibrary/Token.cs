using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    [Flags]
    public enum States
    {
        None = 0,
        Possible = 1,
        Complete = 2,

        Valid = Possible | Complete
    }
    public enum Priority
    {
        Number = 0,
        Addition = 1,
        Subtraction = 1,
        Multiplication = 2,
        Division = 2,
        Exponent = 3
    }
    public abstract class Token
    {
        public Priority Priority;
        public bool Possible { get; protected set; } = true;
        public bool Complete { get; protected set; } = false;

        //public static explicit operator States(Token token)
        //{
          
        //}

        public abstract States Parse(char currChar);
        public abstract void Cleanse();

        protected virtual void CloneLogic(Token replacemnt)
        {
            replacemnt.Possible = Possible;
            replacemnt.Complete = Complete;
            replacemnt.Priority = Priority;
        }
        public abstract float Compute(Token nextToken, float currentValue);

        public abstract Token Clone();
    }
}
