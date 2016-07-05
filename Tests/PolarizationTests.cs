using System;
using System.Numerics;
using FluentAssertions;
using Xunit;

namespace Quantum
{
    public class PolarizationTests
    {
        [Fact]
        public void polarization_operator_acting_on_horizontal_state_gives_horizontal_state()
        {
            var result = Polarization.PolatizationOperator * Polarization.HorizontalStateVector;
            (result == Polarization.HorizontalStateVector).Should().BeTrue();
            //Console.WriteLine(result);
        }

        [Fact]
        public void polarization_operator_acting_on_vertical_state_gives_minus_vertical_state()
        {
            var result = Polarization.PolatizationOperator * Polarization.VerticalStateVector;
            (result == -1 * Polarization.VerticalStateVector).Should().BeTrue();
        }

        [Fact]
        public void state_vectors_are_orthogonal()
        {
            var result =  Polarization.FortyFiveDegreesStateVector.ScalarProduct(Polarization.MinusFortyFiveDegreesStateVector);
            Complex.Abs(result).Should().BeLessThan(0.0001);
        }

        [Fact]
        public void state_vectors_are_normalized()
        {
            var result1 = Polarization.FortyFiveDegreesStateVector.Abs();
            var result2 = Polarization.MinusFortyFiveDegreesStateVector.Abs();

            result1.Should().Be(new Complex(1, 0));
            result2.Should().Be(new Complex(1, 0));
        }
        
    }
}