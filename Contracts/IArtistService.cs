using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models.Concerts;
using Entities.RequestFeatures;

namespace Contracts
{
    public interface IArtistService
    {
        Task<PagedList<Artist>> GetArtistsAsync(Guid genreId, ArtistParameters artistParameters, bool trackChanges);
        Task<Artist> GetArtistAsync(Guid genreId, Guid id, bool trackChanges);
        void CreateArtist(Guid genreId, Artist artist);
        void DeleteArtist(Artist artist);
    }
}