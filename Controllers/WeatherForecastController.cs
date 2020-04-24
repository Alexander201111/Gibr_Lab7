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
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public double[] Post([FromBody]ForSolver data)
        {
            Calculator calculator = new Calculator();
            double[] res = calculator.Solving(data.Ii, data.w, data.d, data.b, data.A);
            return res;
        }

        public void Solve()
        {
            //double[] Ii = { 1, 1, 1, 1, 1, 1, 1 };
            //double[] w = { 0.2, 0.121, 0.683, 0.04, 0.102, 0.081, 0.02 };
            //double[] d =
            //{
            //    10.0054919341489,
            //    3.03265795024749,
            //    6.83122010827837,
            //    1.98478460320379,
            //    5.09293357450987,
            //    4.05721328676762,
            //    0.991215230484718
            //};
            //double[] b = { 0, 0, 0 };
            //double[][] A =
            //{
            //    { 1, -1, -1, 0, 0, 0, 0 },
            //    { 0, 0, 1, -1, -1, 0, 0 },
            //    { 0, 0, 0, 0, 1, -1, -1 },
            //};
            //Calculator calculator = new Calculator();
            //calculator.Solving(Ii, w, d, b, A);
        }
    }
}
