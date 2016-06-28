using System.Numerics;

namespace Quantum
{
    public static class MatrixExtensions
    {
        public static bool IsHermitian(this Matrix m)
        {
            bool result = true;
            for (int row = 0; row < m.Rows; row++)
            {
                for (int column = 0; column < m.Columns; column++)
                {
                    if(m[row, column] != Complex.Conjugate(m[column, row]))
                    {
                        return false;
                    }
                }
            }

            return result;
        }

        public static Matrix Transpose(this Matrix m)
        {
            var resultMatrix = new Matrix(m.Columns, m.Rows);
            for (int row = 0; row < resultMatrix.Rows; row++)
            {
                for (int column = 0; column < resultMatrix.Columns; column++)
                {
                    resultMatrix[row, column] = m[column, row];
                }
            }
            return resultMatrix;
        }
    }
}