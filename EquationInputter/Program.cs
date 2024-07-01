global using MathLibrary;

namespace EquationInputter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int verdict;
            do
            {
                EquationCalculator();

                Console.WriteLine("Another one? \n1) Yes \n2) No");
                verdict = int.Parse(Console.ReadLine());

                
            } while (verdict == 1);

        }
        public static void EquationCalculator()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Give me an equation.");
            Equation equation = new Equation(Console.ReadLine());

            if (equation.TryParseEquation(out float answer))
            {
                Console.WriteLine(answer);
            }
            else Console.WriteLine("Unable to Compute");
            Console.WriteLine();
            
        }
    }
}