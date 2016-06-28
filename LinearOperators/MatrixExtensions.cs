using System.Numerics;

namespace Quantum
{
    public static class MatrixExtensions
    {
        public static bool IsHermitian(this Matrix m)
        {
            bool result = true;
            for (int i = 0; i < m.Height; i++)
            {
                for (int j = 0; j < m.Width; j++)
                {
                    if(m[i, j] != Complex.Conjugate(m[j, i]))
                    {
                        return false;
                    }
                }
            }

            return result;
        }
    }
}