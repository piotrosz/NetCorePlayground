namespace Quantum
{
    public static class Comutator
    {
        public static Matrix Calculate(Matrix m1, Matrix m2) => m1 * m2 - m2 * m1;
    }
}