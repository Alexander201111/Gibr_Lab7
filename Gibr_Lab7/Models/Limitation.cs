using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gibr_Lab7
{
    public class Limitation
    {
        public double min { get; set; }
        public double max { get; set; }

        public Limitation(double _min, double _max)
        {
            min = _min;
            max = _max;
        }
    }
}
