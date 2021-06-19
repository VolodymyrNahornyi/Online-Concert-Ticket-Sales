using System.Collections.Generic;
using Entities.Models.Concerts;

namespace Contracts
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetAllGenres(bool trackChanges);
    }
}