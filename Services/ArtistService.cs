using System;
using System.Collections.Generic;
using Contracts;
using Entities.Models.Concerts;

namespace Services
{
    public class ArtistService : IArtistService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ArtistService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public IEnumerable<Artist> GetArtists(Guid genreId, bool trackChanges)
        {
            return _repositoryManager.Artist.GetArtists(genreId, trackChanges);
        }

        public Artist GetArtist(Guid genreId, Guid id, bool trackChanges)
        {
            return _repositoryManager.Artist.GetArtist(genreId, id, trackChanges);
        }
    }
}