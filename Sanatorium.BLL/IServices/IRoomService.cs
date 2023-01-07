using Sanatorium.BLL.DTOs;
using Sanatorium.DAL.Entities;
using System.Linq.Expressions;

namespace Sanatorium.BLL.IServices
{
    public interface IRoomService
    {
        Task<List<RoomDto>> GetAllRooms(CancellationToken cancellationToken);

        Task<List<RoomDto>> GetAllRooms(Expression<Func<Room, bool>> predicate, CancellationToken cancellationToken);

        Task AddRoomAsync(RoomDto roomDto, CancellationToken cancellationToken);

        Task RemoveRoomAsync(int id, CancellationToken cancellationToken);

        Task<RoomDto> GetOneRoomAsync(int id, CancellationToken cancellationToken);

        Task UpdateRoomAsync(RoomDto roomDto, CancellationToken cancellationToken);
    }
}
