using System;
using System.Numerics;
using Xunit;
using FluentAssertions;
using static System.Numerics.Complex;
using static System.Console;

namespace CSharp6Samples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WriteLine("Enter real part:");
            double x = 0;
            double.TryParse(ReadLine(), out x);
            
            WriteLine("Enter imaginary part: ");
            double y = 0;
            double.TryParse(ReadLine(), out y);

            var complex = new Complex(x, y);

            WriteLine($"Your number is {complex}");
            WriteLine($"Abs: {Abs(complex)}");    
            WriteLine($"Negate: {Negate(complex)}");
            WriteLine($"Conjugate: {Conjugate(complex)}");
            WriteLine($"Acos: {Acos(complex)}");
            WriteLine($"Asin: {Asin(complex)}");
            WriteLine($"Atan: {Atan(complex)}");
            
            // var v2 = new Vector<double>(new double[] { 3, 4 });
            // var v1 = new Vector<Complex>(new[] { new Complex(2, 3), new Complex(4, 5) });
            // WriteLine($"Your vector is: {v2}");
        }
    }

    public class Class1
    {
        [Fact]
        public void FailingTest()
        {
            5.Should().Be(2 + 2);
        }

        [Fact]
        public void PassingTest()
        {
            4.Should().Be(2 + 2);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(6)]
        public void MyFirstTheory(int value)
        {
            (value % 2).Should().Be(1);
        }
    }
}