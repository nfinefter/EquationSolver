namespace MathLibrary
{

    public class Equation
    {

        List<Token> equationList = new List<Token>();
        List<Token> checkingTokens = new()
        {
            new Number(),
            new Operation()
        };
        string equation;
        Number Num1;
        Number Num2;
        Operation Op;
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
        public Equation(char oper, float num1, float num2)
        {

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
            for (int j = 0; j < equation.Length;j++)
            {
                bool allTokensFinished = true;
                for (int i = 0; i < checkingTokens.Count; i++)
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
                if (allTokensFinished)
                {
                    equationList.Add(checkingTokens[index]);
                    j--;
                    checkingTokens[index].Cleanse();
                }
            }
            for (int i = 0; i < equationList.Count; i++)
            {

            }

            return answer;
        }

    }
}
