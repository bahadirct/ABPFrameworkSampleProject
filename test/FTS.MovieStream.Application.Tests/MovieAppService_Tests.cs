using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FTS.MovieStream.Movies
{
    public class MovieAppService_Tests : MovieStreamApplicationTestBase
    {
        private readonly IMovieAppService _movieAppService;

        public MovieAppService_Tests()
        {
            _movieAppService = GetRequiredService<IMovieAppService>();
        }

        [Fact]
        public async void GetMoviesByTypeAsync()
        {
            var authorDto = await _movieAppService.GetByMovieTitleAsync("interstellar");

        }

        [Fact]
        public async void GetMoviesAsync()
        {
            var authorDto = await _movieAppService.GetMoviesAsync();

        }
    }
}
