using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities;
using Entities.Models.Concerts;

namespace Repository
{
    public class ArtistRepository : RepositoryBase<Artist>, IArtistRepository
    {
        public ArtistRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Artist> GetArtists(Guid genreId, bool trackChanges)
        {
            return FindByCondition(a => a.GenreId.Equals(genreId), trackChanges)
                .OrderBy(a => a.ArtistName);
        }

        public Artist GetArtist(Guid genreId, Guid id, bool trackChanges)
        {
            return FindByCondition(a => a.GenreId.Equals(genreId) && a.Id.Equals(id), trackChanges)
                .SingleOrDefault();
        }

        public void CreateArtist(Guid genreId, Artist artist)
        {
            artist.GenreId = genreId;
            Create(artist);
        }
    }
}