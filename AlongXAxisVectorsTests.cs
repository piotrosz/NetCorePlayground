using Xunit;
using FluentAssertions;
using System.Numerics;
using static System.Math;

namespace Quantum
{
    public class AlongXAxisVectorsTests
    {
        SpinVector left;
        SpinVector right;

        public AlongXAxisVectorsTests()
        {
            left = new SpinVector(upComponent: new Complex(real: 1/Sqrt(2), imaginary: 0),
                                  downComponent: new Complex(real: 1/Sqrt(2), imaginary: 0));

            right = new SpinVector(upComponent: new Complex(real: 1/Sqrt(2), imaginary: 0),
                                  downComponent: new Complex(real: -1/Sqrt(2), imaginary: 0));
        }

        // test if r and l are orthonormal
        [Fact]
        public void r_and_l_are_orthogonal()
        {
            var result = SpinVector.ScalarProduct(left, right);
            result.Should().Be(Complex.Zero);
        }

        [Fact]
        public void r_vector_is_normalized()
        {
            var result = SpinVector.ScalarProduct(right, right);

            Abs(result.Real - 1).Should().BeLessThan(0.0001);
        }

        [Fact]
        public void l_vector_is_normalized()
        {
            var result = SpinVector.ScalarProduct(left, left);

            Abs(result.Real - 1).Should().BeLessThan(0.0001);
        }
    }
}