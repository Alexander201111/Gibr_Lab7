using Gibr_Lab7;
using Gibr_Lab7.Controllers;
using NUnit.Framework;

namespace Gibr_Lab7Test
{
    class ControllerTests
    {
        [Test]
        public void Test_Reduced()
        {
            double[] expectedSolution = new double[]
            {
                10.055562924869308,
                3.0143307158690513,
                7.041232209000256,
                1.9820614478522982,
                5.059170761147956,
                4.067338249014302,
                0.9918325121336546
            };
            Result expected = new Result(expectedSolution, true);
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

            ForSolver data = new ForSolver(count, Ii, w, d, b, A);
            #endregion

            SolverController controller = new SolverController();
            Result res = controller.Solve(data);

            Assert.AreEqual(expected.reduced, res.reduced);
            Assert.That(expected.solution, Is.EqualTo(res.solution).Within(0.1));
        }

        [Test]
        public void Test_SecondFlowEqual0()
        {
            double[] expectedSolution = new double[]
            {
                -3.6696413861578048,
                -1.9727827233177697,
                0,
                1.4377792703915215,
                1.5360313978980966,
                1.814149543904313,
                0.8544638972816511
            };
            Result expected = new Result(expectedSolution, true);
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
                new double[] { 1, 1, 1, 1, 1, 1, 1 },
                new double[] { 1, 1, -1, 1, 1, 1, 1 },
                new double[] { 1, 1, 1, 1, 1, 1, 1 }
            };

            ForSolver data = new ForSolver(count, Ii, w, d, b, A);
            #endregion

            SolverController controller = new SolverController();
            Result res = controller.Solve(data);

            Assert.AreEqual(expected.reduced, res.reduced);
            Assert.That(expected.solution, Is.EqualTo(res.solution).Within(0.1));
        }

        [Test]
        public void Test_NotReducedWithLimitations()
        {
            double[] expectedSolution = new double[]
            {
                1.0000000000000009,
                1,
                0.9999999999999994,
                1,
                0.9999999999999996,
                1,
                -6.000000000000001
            };
            Result expected = new Result(expectedSolution, false);
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
                new double[] { 1, 1, 1, 1, 1, 1, 1 },
                new double[] { 0, 0, 1, -1, -1, 0, 0 },
                new double[] { 0, 0, 0, 0, 1, -1, -1 }
            };

            Limitation[] limitations = new Limitation[]
            {
                new Limitation(1, 1),
                new Limitation(1, 1),
                new Limitation(1, 1),
                new Limitation(1, 1),
                new Limitation(1, 1),
                new Limitation(1, 1),
                new Limitation(1, 1),
            };

            ForSolver data = new ForSolver(count, Ii, w, d, b, A, null, limitations);
            #endregion

            SolverController controller = new SolverController();
            Result res = controller.Solve(data);

            Assert.AreEqual(expected.reduced, res.reduced);
            Assert.That(expected.solution, Is.EqualTo(res.solution).Within(0.1));
        }

        [Test]
        public void Test_ReducedExtra()
        {
            double[] expectedSolution = new double[]
            {
                8.24701040395792,
                0.8247010403957922,
                7.422309363562128,
                2.0877220059143995,
                5.334587357647728,
                4.326928579374164,
                1.007658778273564
            };
            Result expected = new Result(expectedSolution, true);
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

            double[][] extra = new double[][]
            {
                new double[] { 1, -10, 0, 0, 0, 0, 0 },
            };

            ForSolver data = new ForSolver(count, Ii, w, d, b, A, extra);
            #endregion

            SolverController controller = new SolverController();
            Result res = controller.Solve(data);

            Assert.AreEqual(expected.reduced, res.reduced);
            Assert.That(expected.solution, Is.EqualTo(res.solution).Within(0.1));
        }

        [Test]
        public void Test_ReducedExtraLimitations()
        {
            double[] expectedSolution = new double[]
            {
                20.00000000000001,
                2,
                18.000000000000014,
                5.020578731317562,
                12.979421268682454,
                11.532467336779543,
                1.4469539319029119
            };
            Result expected = new Result(expectedSolution, true);
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

            double[][] extra = new double[][]
            {
                new double[] { 1, -10, 0, 0, 0, 0, 0 },
            };

            Limitation[] limitations = new Limitation[]
            {
                new Limitation(1, 100),
                new Limitation(2, 100),
                new Limitation(3, 100),
                new Limitation(4, 100),
                new Limitation(-3, 100),
                new Limitation(-2, 100),
                new Limitation(-1, 100),
            };

            ForSolver data = new ForSolver(count, Ii, w, d, b, A, extra, limitations);
            #endregion

            SolverController controller = new SolverController();
            Result res = controller.Solve(data);

            Assert.AreEqual(expected.reduced, res.reduced);
            Assert.That(expected.solution, Is.EqualTo(res.solution).Within(0.1));
        }

        [Test]
        public void Test_Reduced2()
        {
            double[] expectedSolution = new double[]
            {
                0.19999999999999718,
                1.0000000000000002,
                1.1999999999999977,
                3,
                1.8000000000000027,
                0.9954492440018422,
                0.8045507559981595,
            };
            Result expected = new Result(expectedSolution, true);
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
                new double[] { 1, 1, -1, 0, 0, 0, 0 },
                new double[] { 0, 0, 1, -1, 1, 0, 0 },
                new double[] { 0, 0, 0, 0, 1, -1, -1 }
            };

            double[][] extra = new double[][]
            {
                new double[] { -5, 1, 0, 0, 0, 0, 0 },
            };

            Limitation[] limitations = new Limitation[]
            {
                new Limitation(0, 100),
                new Limitation(1, 1),
                new Limitation(0, 100),
                new Limitation(3, 3),
                new Limitation(0, 100),
                new Limitation(0, 100),
                new Limitation(0, 100),
            };

            ForSolver data = new ForSolver(count, Ii, w, d, b, A, extra, limitations);
            #endregion

            SolverController controller = new SolverController();
            Result res = controller.Solve(data);

            Assert.AreEqual(expected.reduced, res.reduced);
            Assert.That(expected.solution, Is.EqualTo(res.solution).Within(0.1));
        }

        [Test]
        public void Test_AllConstant()
        {
            double[] expectedSolution = new double[]
            {
                -0.7500000000000043,
                -3.750000000000006,
                3,
                1.98478460320379,
                5.09293357450987,
                4.05721328676762,
                7
            };
            Result expected = new Result(expectedSolution, false);
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

            double[][] extra = new double[][]
            {
                new double[] { -5, 1, 0, 0, 0, 0, 0 },
            };

            Limitation[] limitations = new Limitation[]
            {
                new Limitation(1, 1),
                new Limitation(2, 2),
                new Limitation(3, 3),
                new Limitation(4, 4),
                new Limitation(5, 5),
                new Limitation(6, 6),
                new Limitation(7, 7),
            };

            ForSolver data = new ForSolver(count, Ii, w, d, b, A, extra, limitations);
            #endregion

            SolverController controller = new SolverController();
            Result res = controller.Solve(data);

            Assert.AreEqual(expected.reduced, res.reduced);
            Assert.That(expected.solution, Is.EqualTo(res.solution).Within(0.1));
        }
    }
}
