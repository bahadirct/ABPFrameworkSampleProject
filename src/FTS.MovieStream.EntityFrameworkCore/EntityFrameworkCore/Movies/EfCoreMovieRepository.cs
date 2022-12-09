using FTS.MovieStream.Movies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Specifications;
using static Volo.Abp.Identity.Settings.IdentitySettingNames;

namespace FTS.MovieStream.EntityFrameworkCore.Movies
{
    public class EfCoreMovieRepository : EfCoreRepository<MovieStreamDbContext, Movie, Guid>, IMovieRepository
    {
        public EfCoreMovieRepository(IDbContextProvider<MovieStreamDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<Movie>> GetMoviesByDirectorAsync(string director, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
           .Where(m => m.Information.Director == director)
           .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<Movie> GetMovieByTitleAsync(string title, bool includeDetails = true, CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
            .IncludeDetails(true)
            .Where(m => m.Title == title)
            .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<Movie>> GetMoviesByTypeAsync(MovieType type, bool includeDetails = true, CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
           .IncludeDetails(true)
           .Where(m => m.Type == type)
           .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public override async Task<IQueryable<Movie>> WithDetailsAsync()
        {
            return (await GetQueryableAsync()).IncludeDetails(true);
        }

    }
}
