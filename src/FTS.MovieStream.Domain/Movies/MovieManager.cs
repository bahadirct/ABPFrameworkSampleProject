using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace FTS.MovieStream.Movies
{
    public class MovieManager : DomainService
    {
        protected IMovieRepository MovieRepository { get; }
        protected IMovieCastMemberRepository MovieCastMemberRepository { get; }

        public MovieManager(IMovieRepository movieRepository, IMovieCastMemberRepository movieCastMemberRepository)
        {
            MovieRepository = movieRepository;
            MovieCastMemberRepository = movieCastMemberRepository;
        }

        public async Task<Movie> CreateMovieAsync(string title, string description, string director, DateTime publishDate, MovieType type, List<(Guid movieId, string Name, string Surname)> castMembers)
        {
            Movie movie = new Movie(

                id: GuidGenerator.Create(),
                title: title,
                information: new Information(description: description, director: director, publishDate: publishDate),
                type: type
                );

            foreach (var castMember in castMembers)
            {
                movie.AddCastMember(
                    id: GuidGenerator.Create(),
                    castMember.movieId,
                    castMember.Name,
                    castMember.Surname
                    );

            }

            var PlacedMovie = await MovieRepository.InsertAsync(movie, true);

            return PlacedMovie;
        }

        public async Task<Movie> GetMovieAsync(Guid id)
        {
            var movie = await MovieRepository.GetAsync(id);
            var CastMembers = await MovieCastMemberRepository.GetCastMembersByMovieAsync(movie.Id);
            movie.CastMembers = CastMembers;
            return movie;
        }

        public async Task<List<Movie>> GetMoviesAsync()
        {
            var Movies = await MovieRepository.GetListAsync();
            foreach (var movie in Movies)
            {
                var CastMembers = await MovieCastMemberRepository.GetCastMembersByMovieAsync(movie.Id);
                movie.CastMembers = CastMembers;
            }
            return Movies;
        }

        public async Task<List<Movie>> GetMoviesByTypeAsync(MovieType type)
        {
            var movies = await MovieRepository.GetMoviesByTypeAsync(type);
            foreach (var movie in movies)
            {
                var CastMembers = await MovieCastMemberRepository.GetCastMembersByMovieAsync(movie.Id);
                movie.CastMembers = CastMembers;
            }
            return movies;
        }

        public async Task<Movie> GetMovieByTitleAsync(string title)
        {
            var movie = await MovieRepository.GetMovieByTitleAsync(title);
            var CastMembers = await MovieCastMemberRepository.GetCastMembersByMovieAsync(movie.Id);
            movie.CastMembers = CastMembers;
            return movie;
        }
    }
}
