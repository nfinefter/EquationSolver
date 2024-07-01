using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

using OperationFunc = System.Func<float, float, float>;

namespace MathLibrary
{

    public class Operation : Token
    {

        public static Dictionary<char, (OperationFunc, Priority)> Operations = new()
        {
            ['+'] = ((num1, num2) => num1 + num2, Priority.Addition),
            ['-'] = ((num1, num2) => num1 - num2, Priority.Subtraction),
            ['*'] = ((num1, num2) => num1 * num2, Priority.Multiplication),
            ['/'] = ((num1, num2) => num1 / num2, Priority.Division),
            ['^'] = (MathF.Pow, Priority.Exponent),
        };
        char op;
        public OperationFunc myFunc;
        public override States Parse(char currChar)
        {
            if (Possible = Complete = myFunc == null & Operations.TryGetValue(currChar, out var result))
            {
                op = currChar;
                (myFunc, Priority) = result;
                return States.Valid;
            }
            else return States.None;
           
            
        }
        public override void Cleanse()
        {
            Possible = true;
            Complete = false;
            myFunc = null;
        }
        protected void CloneLogic(Operation replacemnt)
        {
            base.CloneLogic(replacemnt);
        }

        public override Operation Clone()
        {
            Operation copy = new Operation();
            CloneLogic(copy);
            copy.op = op;
            copy.myFunc = myFunc;
            return copy;
        }

        public override float Compute(Token nextToken, float currentValue)
        {
            return myFunc.Invoke(currentValue, ((Number)nextToken).Num);
        }

        public override void Print()
        {
            Console.Write(op);
        }
        public override string ToString()
        {
            return $"{op}";
        }
    }
}
