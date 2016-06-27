using System;

namespace Quantum 
{
    public class SpinAverageValue
    {
        public SpinAverageValue(double value)
        {
            this.value = value;
        }

        private double value;

        public double Value 
        {
            get
            {
                return this.value;
            }
            set
            {
                if(value > 1 || value < -1)
                {
                    throw new ArgumentException("value");
                }
                this.value = value;
            }
        }
    }
}