using System.Numerics;
using static System.Math;

namespace Quantum
{
    public static class SpinBaseStates
    {
        public static readonly Matrix Up = new Matrix(new Complex[,]
        {
            {1},
            {0}
        });

        public static readonly Matrix Down = new Matrix(new Complex[,]
        {
            {0},
            {1}
        });

        public static readonly Matrix Right = new Matrix(new Complex[,]
        {
            {1/Sqrt(2)},
            {1/Sqrt(2)}
        });
        
        public static readonly Matrix Left = new Matrix(new Complex[,]
        {
            {1/Sqrt(2)},
            {-1/Sqrt(2)}
        });

        public static readonly Matrix In = new Matrix(new Complex[,]
        {
            {1/Sqrt(2)},
            {new Complex(0, 1/Sqrt(2))}
        });

        public static readonly Matrix Out = new Matrix(new Complex[,]
        {
            {1/Sqrt(2)},
            {new Complex(0, -1/Sqrt(2))}
        });
    }
}