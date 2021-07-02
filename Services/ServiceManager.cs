using System.Threading.Tasks;
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
        private IConcertService _concertService;

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
        
        public IConcertService Concert
        {
            get
            {
                if (_concertService == null)
                    _concertService = new ConcertService(_repositoryManager);

                return _concertService;
            }
        }

        public Task SaveAsync()
        {
            return _repositoryManager.SaveAsync();
        }
    }
}