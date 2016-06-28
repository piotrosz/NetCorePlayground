using FluentAssertions;
using Xunit;
using System.Numerics;
using static System.Console;

namespace Quantum
{
    public class PauliMatricesTests
    {
        private Matrix sigma_z;

        public PauliMatricesTests()
        {
            sigma_z = new Matrix(2, 2);
            sigma_z[0, 0] = 1;
            sigma_z[0, 1] = 0;
            sigma_z[1, 0] = 0;
            sigma_z[1, 1] = -1;
        }

        [Fact]
        public void sigma_z_multiplied_by_up()
        {
            var up = SpinVectorBase.Up.ToMatrix();
            //var result = sigma_z * up;
            WriteLine(up);
            //WriteLine(sigma_z);
            //WriteLine(result);

            //result[0, 0].Should().Be(up[0, 0]);
            //result[0, 1].Should().Be(up[0, 1]);


        }        

        [Fact]
        public void sigma_z_multiplied_by_down()
        {
            var down = SpinVectorBase.Down.ToMatrix();
            var result =  sigma_z * down;



            //result[0, 0].Should().Be(-down[0, 0]);
            //result[0, 1].Should().Be(-down[0, 1]);
        }
    }
}