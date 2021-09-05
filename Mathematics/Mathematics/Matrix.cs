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
        private static bool doDiminutionsMatch(List<List<double>> m1, List<List<double>> m2)
        {
            if (m1[0].Count != m2[0].Count)
                return false;
            if (m1.Count != m2.Count)
                return false;
            return isRectangular(m1) && isRectangular(m2);
        }

        private static bool isMultipliable(List<List<double>> m1, List<List<double>> m2)
        {
            if (m1[0].Count != m2.Count)
                return false;
            return isRectangular(m1) && isRectangular(m2);
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

        public Vector getRowVector(int row)
        {
            return new Vector(matrix[row]);
        }
        public Vector getRowColumn(int column)
        {
            List<double> l = new List<double>();
            foreach (var row in matrix)
                l.Add(row[column]);
            return new Vector(l);
        }
        public double Determinate() {
            if (!isSquare(matrix))
                throw new NonSquareMatrix();
            if (matrix.Count == 1)
                return matrix[0][0];
            if (matrix.Count == 2)
                return matrix[0][0] * matrix[1][1] - matrix[1][0] * matrix[0][1];
           List<List<double>>[] newMatrix = new List<List<double>>[Column];
            int spacer;
            for (int i = 0; i < Column; i++)
            {
                newMatrix[i] = new List<List<double>>();
                spacer = 0;
                for (int j = 0; j < Column; j++)
                {
                    if (i != j)
                    {
                        newMatrix[i].Add(new List<double>());
                        for (int k = 1; k < Row; k++)
                            newMatrix[i][j - spacer].Add(matrix[j][k]);
                    }
                    else
                        spacer = 1;
                }
            }
            double determinate = 0;
            for (int i = 0; i < Column; i++)
            {
                determinate += matrix[i][0] * new Matrix(newMatrix[i]).Determinate() * (i%2==0 ? 1 : -1);

            }
            return determinate;
        }
        public static Matrix operator *(Matrix m, double s)
        {
            List<List<double>> newM = new List<List<double>>();

            for (int i = 0; i < m.Row; i++)
            {
                newM.Add(new List<double>());
                for (int j = 0; j < m.Column; j++)
                {
                    newM[i].Add(m.matrix[i][j] * s);
                }
            }

            return new Matrix(newM);
        }
        public static Matrix operator *(double s, Matrix m)
        {
            return m * s;
        }
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            if (!doDiminutionsMatch(m1.matrix, m2.matrix))
                throw new MismatchedMatrixDiminutions();
            List<List<double>> newM = new List<List<double>>();

            for (int i = 0; i < m1.Row; i++)
            {
                newM.Add(new List<double>());
                for (int j = 0; j < m1.Column; j++)
                {
                    newM[i].Add(m1.matrix[i][j] + m2.matrix[i][j]);
                }
            }

            return new Matrix(newM);
        }
        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            return m1 + (-1 * m2);
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if (!isMultipliable(m1.matrix, m2.matrix))
                throw new MismatchedMatrixDiminutions();
            List<List<double>> newM = new List<List<double>>();

            for (int i = 0; i < m1.Row; i++)
            {
                newM.Add(new List<double>());
                for (int j = 0; j < m1.Column; j++)
                {
                    newM[i].Add(m1.getRowVector(i) * m2.getRowColumn(j) );
                }
            }

            return new Matrix(newM);
        }

        public static Matrix operator ^(Matrix m, int s)
        {

            if (s < 0)
                throw new DividingByMatrix();
            Matrix newM = m;

            for(int i = 1; i < s; i++)
            {
                newM *= m;
            }
            return newM;

        }

        public override string ToString()
        {
            String str = "";
            int[] spacing = new int[Column];
            double max =0;

            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)

                    if (max < matrix[j][i])
                        max = matrix[j][i];
                spacing[i] = General.GetNumberOfDigets(max);
                max = 0;
            }



            for (int i = 0; i < Row; i++)
            {
                str += "|";

                for (int j = 0; j < Column; j++)
                {
                    for (int k = 0; k < spacing[j] - General.GetNumberOfDigets(matrix[i][j]); k++)
                        str += " ";
                    str += matrix[i][j];
                    if (j != Column - 1)
                    {
                        str += ", ";
                        
                    }
                    
                }
                str += "|\n";
                
            }

            return str;
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


    class NonSquareMatrix : Exception
    {
        public override string Message
        {
            get
            {
                return "matrix isn;t square";
            }
        }
    }
    class MismatchedMatrixDiminutions : Exception
    {
        public override string Message
        {
            get
            {
                return "matrixes don't have the same diminutions";
            }
        }
    }
    class DividingByMatrix : Exception
    {
        public override string Message
        {
            get
            {
                return "can not divid by a matrix";
            }
        }
    }
}