using Microsoft.EntityFrameworkCore;
using Sanatorium.DAL.Context;
using Sanatorium.DAL.Entities;
using Sanatorium.DAL.Paging;
using System.Linq.Expressions;
using System.Security.Cryptography;

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
            await _table.AddAsync(entity, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
        {
            _table.Remove(entity);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return  _table.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity?> GetOneAsync(int id, CancellationToken cancellationToken)
        {
            return await _table.FirstOrDefaultAsync<TEntity>(entity => entity.Id == id, cancellationToken);
        }

        public async Task<PagedList<TEntity>> GetPageAsync(PageParameters parameters, CancellationToken cancellationToken)
        {
            var entities = await this._table
                                     .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                                     .Take(parameters.PageSize)
                                     .ToListAsync(cancellationToken);

            var count = await this._table.CountAsync(cancellationToken);

            return new PagedList<TEntity>(entities, parameters, count);
        }

        public async Task<PagedList<TEntity>> GetPageAsync(PageParameters parameters, Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            var entities = await this._table
                                     .Where(predicate)
                                     .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                                     .Take(parameters.PageSize)
                                     .ToListAsync(cancellationToken);

            var count = await this._table.CountAsync(cancellationToken);

            return new PagedList<TEntity>(entities, parameters, count);
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            _table.Update(entity);
            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
