using System.Numerics;
using FluentAssertions;
using Xunit;

namespace Quantum
{
    public class HermitianMatrixTests
    {
        [Fact]
        public void is_hermitian()
        {
            var martix = new Matrix(2, 2);
            martix[0, 0] = new Complex(2, 0);
            martix[0, 1] = new Complex(2, 4);
            martix[1, 0] = new Complex(2, -4);
            martix[1, 1] = new Complex(2, 0);

            var result = martix.IsHermitian();

            result.Should().BeTrue();
        }

        [Fact]
        public void is_not_hermitian()
        {
            var martix = new Matrix(2, 2);
            martix[0, 0] = new Complex(2, 0);
            martix[0, 1] = new Complex(2, 4);
            martix[1, 0] = new Complex(2, 4);
            martix[1, 1] = new Complex(2, 0);

            var result = martix.IsHermitian();

            result.Should().BeFalse();
        }
    }
}