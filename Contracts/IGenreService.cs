using System.Collections.Generic;
using Entities.Models.Concerts;

namespace Contracts
{
    public interface IGenreService
    {
        IEnumerable<Genre> GetAllGenres(bool trackChanges);
    }
}