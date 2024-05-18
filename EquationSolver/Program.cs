namespace EquationSolver
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]


        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //Severity	Code	Description	Project	File	Line	Suppression State
            //Error NETSDK1045  The current .NET SDK does not support targeting .NET 8.0.Either target.NET 6.0 or lower, or use a version of the.NET SDK that supports .NET 8.0.EquationInputter    C:\Program Files\dotnet\sdk\6.0.401\Sdks\Microsoft.NET.Sdk\targets\Microsoft.NET.TargetFrameworkInference.targets   144



            Application.Run(new Form1());
        }
    }
}