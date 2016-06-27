using System;
using System.Numerics;
using static System.Numerics.Complex;
using static System.Console;

namespace Quantum
{
    public class SpinVector
    {
        public SpinVector(Complex upComponent, Complex downComponent)
        {
            this.UpComponent = upComponent;
            this.DownComponent = downComponent;
        }

        public Complex UpComponent { get; private set; }
        public Complex DownComponent { get; private set; }

        public static Complex ScalarProduct(SpinVector vector1, SpinVector vector2)
        {
            //WriteLine(vector1);
            //WriteLine(vector2);
            //WriteLine($"{Conjugate(vector1.UpComponent)} * {vector2.UpComponent} + {Conjugate(vector2.DownComponent)} * {vector2.DownComponent}");

            return (Conjugate(vector1.UpComponent) * vector2.UpComponent + 
                   Conjugate(vector1.DownComponent) * vector2.DownComponent);
        }

        public override string ToString()
        {
            return $"[Up: {UpComponent}, Down: {DownComponent}]";
        }
    }
}