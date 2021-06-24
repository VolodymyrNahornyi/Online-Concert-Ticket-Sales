using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;
using Entities.Models.Concerts;

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
            
            var orderParams = orderByQueryString.Trim().Split(',');
            var propertyInfos = typeof(Artist).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;
                
                var propertyFromQueryName = param.Split(" ")[0];
                var objectProperty = propertyInfos.FirstOrDefault(pi => 
                    pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty == null)
                    continue;
                
                var direction = param.EndsWith(" desc") ? "descending" : "ascending";
                
                orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction}, ");
            }
            
            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

            if (string.IsNullOrWhiteSpace(orderQuery))
                return artists.OrderBy(a => a.ArtistName);

            return artists.OrderBy(orderQuery);
        }
    }
}