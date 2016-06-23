using System;
using System.Numerics;
using Xunit;
using FluentAssertions;

namespace CSharp6Samples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int x = 10;
            Console.WriteLine($"Hello World! {x}");

            var cplx = new Complex(1, 2);
            Console.WriteLine($"Img: {cplx.Imaginary} Re: {cplx.Real} Phase: {cplx.Magnitude}");
            Console.WriteLine(cplx);         
        }
    }

    public class Class1
    {
        [Fact]
        public void PassingTest()
        {
            5.Should().Be(2 + 2);;
        }
    }
}
