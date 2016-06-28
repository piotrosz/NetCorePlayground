using Xunit;
using FluentAssertions;
using System.Numerics;

namespace Quantum
{
    public class MatrixTests
    {
        [Fact]
        public void when_matrix_transposed_then_M_ij_equals_M_ji()
        {
            var matrix = new Matrix(2, 2);
            matrix[0, 0] = new Complex(1, 0);
            matrix[0, 1] = new Complex(2, 2);
            matrix[1, 0] = new Complex(3, 3);
            matrix[1, 1] = new Complex(4, 0);

            var result = Matrix.Transpose(matrix);

            result[0, 0].Should().Be(matrix[0, 0]);
            result[1, 1].Should().Be(matrix[1, 1]);
            result[0, 1].Should().Be(matrix[1, 0]);
            result[1, 0].Should().Be(matrix[0, 1]);
        }
    }
}