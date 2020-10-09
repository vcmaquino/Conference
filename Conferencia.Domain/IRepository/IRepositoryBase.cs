using Conferencia.domain.Entity;
using System;
using System.Threading.Tasks;

namespace Conferencia.domain.IRepository
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(Guid id);
        Task<T> SaveAsync(T entity);
    }
}
