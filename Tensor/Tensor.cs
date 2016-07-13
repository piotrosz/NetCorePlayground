using System;
using static System.Console;

namespace Quantum
{
    public class Tensor
    {
        public static Matrix Product(Matrix a, Matrix b)
        {
            var result = new Matrix(a.Columns * b.Columns, a.Rows * b.Rows);

            for (int colA = 0; colA < a.Columns; colA++)
            {
                for (int rowA = 0; rowA < a.Rows; rowA++)
                {
                    WriteLine($"Now: {a[rowA, colA]}");
                       
                }
            }   


            

            return result;
        }
    }
}

/*
a11 b11  a11 b11 a21 b11  a11*b11 a11*b21 a21*b11 a21*b21
a21 b21      b21     b21 
*/

/*
a11 a12  b11 b12  a11 b11 b12 a12 b11 b12  a11*b11 a11*b12 a12*b11 a12*b12
a21 a22  b21 b22      b21 b22     b21 b22  a11*b21 a11*b22 a12*b21 a12*b22
                  a21 b11 b21 a22 b11 b12  
                      b21 b22     b21 b22  
*/

/*
a11 a12 a13  b11 b12 b13    a11 b11 a11 b12 
a21 a22 a23  b21 b22 b23
a31 a32 a33  b31 b32 b33
*/