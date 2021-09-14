using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsAgent.Tests
{
    public class RamMetricsControllerUnitTests
    {
        private RamMetricsController _controller;

        public RamMetricsControllerUnitTests()
        {
            //        _controller = new RamMetricsController();
        }

        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);

            //         var result = _controller.GetAvailableRamFromManager(fromTime, toTime);

            //         Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}