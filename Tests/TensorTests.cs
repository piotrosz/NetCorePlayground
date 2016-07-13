using System;
using System.Numerics;
using FluentAssertions;
using Xunit;

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
            var vector1 = new Matrix(new Complex[,] 
            {
                {1}, 
                {0}
            });

            var vector2 = new Matrix(new Complex[,] 
            {
                {1},
                {0}
            });

            var result = Tensor.Product(vector1, vector2);

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

            (result == new Matrix(new Complex[,]
            {
                { 1, 4, 2, 8 },
                { 2, 3, 4, 6 },
                { 3, 12, 8, 12},
                { }
            })).Should().BeTrue();
        }
    }
}