using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accord.Math.Optimization;

namespace Gibr_Lab7.Solver
{
    public class Calculator
    {
        public double[] Solving(int count, double[] Ii, double[] w, double[] d, double[] b, double[][] A)
        {
            double[,] I = new double[count, count];
            double[,] W = new double[count, count];
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

            double[] D = new double[count];
            int[] VariablesAtIndices = new int[count];
            for (int i = 0; i < count; i++)
            {
                D[i] = d[i] * Q[i, i];
                VariablesAtIndices[i] = i;
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

            List<LinearConstraint> constraints = new List<LinearConstraint>();
            for (int i = 0; i < 3; i++)
            {
                LinearConstraint linear = new LinearConstraint(numberOfVariables: count)
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
