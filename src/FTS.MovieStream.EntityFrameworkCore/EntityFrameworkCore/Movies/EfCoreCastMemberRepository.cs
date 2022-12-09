using FTS.MovieStream.Movies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace FTS.MovieStream.EntityFrameworkCore.Movies
{
    public class EfCoreCastMemberRepository : EfCoreRepository<MovieStreamDbContext, CastMember, Guid>, IMovieCastMemberRepository
    {
        public EfCoreCastMemberRepository(IDbContextProvider<MovieStreamDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        public async Task<List<CastMember>> GetCastMembersByMovieAsync(Guid movieId, bool includeDetails = true, CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
           .Where(m => m.MovieId == movieId)
           .ToListAsync(GetCancellationToken(cancellationToken));
        }
    }
}
