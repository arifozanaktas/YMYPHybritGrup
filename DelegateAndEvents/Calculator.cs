using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateAndEvents
{
    public delegate int MathCalculatorDelegate(int x, int y);

    public class MathCalculator
    {
        public int MathCalculate(int a, int b, MathCalculatorDelegate mathCalculator)
        {
            return mathCalculator(a, b);
        }

        //public int Multiply(int a, int b, MathCalculatorDelegate mathCalculator)
        //{
        //    return mathCalculator(a, b);
        //}

        //public int Subtract(int a, int b, MathCalculatorDelegate mathCalculator)
        //{
        //    return mathCalculator(a, b);
        //}

        //public int Divide(int a, int b, MathCalculatorDelegate mathCalculator)
        //{
        //    return mathCalculator(a, b);
        //}
    }

    //public class Calculator
    //{
    //    public int Calculate(int x, int y, int z, MultiplyDelegate multiplyDelegate)
    //    {
    //        return multiplyDelegate(x, y, z);
    //    }
    //}
}