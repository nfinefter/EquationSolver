using System.Globalization;
using System.Numerics;

namespace MathLibrary
{

    public class Equation
    {
        bool error = false;
        List<Token> equationList = new List<Token>();
        List<Token> checkingTokens = new()
        {
            new Number(),
            new Operation(),
            new WhiteSpace(),
            new Error()
        };
        string equation;
        float answer = 0;
        int index = -1;
        public Equation(string equation)
        {
            this.equation = equation;

            //equationList = new()
            //{
            //   (Num1 = new Number()),
            //    (Op = new Operation()),
            //    (Num2 = new Number())
            //};

        }
        //public bool ErrorCheck()
        //{
        //    for (int i = 0; i < equation.Length; i++)
        //    {
        //        if (equation[i] < 0 || (equation[i] > 9 && !Operation.Operations.ContainsKey(equation[i])))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
        public float ParseEquation()
        {
            for (int j = 0; j < equation.Length; j++)
            {
                bool allTokensFinished = true;
                for (int i = 0; i < checkingTokens.Count - 1; i++)
                {
                    if (!checkingTokens[i].Possible)
                    {
                        continue;
                    }
                    var checkParse = checkingTokens[i].Parse(equation[j]);
                    if (checkParse.HasFlag(States.Possible))
                    {
                        allTokensFinished = false;
                        if (checkParse.HasFlag(States.Complete))
                        {
                            index = i;
                        }
                    }
                }
                if (index == -1)
                {
                    ((Error)checkingTokens[3]).ErrorString = equation[j].ToString();
                    index = 3;
                }
                else if (allTokensFinished)
                {
                    ConcludeToken();
                    j--;
                }
            }
            ConcludeToken();
            for (int i = 0; i < equationList.Count; i++)
            {
                if (equationList[i] is WhiteSpace)
                {
                    equationList.RemoveAt(i);
                }
            }



            //if (VerifyTypes())
            //{
            //    answer = ((Number)equationList[0]).Num;
            //    for (int i = 0; i < equationList.Count; i++)
            //    {

            //        if (equationList[i] is Operation)
            //        {
            //            answer = equationList[i].Compute(equationList[i + 1], answer);
            //        }
            //    }
            //}
            //else
            //{
            //    throw new Exception("Invalid Equation");
            //}

            for (int i = 0; i < equationList.Count; i++)
            {
                if (equationList[i].GetType() == typeof(Error))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    error = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                equationList[i].Print();
            }

            Console.WriteLine();

            //if (equationList.Where(m => m.GetType() == typeof(Error)).Count() >= 0)

            if (!error) return CalcTheYard(ShuntingYard(equationList));
            else throw new Exception("An Error was found");

        }
        public void ConcludeToken()
        {
            var last = equationList[equationList.Count - 1];
            if (last.GetType() == typeof(Error))
            {
                ((Error)last).ErrorString += ((Error)checkingTokens[index].Clone()).ErrorString;
            }
            else if (last.GetType() == checkingTokens[index].GetType())
            {
                Error newError = new Error();
                newError.ErrorString = checkingTokens[index].Clone().ToString();

                equationList.Add()
            }
            equationList.Add(checkingTokens[index].Clone());
            for (int i = 0; i < checkingTokens.Count; i++)
            {
                checkingTokens[i].Cleanse();
            }
            index = -1;
        }
        public bool VerifyTypes()
        {
            for (int i = 1; i < equationList.Count; i++)
            {
                if (equationList[i - 1].GetType() == equationList[i].GetType())
                {
                    return false;
                }
            }
            return true;
        }
        public float CalcTheYard((List<Number> Numbers, List<Operation> Operations) list)
        {
            if (list.Numbers.Count != list.Operations.Count + 1) throw new Exception("Invalid Equation");

            float answer = list.Numbers[0].Num;

            for (int i = 1, opIndex = 0; i < list.Numbers.Count; i++, opIndex++)
            {
                answer = list.Operations[opIndex].Compute(list.Numbers[i], answer);    
            }

            return answer;
        }
        public (List<Number>, List<Operation>) ShuntingYard(List<Token> unParsedList)
        {
            //List<Token> output = new();
            Stack<Token> opStack = new();
            List<Operation> operations = new();
            List<Number> numbers = new();

            //for (int i = 0; i < unParsedList.Count; i++)
            //{
            //    if (unParsedList[i] is Number)
            //    {
            //        output.Add(unParsedList[i]);
            //    }
            //    else if (unParsedList[i] is Operation)
            //    {
            //        if (opStack.Count != 0 && opStack.Peek().Priority >= unParsedList[i].Priority)
            //        {
            //            output.Add(opStack.Pop());
            //        }
            //        opStack.Push(unParsedList[i]);
            //    }

            //}
            //while (opStack.Count > 0)
            //{
            //    output.Add(opStack.Pop());
            //}
            for (int i = 0; i < unParsedList.Count; i++)
            {
                if (unParsedList[i] is Number)
                {
                    numbers.Add((Number)unParsedList[i]);
                }
                else if (unParsedList[i] is Operation)
                {
                    if (opStack.Count != 0 && opStack.Peek().Priority >= unParsedList[i].Priority)
                    {
                        operations.Add((Operation)opStack.Pop());
                    }
                    opStack.Push(unParsedList[i]);
                }

            }
            while (opStack.Count > 0)
            {
                if (opStack.Peek().GetType() == typeof(Operation))
                {
                    operations.Add((Operation)opStack.Pop());
                }
                else if (opStack.Peek().GetType() == typeof(Number))
                {
                    numbers.Add((Number)opStack.Pop());
                }
            }


            return (numbers, operations);
        }
    }
}
