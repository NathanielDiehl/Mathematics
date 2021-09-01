using System;
using System.Collections.Generic;


namespace Mathematics
{
    internal class Vector
    {
        public List<double> vector;
        public int dimensions { get; private set; }
        Vector(List<double> v)
        {
            vector = v;
            dimensions = v.Count;
        }
        Vector(double[] v): this(new List<double>(v))
        {
        }
        public static Vector operator *(Vector v, double s)
        {
            List<double> newV = new List<double>();

            for (int i = 0; i <= v.dimensions; i++)
            {
                newV.Add(v.vector[i] * s);
            }

            return new Vector(newV);
        }
    }
}