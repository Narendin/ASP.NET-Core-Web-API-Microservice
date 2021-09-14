using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsAgent.Tests
{
    public class DotNetMetricsControllerUnitTests
    {
        private DotNetMetricsController _controller;

        public DotNetMetricsControllerUnitTests()
        {
            //      _controller = new DotNetMetricsController();
        }

        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);

            //        var result = _controller.GetErrorsCountFromManager(fromTime, toTime);

            //        Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}