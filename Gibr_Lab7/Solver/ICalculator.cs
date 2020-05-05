﻿using System.Collections.Generic;
using Accord.Math.Optimization;

namespace Gibr_Lab7.Solver
{
    interface ICalculator
    {
        public double[] Solving(int count, double[] Ii, double[] w, double[] d, double[] b, double[][] A, List<LinearConstraint> constraints, double[][] extra = null);
    }
}
