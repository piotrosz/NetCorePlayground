using System;
using System.Numerics;
using FluentAssertions;
using Xunit;

namespace Quantum
{
    public class TripletStatesTests
    {
        [Fact]
        public void given_t1_state_then_avarage_of_sigma_z_()
        {
            var result = TripletStates.T1()
                .Sandwich(
                    Tensor.Product(PauliMatrices.sigma_z, Matrix.GetIdentityMatrix(2)));

            result.Should().Be(Complex.Zero);
        }

        // T1
        [Fact]
        public void given_t1_state_sigma_z_tau_z()
        {
            var result = Tensor.Product(PauliMatrices.sigma_z, PauliMatrices.sigma_z) * TripletStates.T1();
            //Console.WriteLine(result);

            (result == -1 * TripletStates.T1()).Should().BeTrue();
        }

        [Fact]
        public void given_t1_state_sigma_y_tau_y()
        {
            var result = Tensor.Product(PauliMatrices.sigma_y, PauliMatrices.sigma_y) * TripletStates.T1();
            (result == TripletStates.T1()).Should().BeTrue();
            //Console.WriteLine(result);
        }

        [Fact]
        public void given_t1_state_sigma_x_tau_x()
        {
            var result = Tensor.Product(PauliMatrices.sigma_x, PauliMatrices.sigma_x) * TripletStates.T1();
            (result == TripletStates.T1()).Should().BeTrue();
            //Console.WriteLine(result);
        }

        // T2
        [Fact]
        public void given_t2_state_sigma_z_tau_z()
        {
            var result = Tensor.Product(PauliMatrices.sigma_z, PauliMatrices.sigma_z) * TripletStates.T2();
            //Console.WriteLine(result);
            //Console.WriteLine(TripletStates.T2());
            (result == TripletStates.T2()).Should().BeTrue();
        }

        [Fact]
        public void given_t2_state_sigma_y_tau_y()
        {
            var result = Tensor.Product(PauliMatrices.sigma_y, PauliMatrices.sigma_y) * TripletStates.T2();
            //Console.WriteLine(result);
            
            (result == -1 * TripletStates.T2()).Should().BeTrue();
        }

        [Fact]
        public void given_t2_state_sigma_x_tau_x()
        {
            var result = Tensor.Product(PauliMatrices.sigma_x, PauliMatrices.sigma_x) * TripletStates.T2();
            //Console.WriteLine(result);
            (result == TripletStates.T2()).Should().BeTrue();
        }

        // T3
        [Fact]
        public void given_t3_state_sigma_z_tau_z()
        {
            var result = Tensor.Product(PauliMatrices.sigma_z, PauliMatrices.sigma_z) * TripletStates.T3();
            (result == TripletStates.T3()).Should().BeTrue();
        }

        [Fact]
        public void given_t3_state_sigma_y_tau_y()
        {
            var result = Tensor.Product(PauliMatrices.sigma_y, PauliMatrices.sigma_y) * TripletStates.T3();
            (result == TripletStates.T3()).Should().BeTrue();
        }

        [Fact]
        public void given_t3_state_sigma_x_tau_x()
        {
            var result = Tensor.Product(PauliMatrices.sigma_x, PauliMatrices.sigma_x) * TripletStates.T3();
            (result == -1 * TripletStates.T3()).Should().BeTrue();
        }
    }
}