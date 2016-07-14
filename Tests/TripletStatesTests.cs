using System;
using System.Numerics;
using FluentAssertions;
using Xunit;

namespace Quantum
{
    public class TripletStatesTests
    {
        [Fact]
        public void sigma_z_tau_z()
        {
            var result = Tensor.Product(PauliMatrices.sigma_z, PauliMatrices.sigma_z) * TripletStates.T1();

            Console.WriteLine(TripletStates.T1());

            Console.WriteLine(result);
        }

        [Fact]
        public void sigma_y_tau_y()
        {
            
        }

        [Fact]
        public void sigma_x_tau_x()
        {
            
        }
    }
}