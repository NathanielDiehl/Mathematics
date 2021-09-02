using System;
using System.Collections.Generic;


namespace Mathematics
{
    internal class Matrix
    {
        public List<List<double>> matrix { get; private set; }
        public int Row { get; private set; }
        public int Column { get; private set; }

        private static bool isRectangular(List<List<double>> m)
        {
            if (m[0].Count != m.Count)
                return false;
            for (int i = 0; i < m.Count - 1; i++)
            {
                if (m[i].Count != m[i + 1].Count)
                    return false;
            }
            return true;
        }
        private static bool isSquare(List<List<double>> m)
        {
            if (m[0].Count != m.Count)
                return false;
            return isRectangular(m);
        }
        public Matrix(List<List<double>> m)
        {
            if (!isRectangular(m))
            {
                throw new NonRectangularMatrix();
            }
            matrix = m;
            Row = matrix[0].Count;
            Column = matrix.Count;
        }
        public Matrix(double[][] m)
        {
            List<List<double>> temp = new List<List<double>>();
            for (int i = 0; i < m.Length; i++)
            {
                temp.Add(new List<double>(m[i]));
            }
            if (!isRectangular(temp))
            {
                throw new NonRectangularMatrix();
            }
            matrix = temp;
            Row = matrix[0].Count;
            Column = matrix.Count;
        }
    }

    class NonRectangularMatrix : Exception
    {
        public override string Message
        {
            get
            {
                return "matrix cannot be non rectangular";
            }
        }
    }
}