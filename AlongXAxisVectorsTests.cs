using Xunit;
using FluentAssertions;
using System.Numerics;
using static System.Math;

namespace Quantum
{
    public class AlongXAxisVectorsTests
    {
        // test if r and l are orthonormal
        [Fact]
        public void r_and_l_are_orthogonal()
        {
            var result = SpinVector.ScalarProduct(SpinVectorBase.Left, SpinVectorBase.Right);
            result.Should().Be(Complex.Zero);
        }

        [Fact]
        public void r_vector_is_normalized()
        {
            var result = SpinVector.ScalarProduct(SpinVectorBase.Right, SpinVectorBase.Right);

            Abs(result.Real - 1).Should().BeLessThan(0.0001);
        }

        [Fact]
        public void l_vector_is_normalized()
        {
            var result = SpinVector.ScalarProduct(SpinVectorBase.Left, SpinVectorBase.Left);

            Abs(result.Real - 1).Should().BeLessThan(0.0001);
        }
    }
}