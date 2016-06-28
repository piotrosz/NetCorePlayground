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
            var M = new Matrix(2, 2);
            M[0, 0] = Complex.Zero;
            M[0, 1] = Complex.One;
            M[1, 0] = new Complex(real: -1, imaginary: 0);
            M[1, 1] = Complex.Zero;

            //Console.WriteLine($"M: {Environment.NewLine}{M}{Environment.NewLine}");
             
            var v = new Matrix(1, 2);
            v[0, 0] = Complex.One;
            v[0, 1] = Complex.ImaginaryOne;

            //Console.WriteLine($"v: {Environment.NewLine}{v}{Environment.NewLine}");

            var result = Matrix.NaiveMultiplication(v, M);
            //Console.WriteLine($"result: {Environment.NewLine}{result}{Environment.NewLine}");

            var expected = Matrix.MultiplyByNumber(v, new Complex(real: 0, imaginary: -1));
            //Console.WriteLine($"expected: {Environment.NewLine}{expected}{Environment.NewLine}");
            
            result[0, 0].Should().Be(expected[0, 0]);
            result[0, 1].Should().Be(expected[0, 1]);
        }
    }
}