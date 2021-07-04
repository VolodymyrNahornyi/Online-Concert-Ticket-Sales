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

        public async Task<Concert> GetConcertAsync(Guid genreId, Guid artistId, Guid id, bool trackChanges)
        {
            return await _repositoryManager.Concert.GetConcertAsync(genreId, artistId, id, trackChanges);
        }

        public void CreateConcert(Guid artistId, Concert concert)
        {
            _repositoryManager.Concert.CreateConcert(artistId, concert);
        }

        public void DeleteConcert(Concert concert)
        {
            _repositoryManager.Concert.DeleteConcert(concert);
        }
    }
}