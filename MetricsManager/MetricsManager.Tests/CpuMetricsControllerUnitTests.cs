using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsManager.Tests
{
    public class CpuMetricsControllerUnitTests
    {
        private BaseMetricsController _controller;

        public CpuMetricsControllerUnitTests()
        {
            //   _controller = new BaseMetricsController();
        }

        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            var agentId = 1;
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);

            //        var result = _controller.GetMetricsFromAgent(agentId, fromTime, toTime);

            //       Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}