using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gibr_Lab7
{
    public class Result
    {
        public double[] solution { get; set; }
        public bool reduced { get; set; }

        public Result(double[] _solution, bool _reduced)
        {
            solution = _solution;
            reduced = _reduced;
        }
    }
}
