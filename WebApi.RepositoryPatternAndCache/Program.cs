
using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.Hosting;

using WebApi.RepositoryPatternAndCache;

Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<Startup>();
    }).Build().Run();
