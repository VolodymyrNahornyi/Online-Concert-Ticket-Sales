using System.Threading.Tasks;

namespace Contracts
{
    public interface IServiceManager
    {
        IGenreService Genre { get; }
        IArtistService Artist { get; }
        Task SaveAsync();
    }
}