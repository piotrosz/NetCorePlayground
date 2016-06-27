using Xunit;
using FluentAssertions;
using System.Numerics;
using static System.Math;

namespace Quantum
{
    public class AlongYAxisVectorsTests
    {
        SpinVector @in;
        SpinVector @out;

        public AlongYAxisVectorsTests()
        {
            @in = new SpinVector(upComponent: new Complex(real: 1/Sqrt(2), imaginary: 0),
                                  downComponent: new Complex(real: 0, imaginary: 1/Sqrt(2)));

            @out = new SpinVector(upComponent: new Complex(real: 1/Sqrt(2), imaginary: 0),
                                  downComponent: new Complex(real: 0, imaginary: -1/Sqrt(2)));
        }

        // test if r and l are orthonormal
        [Fact]
        public void i_and_o_are_orthogonal()
        {
            var result = SpinVector.ScalarProduct(@in, @out);
            result.Should().Be(0);

            var result2 = SpinVector.ScalarProduct(@out, @in);
            result2.Should().Be(0);
        }

        [Fact]
        public void i_vector_is_normalized()
        {
            var result = SpinVector.ScalarProduct(@in, @in);

            Abs(result - 1).Should().BeLessThan(0.0001);
        }

        [Fact]
        public void o_vector_is_normalized()
        {
            var result = SpinVector.ScalarProduct(@out, @out);

            Abs(result - 1).Should().BeLessThan(0.0001);
        }
    }
}