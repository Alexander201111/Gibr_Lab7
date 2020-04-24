using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gibr_Lab7.Solver
{
    interface ICalculator
    {
        double[] Solving(double[] Ii, double[] w, double[] d, double[] b, double[,] A);
    }
}
