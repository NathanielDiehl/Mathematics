using System;
using System.Collections.Generic;


namespace Mathematics
{
    internal class Calculus
    {
        public static Polynomial Derivative(Polynomial p)
        {
            //Polynomial derivativePolynomial = new Polynomial();
            List<Complex> scalars = new List<Complex>(/*p.Degree+1*/);

            for (int i = 0; i < p.Degree; i++)
            {
                scalars.Add((p.Degree - i) * p.scalars[i]);
            }

            return new Polynomial(scalars);
        }
        public static Polynomial Integral(Polynomial p, Complex c)
        {
            List<Complex> scalars = new List<Complex>();

            for (int i = 0; i <= p.Degree; i++)
            {
                scalars.Add(p.scalars[i] / (p.Degree - i + 1));
            }

            scalars.Add(c);

            return new Polynomial(scalars);
        }
        public static Polynomial Integral(Polynomial p, double c)
        {
            return Integral(p, new Complex(c));
        }
        public static Complex Integral(Polynomial p, double a, double b)
        {
            Polynomial i = Integral(p, 0);

            return i.function(a) - i.function(b);
        }
    }
}