using System;

namespace MyFirstConsoleApp
{
    class Program
    {
        #region Main method
        // Main method
        static void Main(string[] args)
        {
            Console.WriteLine("Find Factorial");
            Console.Write("Input any positive number : ");
            int num = Convert.ToInt32(Console.ReadLine());
            long factorial = Factorial.CalculateFactorial(num);
            Console.WriteLine("The factorial of {0} is : {1} ", num, factorial);
        }
        #endregion
    }
}
