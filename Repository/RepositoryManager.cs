using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;

        private IGenreRepository _genreRepository;
        private IArtistRepository _artistRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IGenreRepository Genre
        {
            get
            {
                if (_genreRepository == null)
                    _genreRepository = new GenreRepository(_repositoryContext);

                return _genreRepository;
            }
        }

        public IArtistRepository Artist
        {
            get
            {
                if (_artistRepository == null)
                    _artistRepository = new ArtistRepository(_repositoryContext);

                return _artistRepository;
            }
        }

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}