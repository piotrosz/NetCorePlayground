using FluentAssertions;
using Xunit;
using System.Numerics;
using static System.Console;

namespace Quantum
{
    public class SingletStateTests
    {
        //[Fact]
        public void singlet_state()
        {
            WriteLine(SingletState.GetMatrix());
        }

        [Fact]
        public void avarage_of_sigma_z_is_zero()
        {
            // <sigma_z> = <sing|sigma_z|sing>
            SingletState.GetMatrix()
                .Sandwich(
                    Tensor.Product(PauliMatrices.sigma_z, Matrix.GetIdentityMatrix(2, 2)))
            .Should().Be(Complex.Zero);
        }

        [Fact]
        public void avarage_of_sigma_x_is_zero()
        {
            // <sigma_x> = <sing|sigma_x|sing>
            SingletState.GetMatrix()
                .Sandwich(
                    Tensor.Product(PauliMatrices.sigma_x, Matrix.GetIdentityMatrix(2, 2)))
            .Should().Be(Complex.Zero);
        }

        [Fact]
        public void avarage_of_sigma_y_is_zero()
        {
            // <sigma_y> = <sing|sigma_y|sing>
            SingletState.GetMatrix()
                .Sandwich(
                    Tensor.Product(PauliMatrices.sigma_y, Matrix.GetIdentityMatrix(2, 2)))
            .Should().Be(Complex.Zero);
        }

        // |sing> is a eigen vector of observable tau_z*sigma_z having eigen value -1.
        // Alice and Bob always have opposite results of measurement: -1, 1 or 1, -1.
        // * - tensor product
        [Fact]
        public void tau_z_sigma_z_acting_on_singlet_gives_minus_singlet()
        {
            var result = Tensor.Product(PauliMatrices.sigma_z, PauliMatrices.sigma_z) * SingletState.GetMatrix();

            (result == -1 * SingletState.GetMatrix()).Should().BeTrue();
        }
    }
}