using Microsoft.AspNetCore.Mvc;
using System;

namespace MetricsAgent
{
    public interface IMetricsController<TDto>
    {
        IActionResult GetByTimePeriod([FromRoute] DateTime fromTime, [FromRoute] DateTime toTime);

        IActionResult Create([FromBody] TDto request);

        IActionResult Update([FromRoute] DateTime time, [FromRoute] int lastValue, [FromRoute] int newValue);

        IActionResult Delete([FromRoute] DateTime time, [FromRoute] int value);
    }
}