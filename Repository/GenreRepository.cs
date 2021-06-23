using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities;
using Entities.Models.Concerts;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class GenreRepository : RepositoryBase<Genre>, IGenreRepository
    {
        public GenreRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Genre>> GetAllGenresAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(g => g.GenreName)
                .ToListAsync();
        }

        public async Task<Genre> GetGenreAsync(Guid genreId, bool trackChanges)
        {
            return await FindByCondition(g => g.Id.Equals(genreId), trackChanges)
                .SingleOrDefaultAsync();
        }

        public void CreateGenre(Genre genre)
        {
            Create(genre);
        }

        public async Task<IEnumerable<Genre>> GetGenresByIdsAsync(IEnumerable<Guid> Ids, bool trackChanges)
        {
            return await FindByCondition(x => Ids.Contains(x.Id), trackChanges)
                .ToListAsync();
        }

        public void DeleteGenre(Genre genre)
        {
            Delete(genre);
        }
    }
}