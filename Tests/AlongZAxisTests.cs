using FluentAssertions;
using Xunit;
using System.Numerics;

namespace Quantum
{
    public class AlongZAxisTests
    {
        [Fact]
        public void u_and_d_are_orthogonal()
        {
            var result = SpinVector.ScalarProduct(SpinVectorBase.Up, SpinVectorBase.Down);
            result.Should().Be(Complex.Zero);
        }

        [Fact]
        public void u_is_normalized()
        {
            var result = SpinVector.ScalarProduct(SpinVectorBase.Up, SpinVectorBase.Up);
            result.Magnitude.Should().Be(1);
        }

        [Fact]
        public void d_is_normalized()
        {
            var result = SpinVector.ScalarProduct(SpinVectorBase.Down, SpinVectorBase.Down);
            result.Magnitude.Should().Be(1);
        }
    }
}