using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<Genre>> GetAllGenresAsync(bool trackChanges)
        {
            return await _repositoryManager.Genre.GetAllGenresAsync(trackChanges);
        }

        public async Task<Genre> GetGenreAsync(Guid genreId, bool trackChanges)
        {
            return await _repositoryManager.Genre.GetGenreAsync(genreId, trackChanges);
        }

        public void CreateGenre(Genre genre)
        {
            _repositoryManager.Genre.CreateGenre(genre);
        }

        public async Task<IEnumerable<Genre>> GetGenresByIdsAsync(IEnumerable<Guid> Ids, bool trackChanges)
        {
            return await _repositoryManager.Genre.GetGenresByIdsAsync(Ids, trackChanges);
        }

        public void DeleteGenre(Genre genre)
        {
            _repositoryManager.Genre.DeleteGenre(genre);
        }
    }
}