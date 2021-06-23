using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IGenreRepository Genre { get; }
        IArtistRepository Artist { get; }
        Task SaveAsync();
    }
}