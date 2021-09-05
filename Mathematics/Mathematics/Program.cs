using System;
using System.Collections.Generic;

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
            //Console.WriteLine(v2 * v1);
            
            List<List<double>> m1Data = new List<List<double>>() { 
                new List<double>(){ 1, 2, 3 },
                new List<double>(){ 400, 5, 6 },
                new List<double>(){ 7, 8, 9 } };
            Matrix m1 = new Matrix(m1Data);

            List<List<double>> m2Data = new List<List<double>>() {
                new List<double>(){ 1, 0, 0 },
                new List<double>(){ 0, 1, 0 },
                new List<double>(){ 0, 0, 1 } };
            Matrix m2 = new Matrix(m2Data);

            Console.WriteLine(m2);
            Console.WriteLine("\n"+m2.Determinate());
        }
    }
}
