using FTS.MovieStream.Movies;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace FTS.MovieStream
{
    internal class MovieStreamDataSeederContributor  /* IDataSeedContributor, ITransientDependency*/
    {
        protected IMovieRepository MovieRepository { get; }
        protected IMovieCastMemberRepository MovieCastMemberRepository { get; }
        protected IGuidGenerator GuidGenerator { get; }

        public MovieStreamDataSeederContributor(IMovieRepository movieRepository, IMovieCastMemberRepository movieCastMemberRepository, IGuidGenerator guidGenerator)
        {
            MovieRepository = movieRepository;
            MovieCastMemberRepository = movieCastMemberRepository;
            GuidGenerator = guidGenerator;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await MovieRepository.GetCountAsync() > 0)
            {
                return;
            }
            var id = GuidGenerator.Create();

            var Movie = new Movie(
                id: id,
                title: "Transformers : Kayıp Çağ",
                information: new Information("Teksas'ta kendi halinde bir tamirci olan Cade Yeager, eline geçen hasarli bir kamyoneti, parçalarini satma umuduyla kabul eder. Ne var ki bu kamyonetin yarali bir Optimus Prime'dan baskasi olmadigini anlamasi uzun sürmez.", "Micheal Bay", DateTime.Now),
                type: MovieType.Fantastic
                );

            await MovieRepository.InsertAsync(Movie);
            Movie.AddCastMember(GuidGenerator.Create(), id, "Bahadır", "Topçu");

        }
    }
}
