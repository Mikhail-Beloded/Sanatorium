using Sanatorium.BLL.DTOs;
using Sanatorium.BLL.IServices;
using Sanatorium.BLL.Maping;
using Sanatorium.DAL.Entities;
using Sanatorium.DAL.Repositories;

namespace Sanatorium.BLL.Services
{
    public class ProcedureService : IProcedureService
    {
        private readonly IGenericRepository<Procedure> _repository;

        private readonly Mapper _mapper = new Mapper();

        public ProcedureService(IGenericRepository<Procedure> repository)
        {
            _repository = repository;
        }

        public async Task AddProcedureAsync(ProcedureDto procedure, CancellationToken cancellationToken)
        {
            var entity = _mapper.MapFromDto(procedure);
            await _repository.AddAsync(entity, cancellationToken);
        }

        public async Task<List<ProcedureDto>> GetAllProcedures(CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAll(cancellationToken);
            return _mapper.MapToDto(entities);
        }

        public async Task<ProcedureDto> GetOneProcedureAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetOneAsync(id, cancellationToken);
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            return _mapper.MapToDto(entity);
        }

        public async Task RemoveProcedureAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetOneAsync(id, cancellationToken);
            await _repository.DeleteAsync(entity, cancellationToken);
        }

        public async Task UpdateProcedureAsync(ProcedureDto procedure, CancellationToken cancellationToken)
        {
            var entity = _mapper.MapFromDto(procedure);
            await _repository.UpdateAsync(entity, cancellationToken);
        }
    }
}
