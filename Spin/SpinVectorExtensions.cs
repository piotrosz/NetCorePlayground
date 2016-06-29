using System.Numerics;

namespace Quantum
{
    public static class SpinVectorExtensions
    {
        public static Matrix ToMatrix(this SpinVector spinVector)
        {
            return new Matrix(new Complex[,] {
                {spinVector.UpComponent},
                {spinVector.DownComponent}
            });
        }
    }
}