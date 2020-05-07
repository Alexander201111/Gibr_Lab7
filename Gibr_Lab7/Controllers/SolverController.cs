using System.Collections.Generic;
using Accord.Math.Optimization;
using Gibr_Lab7.Solver;
using Microsoft.AspNetCore.Mvc;

namespace Gibr_Lab7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SolverController : ControllerBase
    {
        public SolverController() { }

        [HttpPost]
        public double[] Solve([FromBody]ForSolver data)
        {
            List<LinearConstraint> linear = new List<LinearConstraint>();
            if (data.limitations != null)
            {
                for (int i = 0; i < data.limitations.Length; i++)
                {
                    for (int j = 0; j < data.limitations[i].Length; j++)
                    {
                        ConstraintType shouldBe = j == 0 ? ConstraintType.GreaterThanOrEqualTo : ConstraintType.LesserThanOrEqualTo;
                        double Value = data.limitations[i][j];
                        linear.Add(new LinearConstraint(numberOfVariables: 1)
                        {
                            VariablesAtIndices = new int[] { i },
                            ShouldBe = shouldBe,
                            Value = Value
                        });
                    }
                }
            }

            Calculator calculator = new Calculator();
            double[] res = calculator.Solving(data.count, data.Ii, data.w, data.d, data.b, data.A, null, data.extra);
            return res;
        }
    }
}
