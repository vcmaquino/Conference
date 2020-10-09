using Conferencia.domain.Entity;
using Conferencia.domain.IRepository;
using Conferencia.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Conferencia.Infra.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        private readonly ConferenceMercadoTechContext _context;

        public RepositoryBase(ConferenceMercadoTechContext context)
        {
            _context = context;
        }

        public async Task Add(T entity)
        {
            entity.CreateAt = DateTime.UtcNow;
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            try
            {
                var result = await _context.Set<T>().SingleOrDefaultAsync(p => p.Id.Equals(entity.Id));

                entity.UpdateAt = DateTime.UtcNow;
                entity.CreateAt = result.CreateAt;
                _context.Entry(entity).CurrentValues.SetValues(result);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task Delete(Guid id)
        {
            try
            {
                var result = await _context.Set<T>().SingleOrDefaultAsync(p => p.Id.Equals(id));

                _context.Entry(result).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<T> SaveAsync(T entity)
        {
            entity.CreateAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}