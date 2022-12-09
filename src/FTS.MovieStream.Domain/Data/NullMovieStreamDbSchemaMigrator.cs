using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace FTS.MovieStream.Data;

/* This is used if database provider does't define
 * IMovieStreamDbSchemaMigrator implementation.
 */
public class NullMovieStreamDbSchemaMigrator : IMovieStreamDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
