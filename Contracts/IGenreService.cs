using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models.Concerts;

namespace Contracts
{
    public interface IGenreService
    {
        Task<IEnumerable<Genre>> GetAllGenresAsync(bool trackChanges);
        Task<Genre> GetGenreAsync(Guid genreId, bool trackChanges);
        void CreateGenre(Genre genre);
        Task<IEnumerable<Genre>> GetGenresByIdsAsync(IEnumerable<Guid> Ids, bool trackChanges);
        void DeleteGenre(Genre genre);
    }
}