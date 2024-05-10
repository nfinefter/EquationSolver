using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OperationFunc = System.Func<float, float, float>;

namespace MathLibrary
{

    public class Operation
    {

        public static Dictionary<char, OperationFunc> Operations = new()
        {
            ['+'] = (num1, num2) => num1 + num2,
            ['-'] = (num1, num2) => num1 - num2,
            ['*'] = (num1, num2) => num1 * num2,
            ['/'] = (num1, num2) => num1 / num2,
        };

        OperationFunc myFunc;
        public bool Parse(char currChar) => Operations.TryGetValue(currChar, out myFunc);

    }
}
