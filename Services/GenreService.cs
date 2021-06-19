using System.Collections.Generic;
using Contracts;
using Entities.Models.Concerts;

namespace Services
{
    public class GenreService : IGenreService
    {
        private readonly IRepositoryManager _repositoryManager;

        public GenreService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public IEnumerable<Genre> GetAllGenres(bool trackChanges)
        {
            return _repositoryManager.Genre.GetAllGenres(false);
        }
    }
}