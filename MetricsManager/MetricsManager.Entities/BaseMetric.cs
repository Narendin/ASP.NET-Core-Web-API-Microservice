using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricsManager.Entities
{
    public class BaseMetric
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public DateTime Time { get; set; }
    }
}