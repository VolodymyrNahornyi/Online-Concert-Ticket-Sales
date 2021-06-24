using System.Linq;
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
    }
}