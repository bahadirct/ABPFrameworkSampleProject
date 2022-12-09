using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Values;

namespace FTS.MovieStream.Movies
{
    public class Information : ValueObject
    {
        public string Description { get; private set; }
        public string Director { get; private set; }
        public DateTime PublishDate { get; private set; }

        private Information() { }

        public Information(string description, string director, DateTime publishDate)
        {
            Description = Check.NotNullOrEmpty(description, nameof(description), maxLength: MovieConsts.MaxDescriptionLength);
            Director = Check.NotNullOrEmpty(director, nameof(director), maxLength: MovieConsts.MaxDirectorLength);
            PublishDate = publishDate;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Description;
            yield return Director;
            yield return PublishDate;
        }
    }
}
