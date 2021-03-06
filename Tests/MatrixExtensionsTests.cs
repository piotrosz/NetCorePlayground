using Xunit;
using FluentAssertions;
using System.Numerics;
using System;

namespace Quantum
{
    public class MatrixExtensionsTests
    {
        [Fact]
        public void when_matrix_transposed_then_M_ij_equals_M_ji()
        {
            var matrix = new Matrix(new Complex[,] 
            {
                { new Complex(1, 0), new Complex(2, 2) },
                { new Complex(3, 3), new Complex(4, 0) }
            });

            var expected = new Matrix(new Complex[,] 
            {
                { new Complex(1, 0), new Complex(3, 3) },
                { new Complex(2, 2), new Complex(4, 0) }
            }); 

            var result = matrix.Transpose();

            (result == expected).Should().BeTrue();
        }

        [Fact]
        public void martix_string_representation_is_correct()
        {
            var matrix = new Matrix(new Complex[,] {
                {1, 2},
                {3, 4}
            });

            //Console.WriteLine(matrix);
            matrix.ToString().Should().Be($"{Environment.NewLine}  (1, 0)  (2, 0){Environment.NewLine}  (3, 0)  (4, 0)");
        }

        [Fact]
        public void simple_real_scalar_product()
        {
            var m1 = new Matrix(new Complex[,] 
            { 
                {1}, 
                {2} 
            });

            var m2 = new Matrix(new Complex[,] 
            { 
                {3}, 
                {6} 
            });

            var result1 = m1.ScalarProduct(m2);
            var result2 = m2.ScalarProduct(m1);

            //Console.WriteLine(result1);
            //Console.WriteLine(result2);

            result1.Should().Be(new Complex(15, 0));
            result2.Should().Be(new Complex(15, 0));
        }

        [Fact]
        public void simple_complex_scalar_product()
        {
            var m1 = new Matrix(new Complex[,] 
            { 
                {new Complex(1, 5)}, 
                {new Complex(-1, -9)} 
            });

            var m2 = new Matrix(new Complex[,] 
            { 
                {new Complex(0, 7)}, 
                {new Complex(6, 3)} 
            });

            var result1 = m1.ScalarProduct(m2);
            var result2 = m2.ScalarProduct(m1);

            //Console.WriteLine(result1);
            //Console.WriteLine(result2);

            result1.Should().Be(new Complex(2, 58));
            result2.Should().Be(new Complex(2, -58));
        }

        [Fact]
        public void is_identity()
        {
            var m = new Matrix(new Complex[,]
            {
                {1, 0},
                {0, 1}
            });

            m.IsIdentity().Should().BeTrue();
        }

        [Fact]
        public void is_not_identity()
        {
            var m = new Matrix(new Complex[,]
            {
                {0, 2},
                {-4, 1}
            });

            m.IsIdentity().Should().BeFalse();
        }

        [Fact]
        public void identity_matrix_is_created()
        {
            var result = Matrix.GetIdentityMatrix(3);

            (result == new Matrix(new Complex[,] {
                {1, 0, 0},
                {0, 1, 0},
                {0, 0, 1}
            })).Should().BeTrue();
        }

        // [Fact]
        // public void is_unitary_matrix()
        // {
        //     double x = 2*Math.Sqrt(2);

        //     var m = new Matrix(new Complex[,]
        //     {
        //         {new Complex(1/x, 1/x), new Complex(1/x, -1/x)},
        //         {new Complex(-1/x, -1/x), new Complex(1/x, -1/x)}
        //     });

        //     m.IsUnitary().Should().BeTrue();
        // }
    }
}