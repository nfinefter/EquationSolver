global using MathLibrary;

namespace EquationInputter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            Console.WriteLine("Give me an equation.");
            Equation equation = new Equation(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(equation.ParseEquation());
        }
    }
}