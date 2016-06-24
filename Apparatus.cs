namespace Quantum
{
    public class Apparatus
    {
        public SpinState Measure(Spin spin)
        {
            return spin.SpinState;
        }
    }
}