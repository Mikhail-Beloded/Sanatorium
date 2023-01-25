using Microsoft.EntityFrameworkCore;
using Sanatorium.DAL.Context;
using Sanatorium.DAL.Entities;

namespace Sanatorium.DAL.Repositories
{
    public class VoucherRoomRepository : IVoucherRoomRepository
    {
        private EFContext _db;

        private DbSet<VoucherRoom> _table;

        public VoucherRoomRepository(EFContext db)
        {
            _db= db;
            _table = _db.Set<VoucherRoom>();
        }

        public async Task AddVoucherRoomAsync(VoucherRoom entity, CancellationToken cancellationToken)
        {
            _table.Attach(entity);
            await _table.AddAsync(entity, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
