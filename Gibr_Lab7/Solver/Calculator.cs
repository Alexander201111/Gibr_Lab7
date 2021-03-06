﻿using System.Collections.Generic;
using Accord.Math.Optimization;
using Gibr_Lab7.Models;

namespace Gibr_Lab7.Solver
{
    public class Calculator : ICalculator
    {
        public Result SolverNotArrays(int countNodes, Flow[] flows)
        {
            int count = flows.Length;
            double[] Ii = new double[count];
            double[] w = new double[count];
            double[] d = new double[count];
            double[][] a = new double[count][];
            for (int i=0; i<count; i++)
            {
                Ii[i] = 1;
                w[i] = flows[i].w;
                d[i] = flows[i].D;
                a[i] = new double[countNodes];
                for(int j=0; j<countNodes; j++)
                {
                    if(flows[i].source == j+1)
                    {
                        a[i][j] = -1;
                    }
                    if (flows[i].dest == j+1)
                    {
                        a[i][j] = 1;
                    }
                }
            }

            double[][] A = new double[countNodes][];
            for (int i = 0; i < countNodes; i++)
            {
                A[i] = new double[count];
                for (int j = 0; j < count; j++)
                {
                    A[i][j] = a[j][i];
                }
            }

            double[] b = new double[countNodes];
            for (int i = 0; i < countNodes; i++)
            {
                b[i] = 0.0;
            }


            return Solving(count, Ii, w, d, b, A);
        }

        public Result Solving(int count, double[] Ii, double[] w, double[] d, double[] b, double[][] A, List<LinearConstraint> constraints = null, double[][] extra = null)
        {
            #region Calculate matrix
            double[,] I = new double[count, count];
            double[,] W = new double[count, count];
            for (int i = 0; i < w.Length; i++)
            {
                for (int j = 0; j < w.Length; j++)
                {
                    if (j == i)
                    {
                        W[i, j] = w[i] != 0 ? ( 1 / (w[i] * w[i])) : 0;
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
                D[i] = -1 * d[i] * Q[i, i];
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
            #endregion

            #region Forming conditions
            if (constraints == null)
            {
                constraints = new List<LinearConstraint>();
            }

            if (extra != null)
            {
                for (int i = 0; i < extra.Length; i++)
                {
                    constraints.Add(new LinearConstraint(numberOfVariables: count)
                    {
                        VariablesAtIndices = VariablesAtIndices,
                        CombinedAs = extra[i],
                        ShouldBe = ConstraintType.EqualTo,
                        Value = 0
                    });
                }
            }

            for (int i = 0; i < b.Length; i++)
            {
                constraints.Add(new LinearConstraint(numberOfVariables: count)
                {
                    VariablesAtIndices = VariablesAtIndices,
                    CombinedAs = combinedAs[i],
                    ShouldBe = ConstraintType.EqualTo,
                    Value = b[i]
                });
            }
            #endregion

            var solver = new GoldfarbIdnani(
                function: new QuadraticObjectiveFunction(Q, D),
                constraints: constraints);

            bool success = solver.Minimize();
            double[] solution = solver.Solution;
            Result result = new Result(solution, success);
            return result;
        }
    }
}
