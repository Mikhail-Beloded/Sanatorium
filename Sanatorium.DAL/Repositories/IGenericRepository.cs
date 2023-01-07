using Sanatorium.DAL.Entities;
using System.Linq.Expressions;

namespace Sanatorium.DAL.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : EntityBase
    {
        Task AddAsync(TEntity entity, CancellationToken cancellationToken);

        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);

        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);

        Task<TEntity?> GetOneAsync(int id, CancellationToken cancellationToken);

        Task<List<TEntity>> GetAll(CancellationToken cancellationToken);

        Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    }

}
