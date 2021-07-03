using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models.Concerts;
using Entities.RequestFeatures;

namespace Contracts
{
    public interface IConcertService
    {
        Task<PagedList<Concert>> GetConcertsAsync(Guid genreId, Guid artistId, ConcertParameters concertParameters, bool trackChanges);
        Task<Concert> GetConcertAsync(Guid genreId, Guid artistId, Guid id, bool trackChanges);
    }
}