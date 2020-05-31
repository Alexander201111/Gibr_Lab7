using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gibr_Lab7.Models
{
    public class Flow
    {
        public int Id { get; set; }
        public double D { get; set; }
        public double w { get; set; }
        public double source { get; set; }
        public double dest { get; set; }
        public Limitation limitation { get; set; }
    }
}
