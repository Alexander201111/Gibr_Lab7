using System.Collections.Generic;
using Accord.Math.Optimization;
using Gibr_Lab7.Models;

namespace Gibr_Lab7.Solver
{
    interface ICalculator
    {
        public Result SolverNotArrays(int countNodes, Flow[] flows);
        public Result Solving(int count, double[] Ii, double[] w, double[] d, double[] b, double[][] A, List<LinearConstraint> constraints = null, double[][] extra = null);
    }
}
