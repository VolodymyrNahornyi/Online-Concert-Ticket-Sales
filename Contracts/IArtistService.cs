using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.DataTransferObjects;
using Entities.Models.Concerts;
using Entities.RequestFeatures;

namespace Contracts
{
    public interface IArtistService
    {
        Task<ArtistsPagedListCollection> GetArtistsAsync(Guid genreId, ArtistParameters artistParameters, bool trackChanges);
        Task<ArtistDto> GetArtistAsync(Guid genreId, Guid id, bool trackChanges);
        void CreateArtist(Guid genreId, Artist artist);
        void DeleteArtist(Artist artist);
    }
}