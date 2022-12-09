using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using static System.Net.Mime.MediaTypeNames;

namespace FTS.MovieStream.Movies
{
    public class Movie : AggregateRoot<Guid>
    {
        public string Title { get; private set; }
        public Information Information { get; set; }
        public MovieType Type { get; private set; }
        public List<CastMember> CastMembers { get; set; }

        private Movie() { }

        public Movie(Guid id, string title, Information information, MovieType type) : base(id)
        {
            Title = Check.NotNullOrWhiteSpace(title, nameof(Title), MovieConsts.MaxTitleLength);
            Type = type;
            Information = information;
            CastMembers = new List<CastMember>();
        }

        public CastMember AddCastMember(Guid id, Guid movieId, string name, string surname)
        {
            var castMember = new CastMember(id, movieId, name, surname);
            CastMembers.Add(castMember);

            return castMember;
        }

        public void SetTitle(string title)
        {
            Title = title;
        }
        public void SetType(MovieType type)
        {
            Type = type;
        }

        public void SetInformation(string description, string director, DateTime publishDate)
        {
            Information = new Information(description, director, publishDate);
        }
    }

}


