using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricsManager.Entities.Interfaces
{
    public interface IMetric
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public DateTime Time { get; set; }
    }
}