using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities;
using Entities.Models.Concerts;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ArtistRepository : RepositoryBase<Artist>, IArtistRepository
    {
        public ArtistRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Artist>> GetArtistsAsync(Guid genreId, ArtistParameters artistParameters, bool trackChanges)
        {
            return await FindByCondition(a => a.GenreId.Equals(genreId), trackChanges)
                .OrderBy(a => a.ArtistName)
                .Skip((artistParameters.PageNumber - 1) * artistParameters.PageSize)
                .Take(artistParameters.PageSize)
                .ToListAsync();
        }

        public async Task<Artist> GetArtistAsync(Guid genreId, Guid id, bool trackChanges)
        {
            return await FindByCondition(a => a.GenreId.Equals(genreId) && a.Id.Equals(id), trackChanges)
                .SingleOrDefaultAsync();
        }

        public void CreateArtist(Guid genreId, Artist artist)
        {
            artist.GenreId = genreId;
            Create(artist);
        }

        public void DeleteArtist(Artist artist)
        {
            Delete(artist);
        }
    }
}