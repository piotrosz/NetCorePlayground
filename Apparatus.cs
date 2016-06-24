namespace Quantum
{
    public class Apparatus
    {
        private int rotation;

        public SpinState Measure(Spin spin)
        {
            if(rotation == 0)
            {
                return spin.SpinState;
            }
            if(rotation == 180)
            {
                return spin.SpinState == SpinState.Up ?
                        SpinState.Down :
                        SpinState.Up;
            }  

            return spin.SpinState;     
        }

        public void Rotate(int degrees)
        {
            rotation = (rotation + degrees) % 360;
        }
    }
}