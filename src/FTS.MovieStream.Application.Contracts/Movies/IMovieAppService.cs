using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace FTS.MovieStream.Movies
{
    public interface IMovieAppService : IApplicationService
    {
        Task CreateAsync(CreateUpdateMovieDto input);
        Task<MovieDto> GetAsync(Guid id);
        Task<List<MovieDto>> GetByMoviesTypeAsync(MovieType type);
        Task<MovieDto> GetByMovieTitleAsync(string title);
        Task<List<MovieDto>> GetMoviesAsync();
        Task UpdateAsync(Guid id, CreateUpdateMovieDto input);
        Task DeleteAsync(Guid id);
    }
}
