using Core.DbModels;
using Core.Spesifications;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetEntityWithSpec(ISpesification<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpesification<T> spec);
    }
}
