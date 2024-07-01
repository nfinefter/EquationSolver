using System.Globalization;
using System.Numerics;

namespace MathLibrary
{

    public class Equation
    {
        const int ErrorIndex = 3;
        bool error = false;
        List<Token> equationList = new List<Token>();
        List<Token> rawList = new List<Token>();
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
        public bool TryParseEquation(out float answer)
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
                    ((Error)checkingTokens[ErrorIndex]).ErrorString = equation[j].ToString();
                    index = ErrorIndex;
                }
                else if (allTokensFinished)
                {
                    ConcludeToken();
                    j--;
                }
            }

            ConcludeToken();




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
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();

            //if (equationList.Where(m => m.GetType() == typeof(Error)).Count() >= 0)

            //if (!error)
            return CalcTheYard(ShuntingYard(equationList), out answer);


            //else throw new Exception("An Error was found");

        }
        void Cleanse()
        {
            for (int i = 0; i < checkingTokens.Count; i++)
            {
                checkingTokens[i].Cleanse();
            }
            index = -1;
        }
        public void ConcludeToken()
        {

            //for (int i = 0; i < equationList.Count; i++)
            //{
            //    if (equationList[i] is WhiteSpace)
            //    {
            //        equationList.RemoveAt(i);
            //    }
            //}

            if (index == 2)
            {
                Cleanse();
                return;
            }

            if (rawList.Count > 0)
            {
                var prev = rawList[^1];
                //if (prev.GetType() == typeof(Error))
                //{
                //    ((Error)prev).ErrorString += ((Error)checkingTokens[index].Clone()).ErrorString;
                //}

                if (prev.GetType() != typeof(Error) && prev.GetType() == checkingTokens[index].GetType())
                {
                    Error newError = new Error();
                    newError.ErrorString = checkingTokens[index].Clone().ToString();
                    checkingTokens[index = ErrorIndex] = newError;
                }
            }
            if (index != ErrorIndex)
            {
                rawList.Add(checkingTokens[index].Clone());
            }
                equationList.Add(checkingTokens[index].Clone());


            Cleanse();
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
        public bool CalcTheYard((List<Number> Numbers, List<Operation> Operations) list, out float answer)
        {
            bool success = true;
            if (list.Numbers.Count != list.Operations.Count + 1) success = false;

            answer = list.Numbers[0].Num;

            for (int i = 1, opIndex = 0; i < list.Numbers.Count; i++, opIndex++)
            {
                answer = list.Operations[opIndex].Compute(list.Numbers[i], answer);
            }

            return success;
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
