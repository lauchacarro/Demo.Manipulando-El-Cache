using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

using WebApi.CachePerEntity.Caching;
using WebApi.CachePerEntity.Options;
using WebApi.CachePerEntity.Repositories;
using WebApi.CachePerEntity.Validators;

namespace WebApi.CachePerEntity
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


            services.Configure<MongoOptions>(
                Configuration.GetSection(typeof(MongoOptions).Name));

            services.AddSingleton<IMongoOptions>(sp =>
               sp.GetRequiredService<IOptions<MongoOptions>>().Value);

            services.AddSingleton<IMemoryKeyCache, MemoryCache>();
            services.AddSingleton<ICachedRepository, CachedRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductValidator, ProductValidator>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi.CachePerEntity", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi.CachePerEntity v1"));
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
