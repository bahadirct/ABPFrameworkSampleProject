
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Specifications;

namespace FTS.MovieStream.Movies
{
    public interface IMovieRepository : IRepository<Movie, Guid>
    {
        Task<List<Movie>> GetMoviesByDirectorAsync(string director, bool includeDetails = true, CancellationToken cancellationToken = default);
        Task<List<Movie>> GetMoviesByTypeAsync(MovieType type, bool includeDetails = true, CancellationToken cancellationToken = default);
        Task<Movie> GetMovieByTitleAsync(string title, bool includeDetails = true, CancellationToken cancellationToken = default);
    }
}
