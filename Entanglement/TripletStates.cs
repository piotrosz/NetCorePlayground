using static System.Math;

namespace Quantum
{
    public static class TripletStates
    {
        public static Matrix T1()
        {
            return 1/Sqrt(2) * ( Tensor.Product(SpinBaseStates.Up, SpinBaseStates.Down) + 
                                 Tensor.Product(SpinBaseStates.Down, SpinBaseStates.Up) ); 
        }
        public static Matrix T2() 
        {
            return 1/Sqrt(2) * ( Tensor.Product(SpinBaseStates.Down, SpinBaseStates.Down) + 
                                 Tensor.Product(SpinBaseStates.Up, SpinBaseStates.Up) );     
        }

        public static Matrix T3() 
        {
            return 1/Sqrt(2) * ( Tensor.Product(SpinBaseStates.Down, SpinBaseStates.Down) - 
                                 Tensor.Product(SpinBaseStates.Up, SpinBaseStates.Up) ); 
        }
    }
}