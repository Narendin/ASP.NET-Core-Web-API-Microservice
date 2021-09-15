using MetricsAgent.DB;
using MetricsAgent.Interfaces;
using MetricsAgent.Repositories;
using MetricsManager.Entities.Metrics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Data.SQLite;

namespace MetricsAgent
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MetricsAgent", Version = "v1" });
            });
            services.AddScoped<IRepository<CpuMetric>, SqlLiteMetricRepository<CpuMetric>>();
            services.AddScoped<IRepository<DotNetMetric>, SqlLiteMetricRepository<DotNetMetric>>();
            services.AddScoped<IRepository<HddMetric>, SqlLiteMetricRepository<HddMetric>>();
            services.AddScoped<IRepository<NetworkMetric>, SqlLiteMetricRepository<NetworkMetric>>();
            services.AddScoped<IRepository<RamMetric>, SqlLiteMetricRepository<RamMetric>>();
            SQLiteConfigure.ConfigureSqlLiteConnection();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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