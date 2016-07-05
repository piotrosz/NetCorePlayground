using System.Numerics;
using static System.Math;

namespace Quantum
{
    public static class Polarization
    {
        public static readonly Matrix HorizontalStateVector = new Matrix(new Complex[,] 
        {
            {1},
            {0}
        });

        public static readonly Matrix VerticalStateVector = new Matrix(new Complex[,]
        {
            {0},
            {1}
        });

        public static readonly Matrix PolatizationOperator = new Matrix(new Complex[,]
        {
            {1, 0},
            {0, -1}
        });

        public static readonly Matrix FortyFiveDegreesStateVector = new Matrix(new Complex[,]
        {
            {1/Sqrt(2)},
            {1/Sqrt(2)}
        });

        public static readonly Matrix MinusFortyFiveDegreesStateVector = new Matrix(new Complex[,]
        {
            {1/Sqrt(2)},
            {-1/Sqrt(2)}
        });
    }
}