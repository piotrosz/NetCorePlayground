using System;
using System.Numerics;
using System.Text;

namespace Quantum
{
    public class Matrix
    {
        private readonly Complex[,] _matrix;
        public Matrix(int columns, int rows)
        {
            _matrix = new Complex[columns, rows];
        }

        public Matrix(Complex[,] matrix)
        {
            _matrix = matrix;
        }

        public int Rows { get { return _matrix.GetLength(0); } }
        public int Columns { get { return _matrix.GetLength(1); } }

        public Complex this[int x, int y]
        {
            get { return _matrix[x, y]; }
            set { _matrix[x, y] = value; }
        }  

        public static Matrix NaiveMultiplication(Matrix m1, Matrix m2)
        {
            if (m1.Columns != m2.Rows)
            {
                throw new Exception("m1.Columns != m2.Rows");    
            }

            var resultMatrix = new Matrix(m1.Rows, m2.Columns);
            for (int row = 0; row < resultMatrix.Rows; row++)
            {
                for (int column = 0; column < resultMatrix.Columns; column++)
                {
                    resultMatrix[row, column] = 0;
                    for (int k = 0; k < m1.Columns; k++)
                    {
                        resultMatrix[row, column] += m1[row, k] * m2[k, column];
                    }
                }
            }
            return resultMatrix;
        }

        public static Matrix MultiplyByNumber(Matrix m, Complex c)
        {
            var resultMatrix = new Matrix(m.Rows, m.Columns);
            for (int row = 0; row < resultMatrix.Rows; row++)
            {
                for (int column = 0; column < resultMatrix.Columns; column++)
                {
                    resultMatrix[row, column] = m[row, column] * c;
                }
            }
            return resultMatrix;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            for (int r = 0; r < this.Rows; r++)
            {
                stringBuilder.AppendLine();
                for (int c = 0; c < this.Columns; c++)
                {
                    stringBuilder.Append($" {this[r, c].ToString().PadLeft(8)}");
                }
            }
            return stringBuilder.ToString();
        }

        public static Matrix operator *(Matrix left, Matrix right)
         => Matrix.NaiveMultiplication(left, right);
        
        public static bool operator ==(Matrix a, Matrix b)
        {
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            return InternalEquals(a, b);
        }

        public static bool operator !=(Matrix a, Matrix b)
         => !(a == b);
        
        public static Matrix operator *(Complex c, Matrix m) 
         => MultiplyByNumber(m, c); 

        public static Matrix operator -(Matrix a, Matrix b)
        {
            if(a.Rows != b.Rows || a.Columns != b.Columns)
            {
                throw new Exception("Cannot substract matrices");
            }

            var resultMatrix = new Matrix(a.Rows, a.Columns);
            for (int r = 0; r < a.Rows; r++)
            {
                for (int c = 0; c < a.Columns; c++)
                {
                    resultMatrix[r, c] = a[r, c] - b[r, c];
                }
            }

            return resultMatrix;
        }

        public override bool Equals(System.Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var m = obj as Matrix;
            if ((System.Object)m == null)
            {
                return false;
            }

            return InternalEquals(m, this);
        }

        public bool Equals(Matrix m)
        {
            // If parameter is null return false:
            if ((object)m == null)
            {
                return false;
            }

            return InternalEquals(m, this);
        }

        public override int GetHashCode()
        {
            return _matrix.GetHashCode();
        }

        private static bool InternalEquals(Matrix a, Matrix b)
        {
            if(a.Columns != b.Columns)
            {
                return false;
            }

            if(a.Rows != b.Rows)
            {
                return false;
            }

            for (int r = 0; r < a.Rows; r++)
            {
                for (int c = 0; c < a.Columns; c++)
                {
                    if(a[r, c] != b[r ,c])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}