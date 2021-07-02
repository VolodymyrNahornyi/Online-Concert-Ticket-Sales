using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models.Concerts;
using Entities.RequestFeatures;

namespace Contracts
{
    public interface IConcertRepository
    {
        Task<PagedList<Concert>> GetConcertsAsync(Guid genreId, Guid artistId, ConcertParameters concertParameters, bool trackChanges);
    }
}