using MetricsAgent.DB;
using MetricsAgent.DB.Interfaces;
using MetricsAgent.DB.Repositories;
using MetricsAgent.Entities.Metrics;
using MetricsAgent.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MetricsAgent", Version = "v1" });
            });

            services.AddSingleton<IMetricMapper, MetricMapper>();

            services.AddDbContext<AppDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IDbRepository<CpuMetric>, SqLiteMetricRepository<CpuMetric>>();
            services.AddScoped<IDbRepository<DotNetMetric>, SqLiteMetricRepository<DotNetMetric>>();
            services.AddScoped<IDbRepository<HddMetric>, SqLiteMetricRepository<HddMetric>>();
            services.AddScoped<IDbRepository<NetworkMetric>, SqLiteMetricRepository<NetworkMetric>>();
            services.AddScoped<IDbRepository<RamMetric>, SqLiteMetricRepository<RamMetric>>();
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