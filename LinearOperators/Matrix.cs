using System.Numerics;
using System.Text;

namespace Quantum
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
            var resultMatrix = new Matrix(m1.Height, m2.Width);
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

        public static Matrix MultiplyByNumber(Matrix m, Complex c)
        {
            var resultMatrix = new Matrix(m.Height, m.Width);
            for (int i = 0; i < resultMatrix.Height; i++)
            {
                for (int j = 0; j < resultMatrix.Width; j++)
                {
                    resultMatrix[i, j] = m[i, j] * c;
                }
            }
            return resultMatrix;
        }

        public static Matrix Transpose(Matrix m)
        {
            var resultMatrix = new Matrix(m.Width, m.Height);
            for (int i = 0; i < resultMatrix.Height; i++)
            {
                for (int j = 0; j < resultMatrix.Width; j++)
                {
                    resultMatrix[i, j] = m[j, i];
                }
            }
            return resultMatrix;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < this.Width; i++)
            {
                stringBuilder.AppendLine();
                for (int j = 0; j < this.Height; j++)
                {
                    stringBuilder.Append($" {this[j, i]}");
                }
            }
            return stringBuilder.ToString();
        }
    }
}