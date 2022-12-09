using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FTS.MovieStream.Movies
{
    public class CreateUpdateMovieDto
    {
        public string Title { get; set; }
        public MovieType Type { get; set; }
        public InformationDto Information { get; set; } = new();
        public List<CastMemberAddDto> CastMembers { get; set; } = new();
    }
}
