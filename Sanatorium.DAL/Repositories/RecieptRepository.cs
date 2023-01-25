using Microsoft.EntityFrameworkCore;
using Sanatorium.DAL.Context;
using Sanatorium.DAL.Entities;

namespace Sanatorium.DAL.Repositories
{
    public class RecieptRepository : IRecieptRepository
    {
        private EFContext _db;

        private DbSet<Reciept> _table;

        public RecieptRepository(EFContext db)
        {
            _db= db;
            _table = _db.Set<Reciept>();
        }

        public async Task DeleteRecieptAsync(Reciept reciept, CancellationToken cancellationToken)
        {
            _table.Remove(reciept);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Reciept>> GetAll(CancellationToken cancellationToken)
        {
            return await _table.AsNoTracking()
                               .Include(x => x.Voucher)
                                    .ThenInclude(x => x.Patient)
                               .ToListAsync(cancellationToken);
        }

        public async Task<Reciept?> GetOneAsync(int id, CancellationToken cancellationToken)
        {
            return await _table.FirstOrDefaultAsync<Reciept>(entity => entity.Id == id, cancellationToken);
        }

        public async Task<Reciept?> GetOneWithPatient(int id, CancellationToken cancellationToken)
        {
            return await _table.Include(x => x.Voucher)
                               .ThenInclude(x => x.Patient)
                               .FirstOrDefaultAsync<Reciept>(entity => entity.Id == id, cancellationToken);
        }
    }
}
