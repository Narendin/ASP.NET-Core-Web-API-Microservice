using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsAgent.Tests
{
    public class NetworkMetricsControllerUnitTests
    {
        private NetworkMetricsController _controller;

        public NetworkMetricsControllerUnitTests()
        {
            _controller = new NetworkMetricsController();
        }

        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);

            var result = _controller.GetNetworkDataFromManager(fromTime, toTime);

            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}