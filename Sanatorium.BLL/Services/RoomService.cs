using Sanatorium.BLL.DTOs;
using Sanatorium.BLL.IServices;
using Sanatorium.BLL.Maping;
using Sanatorium.DAL.Entities;
using Sanatorium.DAL.Repositories;
using System.Linq.Expressions;

namespace Sanatorium.BLL.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _repository;

        private readonly Mapper _mapper = new Mapper();

        public RoomService(IRoomRepository repository) 
        {
            _repository= repository;
        }

        public async Task AddRoomAsync(RoomDto roomDto, CancellationToken cancellationToken)
        {
            var entity = _mapper.MapFromDto(roomDto);
            await _repository.AddRoomAsync(entity, cancellationToken);
        }

        public async Task<List<RoomDto>> GetAllRooms(CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllRooms(cancellationToken);
            return _mapper.MapToDto(entities);
        }

        public async Task<List<RoomDto>> GetAllRooms(Expression<Func<Room, bool>> predicate, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllRooms(predicate, cancellationToken);
            return _mapper.MapToDto(entities);
        }

        public async Task<List<RoomDto>> GetAvaliableRooms(CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAvaliableRooms(cancellationToken);
            return _mapper.MapToDto(entities);
        }

        public async Task<RoomDto> GetOneRoomAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetOneAsync(id, cancellationToken);
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            return _mapper.MapToDto(entity);
        }

        public async Task RemoveRoomAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetOneAsync(id, cancellationToken);
            await _repository.DeleteRoomAsync(entity, cancellationToken);
        }

        public async Task UpdateRoomAsync(RoomDto roomDto, CancellationToken cancellationToken)
        {
            var entity = _mapper.MapFromDto(roomDto);
            await _repository.UpdateRoomAsync(entity, cancellationToken);
        }
    }
}
