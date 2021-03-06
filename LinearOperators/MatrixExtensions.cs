using System;
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

        public static bool IsUnitary(this Matrix m)
        {
            Matrix result = m.HermitianConjugate() * m;
            return result.IsIdentity();
        }

        public static bool IsIdentity(this Matrix m)
        {
            bool result = true;

            for (int row = 0; row < m.Rows; row++)
            {
                for (int column = 0; column < m.Columns; column++)
                {
                    if(row == column && m[row, column] != 1)
                    {
                        return false;
                    }

                    if(row != column && m[row, column] != 0)
                    {
                        return false;
                    }
                }
            }

            return result;
        }

        public static Matrix HermitianConjugate(this Matrix m)
        {
            var resultMatrix = new Matrix(m.Columns, m.Rows);
            for (int row = 0; row < resultMatrix.Rows; row++)
            {
                for (int column = 0; column < resultMatrix.Columns; column++)
                {
                    resultMatrix[row, column] = Complex.Conjugate(m[column, row]);
                }
            }
            return resultMatrix;
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

        public static Complex ScalarProduct(this Matrix m1, Matrix m2)
        {
            Complex result = 0;
            if(m1.Rows == m2.Rows && m1.Columns == 1 && m2.Columns == 1)
            {
                for (int row = 0; row < m1.Rows; row++)
                {
                    result += Complex.Conjugate(m1[row, 0]) * m2[row, 0];
                }
            }
            else if(m1.Columns == m2.Columns && m1.Rows == 1 && m2.Rows == 1)
            {
                for (int col = 0; col < m2.Columns; col++)
                {
                    result += Complex.Conjugate(m1[0, col]) * m2[0, col];
                }
            }
            else
            {
                throw new Exception("Cannot calculate scalar product");
            }

            return result;
        }

        public static Matrix Conjugate(this Matrix m)
        {
            for (int row = 0; row < m.Rows; row++)
            {
                for (int column = 0; column < m.Columns; column++)
                {
                    m[row, column] = Complex.Conjugate(m[row, column]);
                }
            }

            return m;
        }

        public static double Abs(this Matrix m)
        {
            return Complex.Abs(m.ScalarProduct(m));
        }

        // <a|P|a> = average value of observable associated with P
        public static Complex Sandwich(this Matrix vector, Matrix @operator)
        {
            return vector.ScalarProduct(@operator * vector);
        }

        public static Complex Trace(this Matrix m)
        {
            if(m.Columns != m.Rows)
            {
                throw new Exception("Not a square matrix");
            }

            Complex result = Complex.Zero;
            for (int i = 0; i < m.Columns; i++)
            {
                result += m[i, i];
            }

            return result;
        }
    }
}