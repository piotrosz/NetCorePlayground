namespace Quantum
{
    public static class SpinVectorExtensions
    {
        public static Matrix ToMatrix(this SpinVector spinVector)
        {
            var m = new Matrix(1, 2);
            m[0, 0] = spinVector.UpComponent;
            m[0, 1] = spinVector.DownComponent;
            return m;
        }
    }
}