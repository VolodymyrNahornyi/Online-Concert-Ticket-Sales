namespace Contracts
{
    public interface IRepositoryManager
    {
        IGenreRepository Genre { get; }
        IArtistRepository Artist { get; }
        void Save();
    }
}