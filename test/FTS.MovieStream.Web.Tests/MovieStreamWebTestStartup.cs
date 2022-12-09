using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace FTS.MovieStream;

public class MovieStreamWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<MovieStreamWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
