using System.Threading.Tasks;

namespace FTS.MovieStream.Data;

public interface IMovieStreamDbSchemaMigrator
{
    Task MigrateAsync();
}
