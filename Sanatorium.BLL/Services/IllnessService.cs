using Sanatorium.BLL.DTOs;
using Sanatorium.BLL.IServices;
using Sanatorium.BLL.Maping;
using Sanatorium.DAL.Entities;
using Sanatorium.DAL.Repositories;

namespace Sanatorium.BLL.Services
{
   public class IllnessService : IIllnessService
    {
        private readonly IGenericRepository<Illness> _repository;

        private readonly Mapper _mapper = new Mapper();

        public IllnessService(IGenericRepository<Illness> repository)
        {
            _repository= repository;
        }

        public async Task AddIllnessAsync(IllnessDto illness, CancellationToken cancellationToken)
        {
            var entity = _mapper.MapFromDto(illness);
            await _repository.AddAsync(entity, cancellationToken);
        }

        public async Task<List<IllnessDto>> GetAllIllnesses(CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAll(cancellationToken);
            return _mapper.MapToDto(entities);
        }

        public async Task<IllnessDto> GetOneIllnessAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetOneAsync(id, cancellationToken);
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            return _mapper.MapToDto(entity);
        }

        public async Task RemoveIllnessAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetOneAsync(id, cancellationToken);
            await _repository.DeleteAsync(entity, cancellationToken);
        }

        public async Task UpdateIllnessAsync(IllnessDto illness, CancellationToken cancellationToken)
        {
            var entity = _mapper.MapFromDto(illness);
            await _repository.UpdateAsync(entity, cancellationToken);
        }
    }
}