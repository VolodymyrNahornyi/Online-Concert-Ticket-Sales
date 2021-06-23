using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models.Concerts;

namespace Contracts
{
    public interface IArtistService
    {
        Task<IEnumerable<Artist>> GetArtistsAsync(Guid genreId, bool trackChanges);
        Task<Artist> GetArtistAsync(Guid genreId, Guid id, bool trackChanges);
        void CreateArtist(Guid genreId, Artist artist);
        void DeleteArtist(Artist artist);
    }
}