using System;
using System.Collections.Generic;


namespace Mathematics
{
    internal class Algebra
    {
        public static double Discriminant(double a, double b, double c)
        {
            return b * b - 4 * a * c;
        }
        public static Complex[] Quadratic_Equation(double a, double b, double c)
        {
            Complex Answer1 = new Complex(- b / 2 / a), Answer2 = new Complex(-b / 2 / a);
            double d = Discriminant(a, b, c);

            if (d >= 0)
            {
                Answer1.Real += Math.Sqrt(d) / 2 / a;
                Answer2.Real -= Math.Sqrt(d) / 2 / a;
            }
            else
            {
                Answer1.Imaginary += Math.Sqrt(Math.Abs(d)) / 2 / a;
                Answer2.Imaginary -= Math.Sqrt(Math.Abs(d)) / 2 / a;
            }

            return new Complex[] { Answer1, Answer2 };
        }
    }
}