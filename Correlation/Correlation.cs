using System;
using System.Linq;
using static System.Console;

namespace Quantum 
{
    public static class Correlation
    {
        public static double Calculate(double[] sigma_A_set, double[] sigma_B_set)
        {
            if(sigma_A_set.Length != sigma_B_set.Length)
            {
                throw new Exception("Lengths must be equal");
            }

            double sigma_A_avg = sigma_A_set.Sum() / sigma_A_set.Length;
            double sigma_B_avg = sigma_B_set.Sum() / sigma_B_set.Length;

            //WriteLine($"sigma_A_avg: {sigma_A_avg}");
            //WriteLine($"sigma_B_avg: {sigma_A_avg}");

            double sigma_A_sigma_B_avg = 0;
            for (int i = 0; i < sigma_A_set.Length; i++)
            {
                sigma_A_sigma_B_avg += sigma_A_set[i] * sigma_B_set[i];
            }

            sigma_A_sigma_B_avg = sigma_A_sigma_B_avg / sigma_A_set.Length;

            //WriteLine($"sigma_A_sigma_B_avg: {sigma_A_sigma_B_avg}");

            return sigma_A_sigma_B_avg - (sigma_A_avg * sigma_B_avg);
        }    
    }    
}