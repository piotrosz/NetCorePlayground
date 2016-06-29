using System;
using static System.Math;

namespace Quantum
{
    public class Apparatus
    {
        private int rotation;

        public SpinAverageValue Measure(Spin spin)
        {
            double rotationInRadians = (PI / 180) * rotation;
            
            if(spin.SpinState == SpinState.Down)
            {
                rotationInRadians += PI;   
            }
            
            double average = Cos(rotationInRadians);
            return new SpinAverageValue(average);
        }

        public void Rotate(int degrees) 
         => rotation = (rotation + degrees) % 360;
    }
}