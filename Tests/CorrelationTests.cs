using System;
using System.Numerics;
using FluentAssertions;
using Xunit;

namespace Quantum
{
    public class CorrelationTests
    {
        [Fact]
        public void perfect_correlation()
        {
            var sigma_A = new double[] {  1, -1,  1,  1,  1, -1,  1, -1, -1,  1,  1,  1, -1 };
            var sigma_B = new double[] { -1,  1, -1, -1, -1,  1, -1,  1,  1, -1, -1, -1,  1 };

            var result = Correlation.Calculate(sigma_A, sigma_B);

            Console.WriteLine(result);
            (result + 1).Should().BeLessThan(0.1);
        }

         [Fact]
        public void perfect_correlation2()
        {
            var sigma_A = new double[] { 1, -1, 1, 1, 1, -1, 1, -1, -1 };

            var result = Correlation.Calculate(sigma_A, sigma_A);

            Console.WriteLine(result);
            //result.Should().Be(1);
        }

        [Fact]
        public void imperfect_correlation()
        {
            var sigma_A = new double[] {  1,  1,  1, 1, -1, 1,  -1, -1,  1,  -1,  1,  1,  1 };
            var sigma_B = new double[] {  1,  1, -1, 1,  1, 1,  -1,  1,  1,  -1, -1,  1, -1 };

            var result = Correlation.Calculate(sigma_A, sigma_A);

            Console.WriteLine(result);
        }
    }
}