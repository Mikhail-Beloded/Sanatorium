using Sanatorium.DAL.Entities;
using System.Linq.Expressions;

namespace Sanatorium.DAL.Repositories
{
    public interface IRoomRepository
    {
        Task AddRoomAsync(Room room, CancellationToken cancellationToken);

        Task DeleteRoomAsync(Room room, CancellationToken cancellationToken);

        Task UpdateRoomAsync(Room room, CancellationToken cancellationToken);

        Task<Room?> GetOneAsync(int id, CancellationToken cancellationToken);

        Task<List<Room>> GetAllRooms(CancellationToken cancellationToken);

        Task<List<Room>> GetAllRooms(Expression<Func<Room, bool>> predicate, CancellationToken cancellationToken);

        Task<List<Room>> GetAvaliableRooms(CancellationToken cancellationToken);
    }
}
