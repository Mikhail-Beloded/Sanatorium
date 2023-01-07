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
        private readonly IGenericRepository<Room> _repository;

        private readonly Mapper _mapper = new Mapper();

        public RoomService(IGenericRepository<Room> repository) 
        {
            _repository= repository;
        }

        public async Task AddRoomAsync(RoomDto roomDto, CancellationToken cancellationToken)
        {
            var entity = _mapper.MapFromDto(roomDto);
            await _repository.AddAsync(entity, cancellationToken);
        }

        public async Task<List<RoomDto>> GetAllRooms(CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAll(cancellationToken);
            return _mapper.MapToDto(entities);
        }

        public async Task<List<RoomDto>> GetAllRooms(Expression<Func<Room, bool>> predicate, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAll(predicate, cancellationToken);
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
            await _repository.DeleteAsync(entity, cancellationToken);
        }

        public async Task UpdateRoomAsync(RoomDto roomDto, CancellationToken cancellationToken)
        {
            var entity = _mapper.MapFromDto(roomDto);
            await _repository.UpdateAsync(entity, cancellationToken);
        }
    }
}
