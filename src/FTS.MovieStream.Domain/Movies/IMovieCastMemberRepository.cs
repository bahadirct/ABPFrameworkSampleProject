using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace FTS.MovieStream.Movies
{
    public interface IMovieCastMemberRepository : IRepository<CastMember, Guid>
    {
        Task<List<CastMember>> GetCastMembersByMovieAsync(Guid movieId, bool includeDetails = true, CancellationToken cancellationToken = default);
    }
}
