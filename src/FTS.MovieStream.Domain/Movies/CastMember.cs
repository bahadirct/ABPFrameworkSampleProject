using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace FTS.MovieStream.Movies
{
    public class CastMember : Entity<Guid>
    {
        public Guid MovieId { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }

        protected CastMember() { }

        public CastMember(Guid id, Guid movieId, [NotNull] string name, [NotNull] string surname) : base(id)
        {
            MovieId = movieId;
            Name = Check.NotNullOrWhiteSpace(name, nameof(Name), CastMemberConsts.MaxNameLength);
            Surname = Check.NotNullOrWhiteSpace(surname, nameof(Surname), CastMemberConsts.MaxSurnameLength);
        }

    }
}
