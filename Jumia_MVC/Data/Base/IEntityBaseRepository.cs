using System.Linq.Expressions;

namespace Jumia_MVC.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class , IEntityBase, new()
    {
        Task<IEnumerable<T>> GellAll();
        Task<IEnumerable<T>> GellAll(params Expression<Func<T, object>>[] includeProperty  );
        Task<T> GetById(int id);
        Task<T> Add(T entity);

        Task<T> update(T entity);
        Task updateAsync(int id,T entity);

        Task<T> delete(T entity);
        Task DeleteAsync(int id);

    }
}
