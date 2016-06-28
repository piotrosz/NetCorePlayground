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
            // if (m1.Rows != m2.Columns)
            // {
            //     throw new Exception("m1.Columns != m2.Rows");    
            // }

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
            // for (int column = 0; column < this.Columns; column++)
            // {
            //     stringBuilder.AppendLine();
            //     for (int row = 0; row < this.Rows; row++)
            //     {
            //         stringBuilder.Append($" {this[row, column]}");
            //     }
            // }
            
            for (int r = 0; r < this.Rows; r++)
            {
                stringBuilder.AppendLine();
                for (int c = 0; c < this.Columns; c++)
                {
                    stringBuilder.Append($" {this[r, c]}");
                }
            }
            

            return stringBuilder.ToString();


        }

        public static Matrix operator *(Matrix left, Matrix right) 
        {   
            return Matrix.NaiveMultiplication(left, right);
        }
    }
}