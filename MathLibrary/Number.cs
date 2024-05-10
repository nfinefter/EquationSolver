using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public static class Number
    {
        public static float Parse(ref int currentIndex, string equation)
        {
            int powCount = 0;
            float Num = 0;
            for (currentIndex = equation.Length - 1; currentIndex >= 0; currentIndex--)
            {
                if (equation[currentIndex] >= '0' && equation[currentIndex] <= '9')
                {
                    Num += (float)(int.Parse(equation[currentIndex].ToString()) * Math.Pow(10, powCount));
                    powCount++;
                }
                else
                {
                    break;
                }
            }

            return Num;
        }
    }
}
