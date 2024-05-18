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
        public override bool Parse(char currChar) =>  myFunc == null && Operations.TryGetValue(currChar, out myFunc);

    }
}
