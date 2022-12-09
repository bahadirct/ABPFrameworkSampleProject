using AutoMapper;
using FTS.MovieStream.Movies;
using Volo.Abp.AutoMapper;

namespace FTS.MovieStream;

public class MovieStreamApplicationAutoMapperProfile : Profile
{
    public MovieStreamApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Movie, MovieDto>();
        CreateMap<CreateUpdateMovieDto, Movie>();
        CreateMap<Information, InformationDto>();
        CreateMap<CastMember, CastMemberDto>();
        CreateMap<CastMemberAddDto, CastMember>();
      
    }
}
