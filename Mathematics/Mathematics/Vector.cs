using System;
using System.Collections.Generic;


namespace Mathematics
{
    internal class Vector
    {
        public List<double> vector;
        public int dimensions { get; private set; }
        public Vector(List<double> v)
        {
            vector = v;
            dimensions = v.Count;
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
            dimensions = vector.Count;
        }
        public static Vector operator *(Vector v, double s)
        {
            List<double> newV = new List<double>();

            for (int i = 0; i < v.dimensions; i++)
            {
                newV.Add(v.vector[i] * s);
            }

            return new Vector(newV);
        }
        public static Vector operator *(double s, Vector v)
        {
            return v * s;
        }
        public static Vector operator +(Vector v1, Vector v2)
        {
            Vector newV;
            Vector shortV;
            if (v1.dimensions > v2.dimensions)
            {
                shortV = v2;
                newV = v1;
            }
            else
            {
                shortV = v1;
                newV = v2;
            }

            for (int i = 0; i < shortV.dimensions; i++)
            {
                newV.vector[i] += shortV.vector[i];
            }

            return newV;
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            return v1 + (-1 * v2);
        }

        public override string ToString()
        {
            String str = "<";

            for (int i = 0; i < dimensions - 1; i++)
            {
                str += vector[i] + ", ";
            }
            str += vector[dimensions - 1] + ">";

            return str;
        }
    }
}