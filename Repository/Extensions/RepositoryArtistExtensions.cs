using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;
using Entities.Models.Concerts;
using Repository.Extensions.Utils;

namespace Repository.Extensions
{
    public static class RepositoryArtistExtensions
    {
        public static IQueryable<Artist> Search(this IQueryable<Artist> artists, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return artists;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return artists.Where(a => a.ArtistName.ToLower().Contains(lowerCaseTerm));
        }


        public static IQueryable<Artist> Sort(this IQueryable<Artist> artists, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return artists.OrderBy(a => a.ArtistName);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Artist>(orderByQueryString);
            
            if (string.IsNullOrWhiteSpace(orderQuery))
                return artists.OrderBy(a => a.ArtistName);

            return artists.OrderBy(orderQuery);
        }
    }
}