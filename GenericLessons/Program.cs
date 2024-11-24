using System.Numerics;

namespace GenericLessons
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var calculator = new Calculator<int, int, int>(); // success
            calculator.Add(5, 5);
            var calculator2 = new Calculator<double, int, int>(); // throw exception
            calculator2.Add(10.2, 2);

            var calculator3 = new Calculator3();
            calculator3.Add<int, int, int>(5, 5);
        }
    }


    public class Product : BaseEntity<int>
    {
    }

    public class Stock : BaseEntity<Guid>
    {
    }


    public class BaseEntity<T>
    {
        public T Id { get; set; }

        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }


    public class Calculator3
    {
        public T3 Add<T1, T2, T3>(T1 a, T2 b) where T1 : INumber<T1> where T2 : INumber<T2> where T3 : INumber<T3>
        {
            var x = (dynamic)a + (dynamic)b;

            return x;
        }

        public T1 Multiply<T1, T2>(T1 a, T2 b)
        {
            var x = (dynamic)a + (dynamic)b;
            return x;
        }
    }


    public class Calculator<T1, T2, T3> where T1 : INumber<T1> where T2 : INumber<T2> where T3 : INumber<T3>
    {
        public T3 Add(T1 a, T2 b)
        {
            var x = (dynamic)a + (dynamic)b;

            return x;
        }


        //public T Subtract(T a, T b)
        //{
        //    return a - b;
        //}

        //public T Multiply(T a, T b)
        //{
        //    return a * b;
        //}

        //public T Divide(T a, T b)
        //{
        //    return a / b;
        //}
    }


    public class Calculator<T> where T : INumber<T>
    {
        public T Add(T a, T b)
        {
            return a + b;
        }


        public T Subtract(T a, T b)
        {
            return a - b;
        }

        public T Multiply(T a, T b)
        {
            return a * b;
        }

        public T Divide(T a, T b)
        {
            return a / b;
        }
    }
}