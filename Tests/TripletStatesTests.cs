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

            Console.WriteLine(result);
        }

        [Fact]
        public void given_t1_state_sigma_z_tau_z()
        {
            var result = Tensor.Product(PauliMatrices.sigma_z, PauliMatrices.sigma_z) * TripletStates.T1();
            //Console.WriteLine(result);
        }

        [Fact]
        public void given_t1_state_sigma_y_tau_y()
        {
            var result = Tensor.Product(PauliMatrices.sigma_y, PauliMatrices.sigma_y) * TripletStates.T1();
            //Console.WriteLine(result);
        }

        [Fact]
        public void given_t1_state_sigma_x_tau_x()
        {
            var result = Tensor.Product(PauliMatrices.sigma_x, PauliMatrices.sigma_x) * TripletStates.T1();
            //Console.WriteLine(result);
        }
    }
}