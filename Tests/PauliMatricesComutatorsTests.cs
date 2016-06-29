using System.Numerics;
using FluentAssertions;
using Xunit;

namespace Quantum
{
    public class PauliMatricesComutatorsTests
    {
        [Fact]
        public void sigma_x_sigma_y()
        {
            var result = Comutator.Calculate(PauliMatrices.sigma_x, PauliMatrices.sigma_y);
            (result == 2 * Complex.ImaginaryOne * PauliMatrices.sigma_z).Should().BeTrue();
        }

        [Fact]
        public void sigma_y_sigma_z()
        {
            var result = Comutator.Calculate(PauliMatrices.sigma_y, PauliMatrices.sigma_z);
            (result == 2 * Complex.ImaginaryOne * PauliMatrices.sigma_x).Should().BeTrue();
        }

        [Fact]
        public void sigma_z_sigma_x()
        {
            var result = Comutator.Calculate(PauliMatrices.sigma_z, PauliMatrices.sigma_x);
            (result == 2 * Complex.ImaginaryOne * PauliMatrices.sigma_y).Should().BeTrue();
        }
    }
}