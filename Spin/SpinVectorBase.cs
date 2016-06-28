using System.Numerics;
using static System.Math;

namespace Quantum
{
    public static class SpinVectorBase
    {
        public static readonly SpinVector Left = new SpinVector(
            upComponent: 1/Sqrt(2),
            downComponent: 1/Sqrt(2));

        public static readonly SpinVector Right = new SpinVector(
            upComponent: 1/Sqrt(2),
            downComponent: -1/Sqrt(2));

        public static readonly SpinVector In = new SpinVector(
            upComponent: 1/Sqrt(2),
            downComponent: new Complex(real: 0, imaginary: 1/Sqrt(2)));

        public static readonly SpinVector Out = new SpinVector(
            upComponent: 1/Sqrt(2),
            downComponent: new Complex(real: 0, imaginary: -1/Sqrt(2)));

        public static readonly SpinVector Up = new SpinVector(
            upComponent: Complex.One, 
            downComponent: Complex.Zero);

        public static readonly SpinVector Down = new SpinVector(
            upComponent: Complex.Zero,
            downComponent: Complex.One);
        
    }
}