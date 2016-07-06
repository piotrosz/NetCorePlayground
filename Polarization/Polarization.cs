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

        public static readonly Matrix HorizVertOperator = new Matrix(new Complex[,]
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

        public static readonly Matrix SlashOperator = new Matrix(new Complex[,]
        {
            {0, 1},
            {1, 0}
        });

        public static Matrix ThetaState(double theta) => new Matrix(new Complex[,]
        {
            {Cos(theta)},
            {Sin(theta)}
        });

        public static Matrix ThetaOrthogonalState(double theta) => new Matrix(new Complex[,] 
        {
            {-Sin(theta)},
            {Cos(theta)}
        });

        public static Matrix ThetaOperator(double theta) => new Matrix(new Complex[,]
        {
            {Cos(2*theta), Sin(2*theta)},
            {Sin(2*theta), -Cos(2*theta)}
        });

        public static readonly Matrix CircularPolarizationState = new Matrix(new Complex[,] 
        {
            {1/Sqrt(2)}, 
            {new Complex(0, 1/Sqrt(2))},
        });

        public static readonly Matrix CircularPolarizationOthogonalState = new Matrix(new Complex[,]
        {
            {1/Sqrt(2)}, 
            {new Complex(0, -1/Sqrt(2))}
        });

        // TODO: ?
        public static readonly Matrix MysteryOperator = new Matrix(new Complex[,]
        {
            {new Complex(0, 0), new Complex(0, 0)},
            {new Complex(0, 0), new Complex(0, 0)}
        });
    }
}