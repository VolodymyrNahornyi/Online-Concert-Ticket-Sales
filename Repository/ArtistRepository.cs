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
    }
}