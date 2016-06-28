using FluentAssertions;
using Xunit;
using System.Numerics;

namespace Quantum
{
    public class PauliMatricesTests
    {
        [Fact]
        public void sigma_z()
        {
            var sigma_z = new Matrix(2, 2);
            sigma_z[0, 0] = 1;
            sigma_z[0, 1] = 0;
            sigma_z[1, 0] = 0;
            sigma_z[1, 1] = -1;

            var result = SpinVectorBase.Up.ToMatrix() * sigma_z;

            //result[0, 1].Should().Be();
        }        
    }
}