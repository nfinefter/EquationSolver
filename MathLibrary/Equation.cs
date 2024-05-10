namespace MathLibrary
{

    public class Equation
    {
       

        string equation;
        float Num1;
        float Num2;
        char Op;
        public Equation (string equation)
        {
            this.equation = equation;
        }
        public Equation (char oper, float num1, float num2)
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
            Operation currentOp = new();
            for (int i = 0; i < equation.Length; i++)
            {
                if (equation[i] != ' ')
                {
                    //error, finished, continue
                    if (currentOp.Parse(equation[i]))
                    {

                    }
                }
            }

            int index = equation.Length - 1;
            Num2 = Number.Parse(ref index, equation);
            Op = Operation.Parse(ref index, equation);
            Num1 = Number.Parse (ref index, equation);
            return Operation.Operations[Op].Invoke(Num1, Num2);
        }

    }
}
