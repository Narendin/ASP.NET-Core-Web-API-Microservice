using AutoMapper;
using MetricsManager.Interfaces;
using MetricsManager.DB;
using MetricsManager.Dto;

namespace MetricsManager
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
                    cfg.CreateMap<AgentInfo, AgentInfoDto>();
                    cfg.CreateMap<AgentInfoDto, AgentInfo>();
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