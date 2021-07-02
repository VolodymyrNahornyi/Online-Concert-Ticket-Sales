using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts;
using Entities.Models.Concerts;
using Entities.RequestFeatures;

namespace Services
{
    public class ConcertService : IConcertService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ConcertService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<PagedList<Concert>> GetConcertsAsync(Guid genreId, Guid artistId, ConcertParameters concertParameters, bool trackChanges)
        {
            return await _repositoryManager.Concert.GetConcertsAsync(genreId, artistId, concertParameters, trackChanges);
        }
    }
}