using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;
using Entities.Models.Concerts;
using Repository.Extensions.Utils;

namespace Repository.Extensions
{
    public static class RepositoryConcertExtensions
    {
        
        public static IQueryable<Concert> FilterConcerts(this IQueryable<Concert> concerts, DateTime startDate, DateTime endDate) => 
            concerts.Where(c => (c.Date >= startDate && c.Date <= endDate));
        
        public static IQueryable<Concert> Search(this IQueryable<Concert> concerts, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return concerts;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return concerts.Where(c => c.ConcertName.ToLower().Contains(lowerCaseTerm));
        }


        // public static IQueryable<Artist> Sort(this IQueryable<Artist> artists, string orderByQueryString)
        // {
        //     if (string.IsNullOrWhiteSpace(orderByQueryString))
        //         return artists.OrderBy(a => a.ArtistName);
        //
        //     var orderQuery = OrderQueryBuilder.CreateOrderQuery<Artist>(orderByQueryString);
        //     
        //     if (string.IsNullOrWhiteSpace(orderQuery))
        //         return artists.OrderBy(a => a.ArtistName);
        //
        //     return artists.OrderBy(orderQuery);
        // }
    }
}