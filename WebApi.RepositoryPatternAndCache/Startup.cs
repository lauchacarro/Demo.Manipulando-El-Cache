
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

using WebApi.RepositoryPatternAndCache.Caching;
using WebApi.RepositoryPatternAndCache.Options;
using WebApi.RepositoryPatternAndCache.Repositories;
using WebApi.RepositoryPatternAndCache.Validators;

namespace WebApi.RepositoryPatternAndCache
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
            services.AddOptions();

            services.AddHttpContextAccessor();


            services.Configure<MongoOptions>(
                Configuration.GetSection(typeof(MongoOptions).Name));

            services.AddSingleton<IMongoOptions>(sp =>
               sp.GetRequiredService<IOptions<MongoOptions>>().Value);

            services.AddMemoryCache();
            services.AddSingleton<ICachedRepository, CachedRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductValidator, ProductValidator>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi.RepositoryPatternAndCache", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi.RepositoryPatternAndCache v1"));
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
