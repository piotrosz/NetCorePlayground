using System.Numerics;
using Xunit;
using FluentAssertions;
using System;

namespace Quantum
{
    public class SigmaTauOperatorTests
    {
        private static readonly Matrix SigmaTauOperator = 
        Tensor.Product(
            (PauliMatrices.sigma_x * PauliMatrices.sigma_x) +
            (PauliMatrices.sigma_y * PauliMatrices.sigma_y) +
            (PauliMatrices.sigma_z * PauliMatrices.sigma_z),

            Matrix.GetIdentityMatrix(2));

        [Fact]
        public void sigma_tau_acting_on_singlet_has_eigen_value()
        {
            // Console.WriteLine(SigmaTauOperator);
            // Console.WriteLine(SingletState.GetMatrix());
            // Console.WriteLine(SigmaTauOperator * SingletState.GetMatrix());
        }

        [Fact]
        public void sigma_tau_acting_on_triplet1_has_eigen_value()
        {
            Console.WriteLine(SigmaTauOperator);
            Console.WriteLine(TripletStates.T1());
            Console.WriteLine(SigmaTauOperator * TripletStates.T1());
        }
    }
}