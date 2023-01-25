using Sanatorium.BLL.DTOs;
using Sanatorium.BLL.IServices;
using Sanatorium.BLL.Maping;
using Sanatorium.DAL.Entities;
using Sanatorium.DAL.Repositories;
using System.Linq.Expressions;

namespace Sanatorium.BLL.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepositoy _repository;

        private readonly Mapper _mapper = new Mapper();

        public PatientService(IPatientRepositoy repository)
        {
            _repository = repository;
        }

        public async Task AddPateintAsync(PatientDto patientDto, CancellationToken cancellationToken)
        {
            var entity = _mapper.MapFromDto(patientDto);
            await _repository.AddPatientAsync(entity, cancellationToken);
        }

        public async Task<List<PatientDto>> GetAllPatients(CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllPatients(cancellationToken);
            return _mapper.MapToDto(entities);
        }

        public async Task<List<PatientDto>> GetAllPatients(Expression<Func<Patient, bool>> predicate, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllPatients(predicate, cancellationToken);
            return _mapper.MapToDto(entities);
        }

        public async Task<PatientDto> GetOnePatientAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetOneAsync(id, cancellationToken);
            if(entity == null)
            {
                throw new ArgumentNullException();
            }
            return _mapper.MapToDto(entity);
        }

        public async Task<List<PatientDto>> GetPatientsOrdered(CancellationToken cancellationToken)
        {
            var entities = await _repository.GetPatientsOrdered(cancellationToken);
            return _mapper.MapToDto(entities);
        }

        public async Task RemovePateintAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetOneAsync(id, cancellationToken);
            await _repository.DeletePatientAsync(entity, cancellationToken);
        }

        public async Task UpdatePatientAsync(PatientDto patientDto, CancellationToken cancellationToken)
        {
            var entity = _mapper.MapFromDto(patientDto);
            await _repository.UpdatePatientAsync(entity, cancellationToken);
        }
    }
}
