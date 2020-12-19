
using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.Hosting;

using WebApi.CachePerRequest;

Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<Startup>();
    }).Build().Run();
