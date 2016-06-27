using System.Numerics;
using static System.Math;

namespace Quantum
{
    public static class SpinVectorBase
    {
        public static readonly SpinVector Left = new SpinVector(
            upComponent: new Complex(real: 1/Sqrt(2), imaginary: 0),
            downComponent: new Complex(real: 1/Sqrt(2), imaginary: 0));

        public static readonly SpinVector Right = new SpinVector(
            upComponent: new Complex(real: 1/Sqrt(2), imaginary: 0),
            downComponent: new Complex(real: -1/Sqrt(2), imaginary: 0));

        public static readonly SpinVector In = new SpinVector(
            upComponent: new Complex(real: 1/Sqrt(2), imaginary: 0),
            downComponent: new Complex(real: 0, imaginary: 1/Sqrt(2)));

        public static readonly SpinVector Out = new SpinVector(
            upComponent: new Complex(real: 1/Sqrt(2), imaginary: 0),
            downComponent: new Complex(real: 0, imaginary: -1/Sqrt(2)));

        public static readonly SpinVector Up = new SpinVector(
            upComponent: new Complex(real: 1, imaginary: 0), 
            downComponent: Complex.Zero);

        public static readonly SpinVector Down = new SpinVector(
            upComponent: Complex.Zero,
            downComponent: new Complex(real: -1, imaginary: 0));
        
    }
}