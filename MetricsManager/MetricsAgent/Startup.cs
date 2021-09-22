using MetricsAgent.DB;
using MetricsAgent.DB.Interfaces;
using MetricsAgent.DB.Repositories;
using MetricsAgent.Entities.Metrics;
using MetricsAgent.Interfaces;
using MetricsAgent.Services;
using MetricsAgent.Services.Jobs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

namespace MetricsAgent
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //контроллеры
            services.AddControllers();
            //Сваггер
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MetricsAgent", Version = "v1" });
            });
            //Маппер
            services.AddSingleton<IMetricMapper, MetricMapper>();
            //ДБконтекст
            services.AddDbContext<AppDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"))); ;
            //Репозитории
            services.AddScoped<IDbRepository<CpuMetric>, SqLiteMetricRepository<CpuMetric>>();
            services.AddScoped<IDbRepository<DotNetMetric>, SqLiteMetricRepository<DotNetMetric>>();
            services.AddScoped<IDbRepository<HddMetric>, SqLiteMetricRepository<HddMetric>>();
            services.AddScoped<IDbRepository<NetworkMetric>, SqLiteMetricRepository<NetworkMetric>>();
            services.AddScoped<IDbRepository<RamMetric>, SqLiteMetricRepository<RamMetric>>();
            // Джобы
            services.AddSingleton<IJobFactory, JobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            //Задачи
            services.AddSingleton<CpuMetricJob>();
            services.AddSingleton(new JobSchedule(jobType: typeof(CpuMetricJob), cronExpression: "0/5 * * * * ?"));
            services.AddSingleton<DotNetMetricJob>();
            services.AddSingleton(new JobSchedule(jobType: typeof(DotNetMetricJob), cronExpression: "0/5 * * * * ?"));
            services.AddSingleton<HddMetricJob>();
            services.AddSingleton(new JobSchedule(jobType: typeof(HddMetricJob), cronExpression: "0/5 * * * * ?"));
            services.AddSingleton<NetworkMetricJob>();
            services.AddSingleton(new JobSchedule(jobType: typeof(NetworkMetricJob), cronExpression: "0/5 * * * * ?"));
            services.AddSingleton<RamMetricJob>();
            services.AddSingleton(new JobSchedule(jobType: typeof(RamMetricJob), cronExpression: "0/5 * * * * ?"));

            services.AddHostedService<QuartzHostedService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MetricsAgent v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}