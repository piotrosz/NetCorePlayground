namespace Quantum
{
    public class Comutator
    {
        public Matrix Calculate(Matrix m1, Matrix m2)
        {
            return m1 * m2 - m2 * m1;
        }
    }
}