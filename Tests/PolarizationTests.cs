using System;
using static System.Math;
using System.Numerics;
using FluentAssertions;
using Xunit;

namespace Quantum
{
    public class PolarizationTests
    {
        private const double Precision = 0.0001;

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
        public void horizontal_and_vertical_state_vectors_are_orthogonal()
        {
            var result =  Polarization.FortyFiveDegreesStateVector.ScalarProduct(Polarization.MinusFortyFiveDegreesStateVector);
            result.Real.Should().BeApproximately(0, Precision);
        }

        [Fact]
        public void horizontal_and_vertical_state_vectors_are_normalized()
        {
            var result1 = Polarization.FortyFiveDegreesStateVector.Abs();
            var result2 = Polarization.MinusFortyFiveDegreesStateVector.Abs();

            (result1 - 1).Should().BeLessThan(Precision);
            (result2 - 1).Should().BeLessThan(Precision);
        }

        [Fact]
        public void when_foton_goes_through_45_polarizer_and_then_through_horizontal_polarizer_then_probability_its_horizontally_polarized_is_half()
        {
            var result = Polarization.FortyFiveDegreesStateVector.ScalarProduct(Polarization.HorizontalStateVector);
            result *= result;

            (result.Imaginary).Should().BeLessThan(Precision);
            (result.Real - 0.5).Should().BeLessThan(Precision);
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

            (result.Real - Math.Cos(theta)).Should().BeLessThan(Precision);
            (result.Imaginary).Should().BeLessThan(Precision);
        }

        [Theory]
        [InlineData(4, 2)]
        [InlineData(0.5, 0.1)]
        public void when_foton_passe_through_two_polarizers_of_arbirtary_angle_then_probability_cos_square_alpha_minus_beta(double alpha, double beta)
        {
            var alphaVector = Polarization.ThetaState(alpha);
            var betaVector = Polarization.ThetaState(beta);

            var result = alphaVector.ScalarProduct(betaVector);

            (Math.Cos(alpha - beta) - result.Real).Should().BeLessThan(Precision);
            (result.Imaginary).Should().BeLessThan(Precision); 
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

        [Fact]
        public void mystery_states_are_normalized()
        {
            //Console.WriteLine(Polarization.SomeState.ScalarProduct(Polarization.SomeState));

            (Polarization.CircularPolarizationState.Abs()).Should().BeApproximately(1, Precision);
            (Polarization.CircularPolarizationOthogonalState.Abs()).Should().BeApproximately(1, Precision);
        }

        [Fact]
        public void mystery_states_are_orthogonal()
        {
            var scalarProduct = Polarization.CircularPolarizationState.ScalarProduct(Polarization.CircularPolarizationOthogonalState);
            //Console.WriteLine(scalarProduct);
            scalarProduct.Real.Should().BeApproximately(0, Precision);
            scalarProduct.Imaginary.Should().BeApproximately(0, Precision);
        }

        [Fact]
        public void mystery_operator_is_hermitian()
        {
            Polarization.CircularPolarizationOperator.IsHermitian().Should().BeTrue();
        }

        [Fact]
        public void mystery_operator_acting_on_mystery_state_gives_mystery_state()
        {
            var result = Polarization.CircularPolarizationOperator * Polarization.CircularPolarizationState;
            (result == Polarization.CircularPolarizationState).Should().BeTrue();
        }

        [Fact]
        public void mystery_operator_acting_on_mystery_orthogonal_state_gives_minus_orthogonal_mystery_state()
        {
            var result = Polarization.CircularPolarizationOperator * Polarization.CircularPolarizationOthogonalState;
            (result == -1 * Polarization.CircularPolarizationOthogonalState).Should().BeTrue();
        }

        [Theory]
        [InlineData(0.4)]
        [InlineData(-0.3)]
        [InlineData(2)]        
        public void circularly_polarized_foton_goes_through_theta_polarizer_with_half_probability(double theta)
        {
            var scalarProduct = Polarization.ThetaState(theta).ScalarProduct(Polarization.CircularPolarizationState);
            //Console.WriteLine(scalarProduct);
            (Complex.Abs(scalarProduct) * Complex.Abs(scalarProduct)).Should().BeApproximately(0.5, Precision);
        }
    }
}