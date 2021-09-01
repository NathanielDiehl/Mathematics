using System;

namespace Mathematics
{
    class Program
    {
        static void Main(string[] args)
        {
            Polynomial p = new Polynomial(5, 5, 5, 7);
            Polynomial d = Calculus.Derivative(p);
            Polynomial i = Calculus.Integral(d, 7);

            /*Console.WriteLine(p);
            Console.WriteLine(d);
            Console.WriteLine(i);
            Console.WriteLine(Calculus.Integral(d, 3, 1) );*/

            Vector v1 = new Vector(1, 2, 3, 4);
            Vector v2 = new Vector(10, 20, 30);
            //Console.WriteLine(v2 - v1);
        }
    }
}
