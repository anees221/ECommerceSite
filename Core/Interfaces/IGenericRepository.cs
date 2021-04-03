using System.Threading.Tasks;
using System.Collections.Generic;
using Core.Entitities;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T:BaseEntity
    {

        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();

        Task<T> GetEntitywithSpec(ISpecifications<T> spec);

        Task<IReadOnlyList<T>> ListAsync(ISpecifications<T> spec);
    }
}