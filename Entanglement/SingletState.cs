using static System.Math;

namespace Quantum
{
    public static class SingletState
    {
        // 1/Sqrt(2) (|ud> - |du>)
        public static Matrix GetMatrix() 
        {
            return 1/Sqrt(2) * ( Tensor.Product(SpinBaseStates.Up, SpinBaseStates.Down) - 
                                 Tensor.Product(SpinBaseStates.Down, SpinBaseStates.Up) );
        }
    }
}