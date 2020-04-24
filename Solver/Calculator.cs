using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accord.Math.Optimization;

namespace Gibr_Lab7.Solver
{
    public class Calculator
    {
        public double[] Solving(double[] Ii, double[] w, double[] d, double[] b, double[][] A)
        {
            double[,] I = new double[7, 7];
            double[,] W = new double[7, 7];
            for (int i = 0; i < w.Length; i++)
            {
                for (int j = 0; j < w.Length; j++)
                {
                    if (j == i)
                    {
                        W[i, j] = 1 / (w[i] * w[i]);
                        I[i, j] = Ii[i];
                    }
                    else
                    {
                        W[i, j] = 0;
                        I[i, j] = 0;
                    }
                }
            }
            double[,] Q = Accord.Math.Matrix.Dot(W, I);

            double[] D = new double[7];
            for (int i = 0; i < 7; i++)
            {
                D[i] = d[i] * Q[i, i];
            }

            List<double[]> combinedAs = new List<double[]>();
            for (int i = 0; i < A.Length; i++)
            {
                double[] a = new double[A[i].Length];
                for (int j = 0; j < A[i].Length; j++)
                {
                    a[j] = A[i][j];
                }
                combinedAs.Add(a);
            }

            Console.WriteLine(W[0, 0].ToString(), W[1, 1].ToString(), W[2, 2].ToString());
            int[] VariablesAtIndices = { 0, 1, 2, 3, 4, 5, 6 };
            List<LinearConstraint> constraints = new List<LinearConstraint>();
            for (int i = 0; i < 3; i++)
            {
                LinearConstraint linear = new LinearConstraint(numberOfVariables: 7)
                {
                    VariablesAtIndices = VariablesAtIndices,
                    CombinedAs = combinedAs[i],
                    ShouldBe = ConstraintType.EqualTo,
                    Value = b[i]
                };
                constraints.Add(linear);
            }

            var solver = new GoldfarbIdnani(
                function: new QuadraticObjectiveFunction(Q, D),
                constraints: constraints);

            bool success = solver.Minimize();
            double[] solution = solver.Solution;
            return solution;
        }
    }
}
