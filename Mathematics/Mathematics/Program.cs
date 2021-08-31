using System;

namespace Mathematics
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Polynomial p1 = new Polynomial(1, 2, 3, 4, 5);
            Console.WriteLine(p1.function(5));*/
            //Polynomial p1 = new Polynomial(new List<Complex>{ new Complex(1, 5), new Complex(0, 5), new Complex(1)} );
            
            Polynomial p = new Polynomial(5, 5, 5, 7);
            Polynomial d = Calculus.Derivative(p);
            Polynomial i = Calculus.Integral(d, 7);

            Console.WriteLine(p);
            Console.WriteLine(d);
            Console.WriteLine(i);
            Console.WriteLine(Calculus.Integral(d, 3, 1) );

            //Console.WriteLine(p1.function(5) );

            /*Complex c1 = new Complex(1, 5);
            Complex c2 = new Complex(3, 4);
            Console.WriteLine(c1/c2);*/
        }
    }
}
