using System.Threading.Tasks;

namespace Contracts
{
    public interface IServiceManager
    {
        IGenreService Genre { get; }
        IArtistService Artist { get; }
        IConcertService Concert { get; }
        Task SaveAsync();
    }
}