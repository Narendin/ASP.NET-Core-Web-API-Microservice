using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent
{
    public interface IMetricsController
    {
        IActionResult GetByTimePeriod([FromRoute] DateTime fromTime, [FromRoute] DateTime toTime);

        IActionResult Create([FromRoute] DateTime time, [FromRoute] int value);

        IActionResult Update([FromRoute] DateTime time, [FromRoute] int lastValue, [FromRoute] int newValue);

        IActionResult Delete([FromRoute] DateTime time, [FromRoute] int value);
    }
}