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
            var martix = new Matrix(new Complex[,] 
            {
                { new Complex(2, 0),  new Complex(2, 4) },
                { new Complex(2, -4), new Complex(2, 0) }
            });
            var result = martix.IsHermitian();
            result.Should().BeTrue();
        }

        [Fact]
        public void is_not_hermitian()
        {
            var martix = new Matrix(new Complex[,] 
            {
                { new Complex(2, 0), new Complex(2, 4) },
                { new Complex(2, 4), new Complex(2, 0) }
            });

            var result = martix.IsHermitian();
            result.Should().BeFalse();
        }
    }
}