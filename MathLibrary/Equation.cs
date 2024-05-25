namespace MathLibrary
{

    public class Equation
    {

        List<Token> equationList;
        List<Token> checkingTokens = new()
        {
            new Number(),
            new Operation()
        };
        string equation;
        Number Num1;
        Number Num2;
        Operation Op;
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
            for (int i = 0; i < equation.Length; i++)
            {
                for (int j = 0; j < checkingTokens.Count; j++)
                {
                    if (!checkingTokens[j].Parse(equation[i]))
                    {
                        
                    }
                }
            }
            return Op.myFunc.Invoke(Num1.Num, Num2.Num);
        }

    }
}
