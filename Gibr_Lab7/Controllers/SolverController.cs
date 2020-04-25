using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accord.Math.Optimization;
using Gibr_Lab7.Solver;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
            LinearConstraint linear = null;
            if (data.extra != null)
            {
                linear = new LinearConstraint(numberOfVariables: 2)
                {
                    VariablesAtIndices = new int[] { 0, 1 },
                    CombinedAs = data.extra,
                    ShouldBe = ConstraintType.EqualTo,
                    Value = 0
                };
            }
            Calculator calculator = new Calculator();
            double[] res = calculator.Solving(data.count, data.Ii, data.w, data.d, data.b, data.A, linear);
            return res;
        }
    }
}
