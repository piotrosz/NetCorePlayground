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

        SpinVector up;
        SpinVector down;

        public AlongYAxisVectorsTests()
        {
            @in = new SpinVector(upComponent: new Complex(real: 1/Sqrt(2), imaginary: 0),
                                  downComponent: new Complex(real: 0, imaginary: 1/Sqrt(2)));

            @out = new SpinVector(upComponent: new Complex(real: 1/Sqrt(2), imaginary: 0),
                                  downComponent: new Complex(real: 0, imaginary: -1/Sqrt(2)));

            up = new SpinVector(upComponent: new Complex(real: 1, imaginary: 0), 
                                downComponent: Complex.Zero);
            down = new SpinVector(upComponent: Complex.Zero,
                                  downComponent: new Complex(real: -1, imaginary: 0));
        }

        // test if i and o are orthonormal
        [Fact]
        public void i_and_o_are_orthogonal()
        {
            var result = SpinVector.ScalarProduct(@in, @out);
            result.Should().Be(Complex.Zero);

            var result2 = SpinVector.ScalarProduct(@out, @in);
            result2.Should().Be(Complex.Zero);
        }

        [Fact]
        public void i_vector_is_normalized()
        {
            var result = SpinVector.ScalarProduct(@in, @in);

            Abs(result.Real - 1).Should().BeLessThan(0.0001);
        }

        [Fact]
        public void o_vector_is_normalized()
        {
            var result = SpinVector.ScalarProduct(@out, @out);

            Abs(result.Real - 1).Should().BeLessThan(0.0001);
        }

        [Fact]
        public void o_u_multiplied_by_u_o_should_be_half()
        {
            var result = 
                SpinVector.ScalarProduct(@out, up) *
                SpinVector.ScalarProduct(up, @out);

            Abs(result.Real - 0.5).Should().BeLessThan(0.0001);
        }

        [Fact]
        public void o_d_multiplied_by_d_o_should_be_half()
        {
            var result = 
                SpinVector.ScalarProduct(@out, down) *
                SpinVector.ScalarProduct(down, @out);

            Abs(result.Real - 0.5).Should().BeLessThan(0.0001);
        }

        [Fact]
        public void i_u_multiplied_by_u_i_should_be_half()
        {
            var result = 
                SpinVector.ScalarProduct(@in, up) *
                SpinVector.ScalarProduct(up, @in);

            Abs(result.Real - 0.5).Should().BeLessThan(0.0001);
        }

        [Fact]
        public void i_d_multiplied_by_d_i_should_be_half()
        {
            var result = 
                SpinVector.ScalarProduct(@in, down) *
                SpinVector.ScalarProduct(down, @in);

            Abs(result.Real - 0.5).Should().BeLessThan(0.0001);
        }
    }
}