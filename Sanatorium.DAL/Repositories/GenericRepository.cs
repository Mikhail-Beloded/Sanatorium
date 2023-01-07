using Microsoft.EntityFrameworkCore;
using Sanatorium.DAL.Context;
using Sanatorium.DAL.Entities;
using System.Linq.Expressions;

namespace Sanatorium.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : EntityBase
    {
        private EFContext _db;

        private DbSet<TEntity> _table;

        public GenericRepository(EFContext db)
        {
            _db = db;
            _table = _db.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            _table.Attach(entity);
            await _table.AddAsync(entity, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
        {
            _table.Remove(entity);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<TEntity>> GetAll(CancellationToken cancellationToken)
        {
            return await _table.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _table.AsNoTracking().Where(predicate).ToListAsync(cancellationToken);
        }

        public async Task<TEntity?> GetOneAsync(int id, CancellationToken cancellationToken)
        {
            return await _table.FirstOrDefaultAsync<TEntity>(entity => entity.Id == id, cancellationToken);
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            _table.Update(entity);
            _db.Attach<TEntity>(entity).State= EntityState.Modified;
            _db.Entry<TEntity>(entity).State= EntityState.Modified;
            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
