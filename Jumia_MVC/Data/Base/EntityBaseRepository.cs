using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Jumia_MVC.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly ApplicationDBContext _context;

        public EntityBaseRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<T> Add(T entity)
        {
             await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> delete(T entity)
        {
             _context.Set<T>().Remove(entity);
             _context.SaveChanges();
            return entity;
        }
        public async Task DeleteAsync(int id)
        {
            var data = await _context.Set<T>().FindAsync(id);

            EntityEntry entityEntry = _context.Entry<T>(data);
            entityEntry.State = EntityState.Deleted;
            await _context.SaveChangesAsync();

        }
        public async Task<IEnumerable<T>> GellAll()
        {
            var data=await _context.Set<T>().ToListAsync();
            return data;
        }

        public async Task<IEnumerable<T>> GellAll(params Expression<Func<T, object>>[] includeProperty)
        {
            IQueryable<T> quary = _context.Set<T>();
            quary = includeProperty.Aggregate(quary, (current, includeProperty) 
                                   => current.Include(includeProperty));

            return await quary.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
           var data=await _context.Set<T>().FindAsync(id);
            return data;
        }

        public async Task<T> update(T entity)
        {
             _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;

        }
        public async Task updateAsync(int id,T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State=EntityState.Modified;
            await _context.SaveChangesAsync();
        }

    }
}
