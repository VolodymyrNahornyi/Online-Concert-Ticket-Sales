using System;
using System.Collections.Generic;
using Entities.Models.Concerts;

namespace Contracts
{
    public interface IGenreService
    {
        IEnumerable<Genre> GetAllGenres(bool trackChanges);
        Genre GetGenre(Guid genreId, bool trackChanges);
        void CreateGenre(Genre genre);
    }
}