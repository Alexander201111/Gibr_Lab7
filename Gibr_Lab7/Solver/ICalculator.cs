using System.Collections.Generic;
using Accord.Math.Optimization;

namespace Gibr_Lab7.Solver
{
    interface ICalculator
    {
        public Result Solving(int count, double[] Ii, double[] w, double[] d, double[] b, double[][] A, List<LinearConstraint> constraints = null, double[][] extra = null);
    }
}
