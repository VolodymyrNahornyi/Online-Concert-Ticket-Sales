using Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IRepositoryManager _repositoryManager;


        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        private IGenreService _genreService;
        private IArtistService _artistService;

        public IGenreService Genre
        {
            get
            {
                if (_genreService == null)
                    _genreService = new GenreService(_repositoryManager);

                return _genreService;
            }
        }
        
        public IArtistService Artist
        {
            get
            {
                if (_artistService == null)
                    _artistService = new ArtistService(_repositoryManager);

                return _artistService;
            }
        }

        public void Save()
        {
            _repositoryManager.Save();
        }
    }
}