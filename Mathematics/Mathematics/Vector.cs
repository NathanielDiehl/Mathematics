using System;
using System.Collections.Generic;


namespace Mathematics
{
    internal class Vector
    {
        private List<double> vector;

        public double this[int i]
        {
            get
            {
                return vector[i];
            }
            set
            {
                vector[i] = value;
            }
        }


        public int Dimensions { get; private set; }
        public Vector(List<double> v)
        {
            vector = v;
            Dimensions = v.Count;
        }
        public Vector(double[] v) : this(new List<double>(v))
        {
        }
        public Vector(double a = Double.MaxValue, double b = Double.MaxValue, double c = Double.MaxValue, double d = Double.MaxValue, double e = Double.MaxValue, double f = Double.MaxValue, double g = Double.MaxValue, double h = Double.MaxValue, double i = Double.MaxValue, double j = Double.MaxValue, double k = Double.MaxValue)
        {
            vector = new List<double>();
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
                vector.Add(nums[spot]);
            }
            Dimensions = vector.Count;
        }
        public double Magnitude()
        {
            double inner = 0;
            foreach(double num in vector)
            {
                inner += num * num;
            }
            return Math.Sqrt(inner);
        }
        public Vector Unit()
        {
            
            return this/this.Magnitude();
        }
        public static Vector operator *(Vector v, double s)
        {
            List<double> newV = new List<double>();

            for (int i = 0; i < v.Dimensions; i++)
            {
                newV.Add(v.vector[i] * s);
            }

            return new Vector(newV);
        }
        public static Vector operator *(double s, Vector v)
        {
            return v * s;
        }
        public static Vector operator /(Vector v, double s)
        {
            return v * (1/s);
        }
        public static Vector operator +(Vector v1, Vector v2)
        {
            Vector newV;
            Vector shortV;
            if (v1.Dimensions > v2.Dimensions)
            {
                shortV = v2;
                newV = v1;
            }
            else
            {
                shortV = v1;
                newV = v2;
            }

            for (int i = 0; i < shortV.Dimensions; i++)
            {
                newV.vector[i] += shortV.vector[i];
            }

            return newV;
        }

        public static double operator *(Vector v1, Vector v2) ///Dot
        {
            double dot = 0;
            int shorterDimension;
            int longerDimension;
            List<double> numbers = new List<double>(); ;
            if (v1.Dimensions > v2.Dimensions)
            {
                shorterDimension = v2.Dimensions;
                longerDimension = v1.Dimensions;
            }
            else
            {
                shorterDimension = v1.Dimensions;
                longerDimension = v2.Dimensions;
            }
            for (int i = 0; i < longerDimension; i++)
            {
                numbers.Add(0);
            }
            for (int i = 0; i < shorterDimension; i++)
            {
                dot += v1.vector[i] * v2.vector[i];
            }

            return dot;
        }
        /// Cross

        public static Vector operator -(Vector v1, Vector v2)
        {
            return v1 + (-1 * v2);
        }

        public override string ToString()
        {
            String str = "<";

            for (int i = 0; i < Dimensions; i++)
            {
                str += vector[i];
                if (i != Dimensions - 1)
                    str += ", ";
            }
            str += ">";

            return str;
        }
    }
}