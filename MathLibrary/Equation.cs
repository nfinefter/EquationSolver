using System.Numerics;

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
                    ConcludeToken();
                    j--;
                }
            }
            ConcludeToken();
            if(VerifyTypes())
            {
                 answer = ((Number)equationList[0]).Num;
                for (int i = 0; i < equationList.Count; i++)
                {

                    if (equationList[i].GetType() == typeof(Operation)) 
                    {
                        
                        answer = equationList[i].Compute(equationList[i + 1], answer);
                    }
                }
            }

           

            return answer;
        }
        public void ConcludeToken()
        {
            equationList.Add(checkingTokens[index].Clone());
            for (int i = 0; i < checkingTokens.Count; i++)
            {
                checkingTokens[i].Cleanse();
            }
        }
        public bool VerifyTypes()
        {
            for (int i = 1; i < equationList.Count; i++)
            {
                if (equationList[i -1].GetType() == equationList[i].GetType())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
