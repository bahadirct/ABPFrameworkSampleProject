using FTS.MovieStream.Movies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTS.MovieStream.EntityFrameworkCore.Movies
{
    public static class EfCoreMovieQueryableExtensions
    {
        public static IQueryable<Movie> IncludeDetails(this IQueryable<Movie> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                .Include(x => x.Information);
        }
    }
}
