using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            Calculator calculator = new Calculator();
            double[] res = calculator.Solving(data.count, data.Ii, data.w, data.d, data.b, data.A);
            return res;
        }
    }
}
