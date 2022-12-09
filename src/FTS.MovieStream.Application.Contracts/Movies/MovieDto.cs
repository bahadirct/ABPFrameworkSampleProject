using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace FTS.MovieStream.Movies
{
    public class MovieDto : EntityDto<Guid>
    {
        public string Title { get; set; }
        public MovieType Type { get; set; }
        public InformationDto Information { get; set; } = new();
        public List<CastMemberDto> CastMembers { get; set; } = new();

    }
}
