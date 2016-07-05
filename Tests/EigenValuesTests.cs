using System.Numerics;
using Xunit;
using FluentAssertions;
using System;

namespace Quantum
{
    public class EigenValueTests
    {
        [Fact]
        public void i_is_eigen_value_of_M()
        {
            var M = new Matrix(new Complex[,] 
            {
                { Complex.Zero, Complex.One  },
                { -1,           Complex.Zero }
            });

            //Console.WriteLine($"M: {Environment.NewLine}{M}{Environment.NewLine}");
             
            var v = new Matrix(new Complex[,] 
            {
                { 1, Complex.ImaginaryOne }
            });

            //Console.WriteLine($"v: {Environment.NewLine}{v}{Environment.NewLine}");

            var result = Matrix.NaiveMultiplication(v, M);
            //Console.WriteLine($"result: {Environment.NewLine}{result}{Environment.NewLine}");

            var expected = Matrix.MultiplyByNumber(v, new Complex(real: 0, imaginary: -1));
            //Console.WriteLine($"expected: {Environment.NewLine}{expected}{Environment.NewLine}");
            
            (result == expected).Should().BeTrue();
        }
    }
}