using Sanatorium.DAL.Entities;

namespace Sanatorium.DAL.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : EntityBase
    {
        Task AddAsync(TEntity entity, CancellationToken cancellationToken);

        Task DeleteAsync (TEntity entity, CancellationToken cancellationToken);

        Task<TEntity?> GetOneAsync(int id, CancellationToken cancellationToken);
    }
}
