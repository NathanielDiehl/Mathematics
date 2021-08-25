using System;
using System.Collections.Generic;


namespace Mathematics
{
    internal class Complex
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }
        public Complex(double r = 0, double i = 0)
        {
            Real = r;
            Imaginary = i;
        }
        public static explicit operator Complex(double d)
        {
            return new Complex(d);
        }
        public static explicit operator double(Complex d)
        {
            return d.Real;
        }
        public static Complex operator *(Complex c1, double s)
        {
            return new Complex(c1.Real * s, c1.Imaginary * s);
        }
        public static Complex operator *(double s, Complex c1)
        {
            return c1 * s;
        }
        public static Complex operator /(Complex c1, double s)
        {
            return new Complex(c1.Real / s, c1.Imaginary / s);
        }
        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
        }
        public static Complex operator -(Complex c1, Complex c2)
        {
            return c1 + c2*-1;
        }
        public static Complex operator *(Complex c1, Complex c2)
        {
            return new Complex(c1.Real*c2.Real - c1.Imaginary*c2.Imaginary, c2.Real*c1.Imaginary + c1.Real*c2.Imaginary);
        }
        public static Complex operator /(Complex n, Complex d)
        {
            return (d.Conjugate() * n) / (d* d.Conjugate()).Real;
        }
        public static Complex operator ^(Complex c1, int s)
        {
            Complex newNum = new Complex(1, 0);
            if (s == 0)
            {
                return newNum;
            }
            else if (s > 0)
            {
                for (int i = 0; i < s; i++)
                {
                    newNum *= c1;
                }
            }
            else
            {
                for (int i = 0; i > s; i--)
                {
                    newNum /= c1;
                }
            }
            return newNum;
        }

        public Complex Conjugate()
        {
            return new Complex(this.Real, -this.Imaginary);
        }
        public override string ToString()
        {
            if(Real == 0 && Imaginary == 0)
            {
                return "";
            }else if (Real == 0)
            {
                return Imaginary + "i";
            }
            else if (Imaginary == 0)
            {
                return Real.ToString();
            }
            return Real + " + " + Imaginary + "i";
        }
    }
}