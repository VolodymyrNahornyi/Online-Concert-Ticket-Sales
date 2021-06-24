using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts;
using Entities.Models.Concerts;
using Entities.RequestFeatures;

namespace Services
{
    public class ArtistService : IArtistService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ArtistService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<PagedList<Artist>> GetArtistsAsync(Guid genreId, ArtistParameters artistParameters, bool trackChanges)
        {
            return await _repositoryManager.Artist.GetArtistsAsync(genreId, artistParameters, trackChanges);
        }

        public async Task<Artist> GetArtistAsync(Guid genreId, Guid id, bool trackChanges)
        {
            return await _repositoryManager.Artist.GetArtistAsync(genreId, id, trackChanges);
        }

        public void CreateArtist(Guid genreId, Artist artist)
        {
            _repositoryManager.Artist.CreateArtist(genreId, artist);
        }

        public void DeleteArtist(Artist artist)
        {
            _repositoryManager.Artist.DeleteArtist(artist);
        }
    }
}