using FTS.MovieStream.Localization;
using FTS.MovieStream.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Specifications;

namespace FTS.MovieStream.Movies
{

    public class MovieAppService : ApplicationService, IMovieAppService
    {

        protected IMovieRepository MovieRepository { get; }
        protected MovieManager MovieManager { get; }

        public MovieAppService(MovieManager movieManager, IMovieRepository movieRepository)
        {
            MovieManager = movieManager;
            MovieRepository = movieRepository;
        }

        #region Ana Metotlar
        public async Task CreateAsync(CreateUpdateMovieDto input)
        {
            var castMembers = GetMovieListTuple(input.CastMembers);
            var placedMovie = await MovieManager.CreateMovieAsync(
                title: input.Title,
                type: input.Type,
                description: input.Information.Description,
                director: input.Information.Director,
                publishDate: input.Information.PublishDate,
                castMembers: castMembers
                );
        }
        public async Task<MovieDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Movie, MovieDto>(await MovieManager.GetMovieAsync(id));
        }
        public async Task<MovieDto> GetByMovieTitleAsync(string title)
        {
            var a = await MovieRepository.GetMovieByTitleAsync(title);
            return ObjectMapper.Map<Movie, MovieDto>(await MovieManager.GetMovieByTitleAsync(title));
        }
        public async Task<List<MovieDto>> GetByMoviesTypeAsync(MovieType type)
        {
            return ObjectMapper.Map<List<Movie>, List<MovieDto>>(await MovieManager.GetMoviesByTypeAsync(type));
        }
        public async Task<List<MovieDto>> GetMoviesAsync()
        {
            return ObjectMapper.Map<List<Movie>, List<MovieDto>>(await MovieManager.GetMoviesAsync());
        }
        public async Task UpdateAsync(Guid id, CreateUpdateMovieDto input)
        {
            var movie = await MovieRepository.GetAsync(id);

            movie.SetTitle(input.Title);
            movie.SetType(input.Type);
            movie.SetInformation(input.Information.Description, input.Information.Director, input.Information.PublishDate);
            await MovieRepository.UpdateAsync(movie);
        }
        public async Task DeleteAsync(Guid id)
        {
            await MovieRepository.DeleteAsync(id);
        }
        #endregion

        #region Yardımcı Metotlar
        private List<(Guid movieId, string name, string surname)> GetMovieListTuple(List<CastMemberAddDto> members)
        {
            var castMambers = new List<(Guid productId, string name, string surname)>();

            foreach (var member in members)
            {
                castMambers.Add((member.MovieId, member.Name, member.Surname));
            }

            return castMambers;
        }

        #endregion
    }
}
