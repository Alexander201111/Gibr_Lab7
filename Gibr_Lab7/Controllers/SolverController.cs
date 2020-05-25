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
        public Result Solve([FromBody]ForSolver data)
        {
            List<LinearConstraint> linear = new List<LinearConstraint>();
            if (data.limitations != null)
            {
                for (int i = 0; i < data.limitations.Length; i++)
                {
                    linear.Add(new LinearConstraint(numberOfVariables: 1)
                    {
                        VariablesAtIndices = new int[] { i },
                        ShouldBe = ConstraintType.GreaterThanOrEqualTo,
                        Value = data.limitations[i].min
                    });
                    linear.Add(new LinearConstraint(numberOfVariables: 1)
                    {
                        VariablesAtIndices = new int[] { i },
                        ShouldBe = ConstraintType.LesserThanOrEqualTo,
                        Value = data.limitations[i].max
                    });
                }
            }

            Calculator calculator = new Calculator();
            Result res = calculator.Solving(data.count, data.Ii, data.w, data.d, data.b, data.A, linear, data.extra);
            return res;
        }
    }
}
