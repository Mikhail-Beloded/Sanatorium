using Microsoft.EntityFrameworkCore;
using Sanatorium.DAL.Context;
using Sanatorium.DAL.Entities;

namespace Sanatorium.DAL.Repositories
{
    public class VoucherRepository : IVoucherRepository
    {
        private EFContext _db;

        private DbSet<Voucher> _table;
        public VoucherRepository(EFContext db)
        {
            _db= db;
            _table= _db.Set<Voucher>();
        }

        public async Task AddAsync(Voucher voucher, CancellationToken cancellationToken)
        {
            _table.Attach(voucher);
            await _table.AddAsync(voucher, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Voucher>> GetAll(CancellationToken cancellationToken)
        {
            return await _table.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<List<Voucher>> GetAllVouchersWithoutDoctors(CancellationToken cancellationToken)
        {
            return await _table.AsNoTracking()
                               .Include(x => x.Patient)
                               .Include(x => x.Illness)
                               .Where(x => x.Doctor == null)
                               .ToListAsync(cancellationToken);
        }

        public async Task<List<Voucher>> GetAllVouchersWithoutProcedures(CancellationToken cancellationToken)
        {
            return await _table.AsNoTracking()
                               .Include(x => x.Patient)
                               .Include(x => x.Illness)
                               .Where(x => x.VoucherProcedures.Count == 0)
                               .ToListAsync(cancellationToken);
        }

        public async Task<Voucher?> GetOneAsync(int id, CancellationToken cancellationToken)
        {
            return await _table.Include(x => x.Illness)
                               .Include(x => x.Patient)
                               .FirstOrDefaultAsync<Voucher>(entity => entity.Id == id, cancellationToken);
        }

        public async Task UpdateAsync(Voucher voucher, CancellationToken cancellationToken)
        {
            _table.Update(voucher);
            _db.Attach<Voucher>(voucher).State = EntityState.Modified;
            _db.Entry<Voucher>(voucher).State = EntityState.Modified;
            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
