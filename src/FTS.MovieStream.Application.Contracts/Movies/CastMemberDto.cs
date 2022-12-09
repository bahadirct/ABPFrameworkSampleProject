using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace FTS.MovieStream.Movies
{
    public class CastMemberDto : EntityDto<Guid>
    {
        public Guid MovieId { get;  set; }
        public string Name { get;  set; }
        public string Surname { get;  set; }
    }
}