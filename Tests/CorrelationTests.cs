using System;
using System.Numerics;
using FluentAssertions;
using Xunit;

namespace Quantum
{
    public class CorrelationTests
    {
        [Fact]
        public void perfect_negative_correlation()
        {
            var sigma_A = new double[100];
            var sigma_B = new double[100];
            var random = new Random();

            for (int i = 0; i < 100; i++)
            {
                int number = random.Next(0, 2);
                
                if(number == 0)
                {
                    sigma_A[i] = -1;
                    sigma_B[i] = 1;
                }
                else
                {
                    sigma_A[i] = 1;
                    sigma_B[i] = -1;
                }
            }

            var result = Correlation.Calculate(sigma_A, sigma_B);

            //Console.WriteLine(result);
            result.Should().BeApproximately(-1, 0.1);
        }

        [Fact]
        public void perfect_positive_correlation()
        {
            var sigma_A = new double[100];
            var random = new Random();

            for (int i = 0; i < 100; i++)
            {
                sigma_A[i] = random.Next(0, 2) == 0 ? 1 : -1;
            }

            var result = Correlation.Calculate(sigma_A, sigma_A);

            //Console.WriteLine(result);
            result.Should().BeApproximately(1, 0.1);
        }

        //[Fact]
        public void imperfect_correlation()
        {
            var sigma_A = new double[] { 1, 1,  1, -1 };
            var sigma_B = new double[] { 1, 1, -1, 1,};

            var result = Correlation.Calculate(sigma_A, sigma_A);

            Console.WriteLine(result);
        }
    }
}