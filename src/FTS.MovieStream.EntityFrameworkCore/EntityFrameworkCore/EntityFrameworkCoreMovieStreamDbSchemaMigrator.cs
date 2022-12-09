using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FTS.MovieStream.Data;
using Volo.Abp.DependencyInjection;

namespace FTS.MovieStream.EntityFrameworkCore;

public class EntityFrameworkCoreMovieStreamDbSchemaMigrator
    : IMovieStreamDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreMovieStreamDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the MovieStreamDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<MovieStreamDbContext>()
            .Database
            .MigrateAsync();
    }
}
