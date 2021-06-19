using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities;
using Entities.Models.Concerts;

namespace Repository
{
    public class GenreRepository : RepositoryBase<Genre>, IGenreRepository
    {
        public GenreRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Genre> GetAllGenres(bool trackChanges)
        {
            return FindAll(trackChanges)
                .OrderBy(g => g.GenreName)
                .ToList();
        }

        public Genre GetGenre(Guid genreId, bool trackChanges)
        {
            return FindByCondition(g => g.Id.Equals(genreId), trackChanges)
                .SingleOrDefault();
        }
    }
}