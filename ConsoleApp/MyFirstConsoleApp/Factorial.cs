namespace MyFirstConsoleApp
{
    class Factorial
    {
        #region CalculateFactorial Method
        // CalculateFactorial function to calculate factorial with number as a input parameter
        public static int CalculateFactorial(int num)
        {
            if (num == 0)
				return 1;
            else if(num > 0)
				return num * CalculateFactorial(num - 1);
            return 0;
        }
        #endregion
    }
}
