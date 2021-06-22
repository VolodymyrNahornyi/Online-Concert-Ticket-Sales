using System;
using System.Collections.Generic;
using Entities.Models.Concerts;

namespace Contracts
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetAllGenres(bool trackChanges);
        Genre GetGenre(Guid genreId, bool trackChanges);
        void CreateGenre(Genre genre);
        IEnumerable<Genre> GetGenresByIds(IEnumerable<Guid> Ids, bool trackChanges);
        void DeleteGenre(Genre genre);
    }
}