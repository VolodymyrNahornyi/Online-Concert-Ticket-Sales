using Contracts;

namespace Services
{
    public class ArtistService : IArtistService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ArtistService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
    }
}