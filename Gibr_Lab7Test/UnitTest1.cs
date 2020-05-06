using Accord.Math.Optimization;
using Gibr_Lab7.Solver;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Gibr_Lab7Test
{
    public class Tests
    {
        [Test]
        public void Test_Original()
        {
            #region Init Params
            int count = 7;
            double[] Ii = { 1, 1, 1, 1, 1, 1, 1 };
            double[] w = { 0.2, 0.121, 0.683, 0.04, 0.102, 0.081, 0.02 };
            double[] d =
            {
                10.0054919341489,
                3.03265795024749,
                6.83122010827837,
                1.98478460320379,
                5.09293357450987,
                4.05721328676762,
                0.991215230484718
            };
            double[] b = { 0, 0, 0 };
            double[][] A =
            {
                new double[] { 1, -1, -1, 0, 0, 0, 0 },
                new double[] { 0, 0, 1, -1, -1, 0, 0 },
                new double[] { 0, 0, 0, 0, 1, -1, -1 }
            };
            #endregion

            Calculator calculator = new Calculator();
            double[] res = calculator.Solving(count, Ii, w, d, b, A);
            bool check = true;
            for (int i = 0; i < 3; i++)
            {
                double resultForCheck = 0;
                for(int j=0; j<count; j++) { resultForCheck += res[j] * A[i][j]; }
                if (Math.Round(resultForCheck) != 0) { check = false; break; }
            }

            Assert.AreEqual(true, check);
        }

        [Test]
        public void Test_V2()
        {
            #region Init Params
            int count = 8;
            double[] Ii = { 1, 1, 1, 1, 1, 1, 1, 1 };
            double[] w = { 0.2, 0.121, 0.683, 0.04, 0.102, 0.081, 0.02, 0.667 };
            double[] d =
            {
                10.0054919341489,
                3.03265795024749,
                6.83122010827837,
                1.98478460320379,
                5.09293357450987,
                4.05721328676762,
                0.991215230484718,
                6.66666666666666
            };
            double[] b = { 0, 0, 0 };
            double[][] A =
            {
                new double[] { 1, -1, -1, 0, 0, 0, 0, 0 },
                new double[] { 0, 0, 1, -1, -1, 0, 0, 0 },
                new double[] { 0, 0, 0, 0, 1, -1, -1, 1 }
            };
            #endregion

            Calculator calculator = new Calculator();
            double[] res = calculator.Solving(count, Ii, w, d, b, A);
            bool check = true;
            for (int i = 0; i < 3; i++)
            {
                double resultForCheck = 0;
                for (int j = 0; j < count; j++) { resultForCheck += res[j] * A[i][j]; }
                if (Math.Round(resultForCheck) != 0) { check = false; break; }
            }

            Assert.AreEqual(true, check);
        }

        [Test]
        public void Test_10P1EqualP2()
        {
            #region Init Params
            int count = 8;
            double[] Ii = { 1, 1, 1, 1, 1, 1, 1, 1 };
            double[] w = { 0.2, 0.121, 0.683, 0.04, 0.102, 0.081, 0.02, 0.667 };
            double[] d =
            {
                10.0054919341489,
                3.03265795024749,
                6.83122010827837,
                1.98478460320379,
                5.09293357450987,
                4.05721328676762,
                0.991215230484718,
                6.66666666666666
            };
            double[] b = { 0, 0, 0 };
            double[][] A =
            {
                new double[] { 1, -1, -1, 0, 0, 0, 0, 0 },
                new double[] { 0, 0, 1, -1, -1, 0, 0, 0 },
                new double[] { 0, 0, 0, 0, 1, -1, -1, 1 }
            };

            List<LinearConstraint> list = new List<LinearConstraint>();

            list.Add(new LinearConstraint(numberOfVariables: 2)
            {
                VariablesAtIndices = new int[] { 0, 1 },
                CombinedAs = new double[] { 1, -10},
                ShouldBe = ConstraintType.EqualTo,
                Value = 0
            });
            #endregion

            Calculator calculator = new Calculator();
            double[] res = calculator.Solving(count, Ii, w, d, b, A, list);
            bool check = true;
            for (int i = 0; i < 3; i++)
            {
                double resultForCheck = 0;
                for (int j = 0; j < count; j++) { resultForCheck += res[j] * A[i][j]; }
                if (Math.Round(resultForCheck) != 0) { check = false; break; }
            }

            Assert.AreEqual(true, check);
        }
    }
}