namespace Contracts
{
    public interface IServiceManager
    {
        IGenreService Genre { get; }
        IArtistService Artist { get; }
    }
}