using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OperationFunc = System.Func<float, float, float>;

namespace MathLibrary
{

    public class Operation : Token
    {

        public static Dictionary<char, OperationFunc> Operations = new()
        {
            ['+'] = (num1, num2) => num1 + num2,
            ['-'] = (num1, num2) => num1 - num2,
            ['*'] = (num1, num2) => num1 * num2,
            ['/'] = (num1, num2) => num1 / num2,
        };

        public OperationFunc myFunc;
        public override States Parse(char currChar) => (Possible = Complete = myFunc == null && Operations.TryGetValue(currChar, out myFunc)) ? States.Valid : States.None;

        public override void Cleanse()
        {
            Possible = false;
            Complete = false;
        }
    }
}
