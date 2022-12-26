using Sanatorium.DAL.Entities;
using Sanatorium.DAL.Paging;
using System.Linq.Expressions;

namespace Sanatorium.DAL.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : EntityBase
    {
        Task AddAsync(TEntity entity, CancellationToken cancellationToken);

        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);

        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);

        Task<TEntity?> GetOneAsync(int id, CancellationToken cancellationToken);

        Task<PagedList<TEntity>> GetPageAsync(PageParameters parameters, CancellationToken cancellationToken);

        Task<PagedList<TEntity>> GetPageAsync(PageParameters parameters, Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

        Task<List<TEntity>> GetAllAsync();
    }

}
