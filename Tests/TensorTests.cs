using System;
using System.Numerics;
using FluentAssertions;
using Xunit;
using static System.Console;

namespace Quantum
{
    public class TensorTests
    {
        [Fact]
        public void product_of_two_column_vectors()
        {
            var vector1 = new Matrix(new Complex[,] 
            {
                {1}, 
                {0}
            });

            var vector2 = new Matrix(new Complex[,] 
            {
                {0},
                {1}
            });

            var result = Tensor.Product(vector1, vector2);
            //WriteLine(result);

            (result == new Matrix(new Complex[,]
            {
                {0},
                {1},
                {0},
                {0}
            })).Should().BeTrue();
        }

        [Fact]
        public void product_of_two_column_vectors2()
        {
            var v1 = new Matrix(new Complex[,] 
            {
                {1}, 
                {0}
            });

            var v2 = new Matrix(new Complex[,] 
            {
                {1},
                {0}
            });

            var result = Tensor.Product(v1, v2);

            (result == new Matrix(new Complex[,]
            {
                {1},
                {0},
                {0},
                {0}
            })).Should().BeTrue();
        } 

        [Fact]
        public void product_of_2_2x2_matrices()
        {
            var m1 = new Matrix(new Complex[,] 
            {
                {1, 2},
                {3, 4}
            });
            var m2 = new Matrix(new Complex[,]
            {
                {1, 4},
                {2, 3}
            });

            var result = Tensor.Product(m1, m2);
            //WriteLine(result);
            (result == new Matrix(new Complex[,]
            {
                {1, 4,  2, 8},
                {2, 3,  4, 6},
                {3, 12, 4, 16},
                {6, 9,  8, 12}
            })).Should().BeTrue();
        }
    }
}