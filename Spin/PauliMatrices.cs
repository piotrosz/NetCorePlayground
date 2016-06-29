using System;
using System.Numerics;

namespace Quantum 
{
    public static class PauliMatrices
    {
        public static readonly Matrix sigma_z = new Matrix(new Complex[,] 
                                                {
                                                    {1,  0},
                                                    {0, -1}
                                                });
        public static readonly Matrix sigma_x = new Matrix(new Complex[,]
                                                {
                                                    {0, 1},
                                                    {1, 0}
                                                });
        public static readonly Matrix sigma_y = new Matrix(new Complex[,]
                                                {
                                                    {0, -Complex.ImaginaryOne},
                                                    {Complex.ImaginaryOne, 0}
                                                });
    }
}