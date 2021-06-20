using System;
using System.Collections.Generic;
using Entities.Models.Concerts;

namespace Contracts
{
    public interface IArtistRepository
    {
        IEnumerable<Artist> GetArtists(Guid genreId, bool trackChanges);
        Artist GetArtist(Guid genreId, Guid id, bool trackChanges);
        void CreateArtist(Guid genreId, Artist artist);
    }
}