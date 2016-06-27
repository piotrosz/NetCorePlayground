using System.Numerics;

namespace Quantum.LinearOperators
{
    public class Matrix
    {
        private readonly Complex[,] _matrix;
        public Matrix(int dim1, int dim2)
        {
            _matrix = new Complex[dim1, dim2];
        }

        public int Height { get { return _matrix.GetLength(0); } }
        public int Width { get { return _matrix.GetLength(1); } }

        public Complex this[int x, int y]
        {
            get { return _matrix[x, y]; }
            set { _matrix[x, y] = value; }
        }  

        public static Matrix NaiveMultiplication(Matrix m1, Matrix m2)
        {
            Matrix resultMatrix = new Matrix(m1.Height, m2.Width);
            for (int i = 0; i < resultMatrix.Height; i++)
            {
                for (int j = 0; j < resultMatrix.Width; j++)
                {
                    resultMatrix[i, j] = 0;
                    for (int k = 0; k < m1.Width; k++)
                    {
                        resultMatrix[i, j] += m1[i, k] * m2[k, j];
                    }
                }
            }
            return resultMatrix;
        }
    }
}