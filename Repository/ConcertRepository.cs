using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities;
using Entities.Models.Concerts;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;

namespace Repository
{
    public class ConcertRepository : RepositoryBase<Concert>, IConcertRepository
    {
        public ConcertRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<PagedList<Concert>> GetConcertsAsync(Guid genreId, Guid artistId, ConcertParameters concertParameters, bool trackChanges)
        {
            var concerts = await FindByCondition(c => c.Artist.GenreId.Equals(genreId) 
                                                      && c.ArtistId.Equals(artistId), trackChanges)
                .ToListAsync();
            
            return PagedList<Concert>.ToPagedList(concerts, concertParameters.PageNumber, concertParameters.PageSize);
        }

        public async Task<Concert> GetConcertAsync(Guid genreId, Guid artistId, Guid id, bool trackChanges)
        {
            return await FindByCondition(c => c.Artist.GenreId.Equals(genreId)
                                              && c.ArtistId.Equals(artistId) && c.Id.Equals(id), trackChanges)
                .SingleOrDefaultAsync();
        }
    }
}