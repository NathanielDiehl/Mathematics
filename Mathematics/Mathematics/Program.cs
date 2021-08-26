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
            Polynomial p1 = new Polynomial(1, 2, 3);
            Polynomial p2 = new Polynomial(5, 5, 5, 7);
            Console.WriteLine(p1+p2);
            //Console.WriteLine(p1.function(5) );

            /*Complex c1 = new Complex(1, 5);
            Complex c2 = new Complex(3, 4);
            Console.WriteLine(c1/c2);*/
        }
    }
}
