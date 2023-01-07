using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _context;
        public GenericRepository(StoreContext context)
        {
            _context = context;

        }

        public void Add(T entity)
        {
           _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
             _context.Set<T>().Remove(entity);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void Update(T entity)
        {
           _context.Set<T>().Attach(entity);
           _context.Entry(entity).State = EntityState.Modified;
        }
    }
}