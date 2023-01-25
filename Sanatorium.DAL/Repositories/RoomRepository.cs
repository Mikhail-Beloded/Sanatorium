using Microsoft.EntityFrameworkCore;
using Sanatorium.DAL.Context;
using Sanatorium.DAL.Entities;
using System.Linq.Expressions;

namespace Sanatorium.DAL.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private EFContext _db;

        private DbSet<Room> _table;

        public RoomRepository(EFContext db)
        {
            _db= db;
            _table = _db.Set<Room>();
        }

        public async Task AddRoomAsync(Room room, CancellationToken cancellationToken)
        {
            _table.Attach(room);
            await _table.AddAsync(room, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteRoomAsync(Room room, CancellationToken cancellationToken)
        {
            _table.Remove(room);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Room>> GetAllRooms(CancellationToken cancellationToken)
        {
            return await _table.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<List<Room>> GetAllRooms(Expression<Func<Room, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _table.AsNoTracking().Where(predicate).ToListAsync(cancellationToken);
        }

        public async Task<Room?> GetOneAsync(int id, CancellationToken cancellationToken)
        {
            return await _table.FirstOrDefaultAsync<Room>(entity => entity.Id == id, cancellationToken);
        }

        public async Task<List<Room>> GetAvaliableRooms(CancellationToken cancellationToken)
        {
            return await _table.AsNoTracking()
                               .Where(x => x.VoucherRooms.Count < x.Capacity)
                               .ToListAsync(cancellationToken);
        }

        public async Task UpdateRoomAsync(Room room, CancellationToken cancellationToken)
        {
            _table.Update(room);
            _db.Attach<Room>(room).State = EntityState.Modified;
            _db.Entry<Room>(room).State = EntityState.Modified;
            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
