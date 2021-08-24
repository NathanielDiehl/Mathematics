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
        public static double[] Quadratic_Equation(double a, double b, double c)
        {
            double Answer1 = -b / 2 / a, Answer2 = -b / 2 / a;
            double d = Discriminant(a, b, c);

            if (d >= 0)
            {
                Answer1 += Math.Sqrt(d) / 2 / a;
                Answer2 -= Math.Sqrt(d) / 2 / a;
            }

            return new double[] { Answer1, Answer2 };
        }
    }
}