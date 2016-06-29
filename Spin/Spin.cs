namespace Quantum
{
    public class Spin
    {
        public Spin(SpinState spinState)
        {
            SpinState = spinState;
        }

        public SpinState SpinState { get; private set;}
    }
}