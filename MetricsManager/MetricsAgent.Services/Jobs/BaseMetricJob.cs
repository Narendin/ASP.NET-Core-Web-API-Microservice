using MetricsAgent.DB.Interfaces;
using MetricsAgent.Entities.Metrics;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

//"Processor", "% Processor Time", "_Total"
//"Memory", "Available MBytes"

namespace MetricsAgent.Services.Jobs
{
    public abstract class BaseMetricJob<TMetric> : IJob
        where TMetric : BaseMetric, new()
    {
        private readonly PerformanceCounter _metricCounter;
        private IDbRepository<TMetric> _repository;
        private readonly IServiceProvider _serviceProvider;

        public BaseMetricJob(IServiceProvider serviceProvider, PerformanceCounter metricCounter)
        {
            _serviceProvider = serviceProvider;
            _metricCounter = metricCounter;
        }

        public Task Execute(IJobExecutionContext context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                _repository = scope.ServiceProvider.GetRequiredService<IDbRepository<TMetric>>();
                var metricParam = Convert.ToInt32(_metricCounter.NextValue());
                _repository.AddAsync(new TMetric { Time = DateTime.Now, Value = metricParam });
            }

            return Task.CompletedTask;
        }
    }
}