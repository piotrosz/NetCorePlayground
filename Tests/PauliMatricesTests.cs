using FluentAssertions;
using Xunit;
using System.Numerics;
using static System.Console;

namespace Quantum
{
    public class PauliMatricesTests
    {
        [Fact]
        public void sigma_z_acting_on_up_gives_up()
        {
            var up = SpinVectorBase.Up.ToMatrix();
            
            var result = PauliMatrices.sigma_z * up;
            //WriteLine(up);
            //WriteLine(sigma_z);
            //WriteLine(result);

            (result == up).Should().BeTrue();
        }        

        [Fact]
        public void sigma_z_acting_on_down_gives_minus_down()
        {
            var down = SpinVectorBase.Down.ToMatrix();
            var result =  PauliMatrices.sigma_z * down;
            (result == -1 * down).Should().BeTrue();
        }

        [Fact]
        public void sigma_x_acting_on_right_gives_right()
        {
            var right = SpinVectorBase.Right.ToMatrix();
            var result = PauliMatrices.sigma_x * right;
            (result == right).Should().BeTrue();
            // WriteLine(sigma_x);
            // WriteLine(right);
            // WriteLine(result);
        }

        [Fact]
        public void sigma_x_acting_on_left_gives_minus_left()
        {
            var left = SpinVectorBase.Left.ToMatrix();
            var result = PauliMatrices.sigma_x * left;
            (result == -1 * left).Should().BeTrue();
            //WriteLine(result);
        }

        [Fact]
        public void sigma_y_acting_on_in_gives_in()
        {
            var @in = SpinVectorBase.In.ToMatrix();
            var result = PauliMatrices.sigma_y * @in;
            (result == @in).Should().BeTrue();
        }

        
        [Fact]
        public void sigma_y_acting_on_out_gives_minus_out()
        {
            var @out = SpinVectorBase.Out.ToMatrix();
            var result = PauliMatrices.sigma_y * @out;
            (result == -1 * @out).Should().BeTrue();
        }
    }
}