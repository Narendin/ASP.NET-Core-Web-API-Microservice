using AutoMapper;
using MetricsAgent.Dto;
using MetricsAgent.Entities.Metrics;
using MetricsAgent.Interfaces;

namespace MetricsAgent
{
    /// <summary>
    /// Базовый класс для маппера
    /// </summary>
    public class MetricMapper : IMetricMapper
    {
        /// <summary>
        /// ctor
        /// </summary>
        public MetricMapper()
        {
            var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CpuMetric, CpuMetricDto>();
                    cfg.CreateMap<CpuMetricDto, CpuMetric>();

                    cfg.CreateMap<DotNetMetric, DotNetMetricDto>();
                    cfg.CreateMap<DotNetMetricDto, DotNetMetric>();

                    cfg.CreateMap<HddMetric, HddMetricDto>();
                    cfg.CreateMap<HddMetricDto, HddMetric>();

                    cfg.CreateMap<NetworkMetric, NetworkMetricDto>();
                    cfg.CreateMap<NetworkMetricDto, NetworkMetric>();

                    cfg.CreateMap<RamMetric, RamMetricDto>();
                    cfg.CreateMap<RamMetricDto, RamMetric>();
                });
            Mapper = config.CreateMapper();
        }

        /// <inheritdoc/>
        public IConfigurationProvider ConfigurationProvider => Mapper.ConfigurationProvider;

        /// <summary>
        /// Объект маппера
        /// </summary>
        protected IMapper Mapper { get; set; }

        /// <inheritdoc/>
        public T Map<T>(object sourse)
        {
            return Mapper.Map<T>(sourse);
        }
    }
}