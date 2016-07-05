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
            var result = Polarization.HorizVertOperator * Polarization.HorizontalStateVector;
            (result == Polarization.HorizontalStateVector).Should().BeTrue();
            //Console.WriteLine(result);
        }

        [Fact]
        public void polarization_operator_acting_on_vertical_state_gives_minus_vertical_state()
        {
            var result = Polarization.HorizVertOperator * Polarization.VerticalStateVector;
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

            Math.Abs(result1.Real - 1).Should().BeLessThan(0.00001);
            Math.Abs(result2.Real - 1).Should().BeLessThan(0.00001);
            Math.Abs(result1.Imaginary).Should().BeLessThan(0.00001);
            Math.Abs(result2.Imaginary).Should().BeLessThan(0.00001);
        }

        [Fact]
        public void when_foton_goes_through_45_polarizer_and_then_through_horizontal_polarizer_then_probability_its_horizontally_polarized_is_half()
        {
            var result = Polarization.FortyFiveDegreesStateVector.ScalarProduct(Polarization.HorizontalStateVector);
            result *= result;

            Math.Abs(result.Imaginary).Should().BeLessThan(0.0001);
            Math.Abs(result.Real - 0.5).Should().BeLessThan(0.0001);
        }
        
        [Fact]
        public void slash_operator_acting_on_45_state_gives_45_state()
        {
            var result = Polarization.SlashOperator * Polarization.FortyFiveDegreesStateVector;

            (result == Polarization.FortyFiveDegreesStateVector).Should().BeTrue();
        }

        [Fact]
        public void slash_operator_acting_on_minus_45_state_gives_minus_minus_45_state()
        {
            var result = Polarization.SlashOperator * Polarization.MinusFortyFiveDegreesStateVector;

            (result == -1 * Polarization.MinusFortyFiveDegreesStateVector).Should().BeTrue();
        }

        [Theory]
        [InlineData(40)]
        [InlineData(5)]
        public void foton_polarized_by_theta_and_then_by_horiz_then_prob_is_cos_theta(double theta)
        {
            var result = Polarization.HorizontalStateVector.ScalarProduct(Polarization.ThetaState(theta));

            Math.Abs(result.Real - Math.Cos(theta)).Should().BeLessThan(0.00001);
            Math.Abs(result.Imaginary).Should().BeLessThan(0.00001);
        }

        [Theory]
        [InlineData(4, 2)]
        [InlineData(0.5, 0.1)]
        public void pass_through_two_polarizers(double alpha, double beta)
        {
            var alphaVector = Polarization.ThetaState(alpha);
            var betaVector = Polarization.ThetaState(beta);

            var result = alphaVector.ScalarProduct(betaVector);

            Math.Abs(Math.Cos(alpha - beta) - result.Real).Should().BeLessThan(0.00001);
            Math.Abs(result.Imaginary).Should().BeLessThan(0.00001); 
        }

        [Theory]
        [InlineData(0.4)]
        public void theta_operator_acting_on_theta_vector_gives_theta_vector(double theta)
        {
            var result = Polarization.ThetaOperator(theta) * Polarization.ThetaState(theta);
            (result == Polarization.ThetaState(theta)).Should().BeTrue();
        }

        [Theory]
        [InlineData(0.4)]
        public void theta_operator_acting_on_theta_orthogonal_vector_gives_minus_orthogonal_theta_vector(double theta)
        {
            var result = Polarization.ThetaOperator(theta) * Polarization.ThetaOrthogonalState(theta);
            (result == -1 * Polarization.ThetaOrthogonalState(theta)).Should().BeTrue();
        }
        
        [Theory]
        [InlineData(0.3)]
        public void theta_operator_is_hermitian(double theta)
        {
            Polarization.ThetaOperator(theta).IsHermitian().Should().BeTrue();
        }
    }
}