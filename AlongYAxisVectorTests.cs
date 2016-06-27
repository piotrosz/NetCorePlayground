using Xunit;
using FluentAssertions;
using System.Numerics;
using static System.Math;

namespace Quantum
{
    public class AlongYAxisVectorsTests
    {
        // test if i and o are orthonormal
        [Fact]
        public void i_and_o_are_orthogonal()
        {
            var result = SpinVector.ScalarProduct(SpinVectorBase.In, SpinVectorBase.Out);
            result.Should().Be(Complex.Zero);

            var result2 = SpinVector.ScalarProduct(SpinVectorBase.Out, SpinVectorBase.In);
            result2.Should().Be(Complex.Zero);
        }

        [Fact]
        public void i_vector_is_normalized()
        {
            var result = SpinVector.ScalarProduct(SpinVectorBase.In, SpinVectorBase.In);

            Abs(result.Magnitude - 1).Should().BeLessThan(0.0001);
        }

        [Fact]
        public void o_vector_is_normalized()
        {
            var result = SpinVector.ScalarProduct(SpinVectorBase.Out, SpinVectorBase.Out);

            Abs(result.Magnitude - 1).Should().BeLessThan(0.0001);
        }

        [Fact]
        public void o_u_multiplied_by_u_o_should_be_half()
        {
            var result = 
                SpinVector.ScalarProduct(SpinVectorBase.Out, SpinVectorBase.Up) *
                SpinVector.ScalarProduct(SpinVectorBase.Up, SpinVectorBase.Out);

            Abs(result.Real - 0.5).Should().BeLessThan(0.0001);
        }

        [Fact]
        public void o_d_multiplied_by_d_o_should_be_half()
        {
            var result = 
                SpinVector.ScalarProduct(SpinVectorBase.Out, SpinVectorBase.Down) *
                SpinVector.ScalarProduct(SpinVectorBase.Down, SpinVectorBase.Out);

            Abs(result.Real - 0.5).Should().BeLessThan(0.0001);
        }

        [Fact]
        public void i_u_multiplied_by_u_i_should_be_half()
        {
            var result = 
                SpinVector.ScalarProduct(SpinVectorBase.In, SpinVectorBase.Up) *
                SpinVector.ScalarProduct(SpinVectorBase.Up, SpinVectorBase.In);

            Abs(result.Real - 0.5).Should().BeLessThan(0.0001);
        }

        [Fact]
        public void i_d_multiplied_by_d_i_should_be_half()
        {
            var result = 
                SpinVector.ScalarProduct(SpinVectorBase.In, SpinVectorBase.Down) *
                SpinVector.ScalarProduct(SpinVectorBase.Down, SpinVectorBase.In);

            Abs(result.Real - 0.5).Should().BeLessThan(0.0001);
        }

        [Fact]
        public void o_r_multiplied_by_r_o_should_be_half()
        {
            var result = 
                SpinVector.ScalarProduct(SpinVectorBase.Right, SpinVectorBase.Out) *
                SpinVector.ScalarProduct(SpinVectorBase.Out, SpinVectorBase.Right);

            Abs(result.Real - 0.5).Should().BeLessThan(0.0001);
        }

        [Fact]
        public void o_l_multiplied_by_l_o_should_be_half()
        {
            var result = 
                SpinVector.ScalarProduct(SpinVectorBase.Left, SpinVectorBase.Out) *
                SpinVector.ScalarProduct(SpinVectorBase.Out, SpinVectorBase.Left);

            Abs(result.Real - 0.5).Should().BeLessThan(0.0001);
        }

        [Fact]
        public void i_r_multiplied_by_r_i_should_be_half()
        {
            var result = 
                SpinVector.ScalarProduct(SpinVectorBase.Right, SpinVectorBase.In) *
                SpinVector.ScalarProduct(SpinVectorBase.In, SpinVectorBase.Right);

            Abs(result.Real - 0.5).Should().BeLessThan(0.0001);
        }

        [Fact]
        public void i_l_multiplied_by_l_i_should_be_half()
        {
            var result = 
                SpinVector.ScalarProduct(SpinVectorBase.Left, SpinVectorBase.In) *
                SpinVector.ScalarProduct(SpinVectorBase.In, SpinVectorBase.Left);

            Abs(result.Real - 0.5).Should().BeLessThan(0.0001);
        }
    }
}