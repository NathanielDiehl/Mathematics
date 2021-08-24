using System;
using System.Collections.Generic;


namespace Mathematics
{
    internal class Polynomial
    {
        private List<double> scalars;
        public int Degree { get; private set; }

        public Polynomial(List<double> s)
        {
            scalars = s;
            Degree = s.Count-1;
        }
        public Polynomial(double a = Double.MaxValue, double b = Double.MaxValue, double c = Double.MaxValue, double d = Double.MaxValue, double e = Double.MaxValue, double f = Double.MaxValue, double g = Double.MaxValue, double h = Double.MaxValue, double i = Double.MaxValue, double j = Double.MaxValue, double k = Double.MaxValue)
        {
            scalars = new List<double>();
            double[] nums = new double[] { a, b, c, d, e, f, g, h, i, j, k };
            int l = 0;
            for (int spot = nums.Length - 1; spot >= 0; spot--)
            {
                if (nums[spot] != Double.MaxValue)
                    break;
                l++;
            }
            for (int spot = 0; spot < nums.Length - l; spot++)
            {
                scalars.Add(nums[spot]);
            }
            Degree = scalars.Count-1;
        }
        public double function(double x)
        {
            double value = 0;

            for (int spot = 0; spot <= Degree; spot++)
            {
                value += scalars[spot] * Math.Pow(x, scalars.Count - spot - 1);
            }

            return value;
        }
        public static Polynomial operator *(Polynomial p, double s)
        {
            List<double> newP = new List<double>();

            for(int i = 0; i <= p.Degree; i++)
            {
                newP.Add(p.scalars[i] * s);
            }

            return new Polynomial(newP);
        }
        public override string ToString()
        {
            string str = "";
            for (int spot = 0; spot <= Degree; spot++)
            {
                str += scalars[spot];

                if (Degree - spot > 1)
                {
                    str += "x^" + (Degree - spot) + " + ";
                }
                else if (Degree - spot == 1)
                {
                    str += "x + ";
                }

            }
            return str;
        }

    }
    /*
    internal class Polynomial
    {
        private List<Complex> scalars;
        public int Degree { get; private set; }

        public Polynomial(List<Complex> s)
        {
            scalars = s;
            Degree = s.Count-1;
        }
        /*public Polynomial(Complex a = null, Complex b = null, Complex c = null, Complex d = null, Complex e = null, Complex f = null; Complex g = null, Complex h = null, Complex i = null, Complex j = null, Complex k = null)
        {
            a = new Complex(0, 0); //a == null ? new Complex(0) : a;
            Complex num2 = new Complex(1, 2);

            scalars = new List<Complex>();
            Complex[] nums = new Complex[] { a, b, c, d, e, f, g, h, i, j, k };
            int l = 0;
            for (int spot = nums.Length - 1; spot >= 0; spot--)
            {
                if (nums[spot] != 0)
                    break;
                l++;
            }
            for (int spot = 0; spot < nums.Length - l; spot++)
            {
                scalars.Add(nums[spot]);
            }
            Degree = scalars.Count;
        }
        public Complex function(double x)
        {
            Complex value = new Complex(0,0);

            for (int spot = 0; spot <= scalars.Count; spot++)
            {
                value += scalars[spot] * Math.Pow(x, Degree - spot);
            }

            return value;
        }
        public static Polynomial operator *(Polynomial p, double s)
        {
            List<Complex> newP = new List<Complex>();

            for (int i = 0; i <= p.Degree; i++)
            {
                newP.Add(p.scalars[i] * s);
            }

            return new Polynomial(newP);
        }
        public override string ToString()
        {
            string str = "";
            for (int spot = 0; spot <= Degree; spot++)
            {
                if (scalars[spot].Real == 0 && scalars[spot].Imaginary == 0)
                {

                }
                else if (scalars[spot].Imaginary == 0)
                {
                    str += scalars[spot].Real;
                }
                else if (scalars[spot].Real == 0)
                {
                    str += scalars[spot].Imaginary + "i";
                }
                else
                {
                    str += "(" + scalars[spot] + ")";
                }

                if (Degree - spot > 1)
                {
                    str += "x^" + (Degree - spot) + " + ";
                }
                else if (Degree - spot == 1)
                {
                    str += "x + ";
                }
            }
            return str;
        }
        
    }*/

}