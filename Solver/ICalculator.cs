using Accord.Math.Optimization;

namespace Gibr_Lab7.Solver
{
    interface ICalculator
    {
        public double[] Solving(int count, double[] Ii, double[] w, double[] d, double[] b, double[][] A, LinearConstraint newConstraints = null);
    }
}
