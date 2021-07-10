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


        public static IQueryable<Concert> Sort(this IQueryable<Concert> concerts, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return concerts.OrderBy(c => c.ConcertName);
            
            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Concert>(orderByQueryString);
            
            if (string.IsNullOrWhiteSpace(orderQuery))
                return concerts.OrderBy(c => c.ConcertName);
        
            return concerts.OrderBy(orderQuery);
        }
    }
}