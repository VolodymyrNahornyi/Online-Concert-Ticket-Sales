using System;
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
            return _repositoryManager.Genre.GetAllGenres(trackChanges);
        }

        public Genre GetGenre(Guid genreId, bool trackChanges)
        {
            return _repositoryManager.Genre.GetGenre(genreId, trackChanges);
        }

        public void CreateGenre(Genre genre)
        {
            _repositoryManager.Genre.CreateGenre(genre);
        }

        public IEnumerable<Genre> GetGenresByIds(IEnumerable<Guid> Ids, bool trackChanges)
        {
            return  _repositoryManager.Genre.GetGenresByIds(Ids, trackChanges);
        }
    }
}