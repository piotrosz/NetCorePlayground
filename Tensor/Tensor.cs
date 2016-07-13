using System;
using static System.Console;

namespace Quantum
{
    public class Tensor
    {
        public static Matrix Product(Matrix a, Matrix b)
        {
            var result = new Matrix(a.Rows * b.Rows, a.Columns * b.Columns);            
            int currentRow = 0, currentCol = 0;

            for (int rowA = 0; rowA < a.Rows; rowA++)
            {
                for (int colA = 0; colA < a.Columns; colA++)
                {
                    Matrix temp = a[rowA, colA] * b;

                    for (int row = 0; row < temp.Rows; row++)
                    {
                        for (int col = 0; col < temp.Columns; col++)
                        {
                            //WriteLine($"result[{currentRow + row}, {currentCol + col}] = temp[{row}, {col}]");
                            result[currentRow + row, currentCol + col] = temp[row, col];
                        }
                    }

                    currentCol += b.Columns;
                    if(currentCol == result.Columns)
                    {
                        currentCol = 0;
                    }
                }

                currentRow += b.Rows;
                if(currentRow == result.Rows)
                {
                    currentRow = 0;
                }
            }
            
            return result;
        }
    }
}

