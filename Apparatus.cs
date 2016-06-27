using System;

namespace Quantum
{
    public class Apparatus
    {
        private int rotation;

        public SpinAverageValue Measure(Spin spin)
        {
            double radians = (Math.PI / 180) * rotation;
            double average = Math.Cos(Convert.ToDouble(radians));
            return new SpinAverageValue(average);
        }

        public void Rotate(int degrees)
        {
            rotation = (rotation + degrees) % 360;
        }
    }
}